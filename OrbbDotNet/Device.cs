using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>Main class to communicate with device.</summary>
/// <remarks>
/// Device-related functions, including operations such as obtaining and creating a device,
/// setting and obtaining device property, and obtaining sensors.
/// </remarks>
public sealed class Device : IDisposablePlus
{
    private readonly Native.PtrWrapper<ObDevicePtr> obDevicePtr;
    private readonly Lazy<DevicePropertyList> supportedProperties;
    private event EventHandler<DeviceStateChangedEventArgs>? deviceStateChangedImpl;
    private IntPtr? callbackUserData;
    private readonly object callbackUserDataSync = new();

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    internal Device(Native.PtrWrapper<ObDevicePtr> ptr)
    {
        obDevicePtr = ptr;
        obDevicePtr.Disposed += obDevicePtr_Disposed;
        supportedProperties = new(() => new DevicePropertyList(this), isThreadSafe: true);
    }

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
    {
        if (supportedProperties.IsValueCreated)
            supportedProperties.Value.Dispose();
        obDevicePtr.Dispose();
    }

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obDevicePtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obDevicePtr_Disposed(object? sender, EventArgs e)
    {
        lock (callbackUserDataSync)
        {
            if (callbackUserData.HasValue)
            {
                IntPtrToObjectMap<Device>.Unregister(callbackUserData.Value);
                callbackUserData = null;
            }
        }

        obDevicePtr.Disposed -= obDevicePtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    /// <summary>Value of native pointer is used as hash.</summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
        => obDevicePtr.GetHashCode();

    /// <summary>String representation of native pointer.</summary>
    /// <returns>HEX value of native pointer with type-specific prefix.</returns>
    public override string ToString()
        => obDevicePtr.ToString();

    #region General info

    /// <summary>Native pointer associated with this managed wrapper.</summary>
    internal ObDevicePtr NativePtr => obDevicePtr.ValueNotDisposed;

    /// <summary>Device information.</summary>
    public DeviceInfo DeviceInfo
        => new(Helpers.GetValue(Native.DeviceApi.Device.GetDeviceInfo, obDevicePtr));

    /// <summary>The protocol version of the device.</summary>
    public ProtocolVersion ProtocolVersion
        => Helpers.GetValue(Native.DeviceApi.Device.GetProtocolVersion, obDevicePtr);

    #endregion

    /// <summary>List of sensors present in the device.</summary>
    public SensorList SensorList
        => new(Helpers.GetValue(Native.DeviceApi.Device.GetSensorList, obDevicePtr));

    /// <summary>Gets a device's sensor by its type.</summary>
    /// <param name="sensorType">Type of sensor to get.</param>
    /// <returns>The acquired sensor.</returns>
    public Sensor GetSensor(SensorType sensorType)
    {
        var ptr = Native.DeviceApi.Device.GetSensor(NativePtr, sensorType, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }

    /// <summary>Gets the original parameter list of camera calibration saved on the device.</summary>
    /// <remarks>
    /// The parameters in the list do not correspond to the current open-stream configuration.
    /// You need to select the parameters according to the actual situation,
    /// and may need to do scaling, mirroring and other processing.
    /// Non-professional users are recommended to use the <see cref="Pipeline.CameraParam"/> property of <see cref="Pipeline"/> class.
    /// </remarks>
    public CameraParamList CalibrationCameraParamList
        => new(Helpers.GetValue(Native.DeviceApi.Device.GetCalibrationCameraParamList, obDevicePtr));

    /// <summary>Gets the current depth work mode.</summary>
    public DepthWorkMode CurrentDepthWorkMode
        => Helpers.GetValue(Native.DeviceApi.Device.GetCurrentDepthWorkMode, obDevicePtr);

    /// <summary>Switches the depth work mode obtained from <see cref="DepthWorkModeList"/> property.</summary>
    /// <param name="workMode">The depth work mode from <see cref="OrbbDotNet.DepthWorkModeList"/> object which is returned by <see cref="DepthWorkModeList"/> property.</param>
    /// <returns>The switch result. <see langword="true"/>: success, <see langword="false"/> - failed.</returns>
    public bool SwitchDepthWorkMode(ref DepthWorkMode workMode)
    {
        var res = Native.DeviceApi.Device.SwitchDepthWorkMode(NativePtr, ref workMode, out var error);
        ObException.CheckError(ref error);
        return res == ObStatus.Ok;
    }

    /// <summary>Switches the depth work mode by work mode name.</summary>
    /// <param name="workModeName">The depth work mode name which is equal to <see cref="DepthWorkMode.Name"/>.</param>
    /// <returns>The switch result. <see langword="true"/>: success, <see langword="false"/> - failed.</returns>
    public bool SwitchDepthWorkMode(string workModeName)
    {
        var res = Native.DeviceApi.Device.SwitchDepthWorkModeByName(NativePtr, workModeName, out var error);
        ObException.CheckError(ref error);
        return res == ObStatus.Ok;
    }

    /// <summary>Requests the list of supported depth work modes.</summary>
    public DepthWorkModeList DepthWorkModeList
        => new(Helpers.GetValue(Native.DeviceApi.Device.GetDepthWorkModeList, obDevicePtr));

    #region State

    /// <summary>Gets the current device status.</summary>
    public DeviceState State => Helpers.GetValue(Native.DeviceApi.Device.GetDeviceState, obDevicePtr);

    /// <summary>Monitor device state changes.</summary>
    public event EventHandler<DeviceStateChangedEventArgs>? StateChanged
    {
        add
        {
            bool notRegistered = false;
            lock (callbackUserDataSync)
            {
                if (!callbackUserData.HasValue)
                {
                    callbackUserData = IntPtrToObjectMap<Device>.Register(this);
                    notRegistered = true;
                }
            }

            if (notRegistered)
            {
                Native.DeviceApi.Device.StateChanged(NativePtr, deviceStateChangedCallback, callbackUserData.Value, out var error);
                ObException.CheckError(ref error);
            }

            deviceStateChangedImpl += value;
        }

        remove
        {
            deviceStateChangedImpl -= value;
        }
    }

    private static void OnDeviceStateChanged(DeviceState state, IntPtr message, IntPtr userData)
    {
        if (IntPtrToObjectMap<Device>.TryGet(userData, out var device)
            && device.callbackUserData == userData)
        {
            var msg = Marshal.PtrToStringAnsi(message);
            var args = new DeviceStateChangedEventArgs(state, msg);
            device.deviceStateChangedImpl?.Invoke(device, args);
        }
    }

    private static readonly ObDeviceStateCallback deviceStateChangedCallback = OnDeviceStateChanged;

    #endregion

    #region Properties

    /// <summary>Gets the list of properties supported by the device.</summary>
    public DevicePropertyList SupportedProperties => supportedProperties.Value;

    /// <summary>Gets raw data of a device property.</summary>
    /// <param name="propertyId">The ID of the property.</param>
    /// <param name="receiveCallback">The get data callback.</param>
    public void GetRawData(PropertyId propertyId, DataReceiveCallback receiveCallback)
    {
        var userData = IntPtrToObjectMap<DataReceiveCallback>.Register(receiveCallback);
        try
        {
            Native.DeviceApi.Device.GetRawData(NativePtr, propertyId, getDataCallback,
                async: false, userData: userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<DataReceiveCallback>.Unregister(userData);
        }
    }

    private static void OnGetRawData(DataTransferState state, DataChunk dataChunk, IntPtr userData)
    {
        if (IntPtrToObjectMap<DataReceiveCallback>.TryGet(userData, out var callback))
            callback.Invoke(state, dataChunk);
    }

    private static readonly ObGetDataCallback getDataCallback = OnGetRawData;

    /// <summary>Sets raw data of a device property.</summary>
    /// <param name="propertyId">The ID of the property to be set.</param>
    /// <param name="dataPtr">The property data to be set.</param>
    /// <param name="dataSizeBytes">The size of the property data to be set.</param>
    /// <param name="progressCallback">The set data callback.</param>
    public void SetRawData(PropertyId propertyId, IntPtr dataPtr, int dataSizeBytes, DataSendCallback progressCallback)
    {
        var userData = IntPtrToObjectMap<DataSendCallback>.Register(progressCallback);
        try
        {
            Native.DeviceApi.Device.SetRawData(NativePtr, propertyId, dataPtr, (uint)dataSizeBytes, setDataCallback,
                async: false, userData: userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<DataSendCallback>.Unregister(userData);
        }
    }

    private static void OnSetRawData(DataTransferState state, byte percent, IntPtr userData)
    {
        if (IntPtrToObjectMap<DataSendCallback>.TryGet(userData, out var callback))
            callback.Invoke(state, percent);
    }

    private static readonly ObSetDataCallback setDataCallback = OnSetRawData;

    #endregion

    #region Reading and writing of: AHB/I2C registers, flash memory, custom data

    public uint ReadAhb(uint register, uint mask)
    {
        Native.DeviceApi.Device.ReadAhb(NativePtr, register, mask, out var value, out var error);
        ObException.CheckError(ref error);
        return value;
    }

    public void WriteAhb(uint register, uint mask, uint value)
    {
        Native.DeviceApi.Device.WriteAhb(NativePtr, register, mask, value, out var error);
        ObException.CheckError(ref error);
    }

    public uint ReadI2C(uint moduleId, uint register, uint mask)
    {
        Native.DeviceApi.Device.ReadI2C(NativePtr, moduleId, register, mask, out var value, out var error);
        ObException.CheckError(ref error);
        return value;
    }

    public void WriteI2C(uint moduleId, uint register, uint mask, uint value)
    {
        Native.DeviceApi.Device.WriteI2C(NativePtr, moduleId, register, mask, value, out var error);
        ObException.CheckError(ref error);
    }

    public void ReadFlash(int offset, int dataSize, DataReceiveCallback receiveCallback)
    {
        var userData = IntPtrToObjectMap<DataReceiveCallback>.Register(receiveCallback);
        try
        {
            Native.DeviceApi.Device.ReadFlash(NativePtr, (uint)offset, (uint)dataSize, getDataCallback,
                async: false, userData: userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<DataReceiveCallback>.Unregister(userData);
        }
    }

    public void WriteFlash(int offset, IntPtr dataPtr, int dataSizeBytes, DataSendCallback progressCallback)
    {
        var userData = IntPtrToObjectMap<DataSendCallback>.Register(progressCallback);
        try
        {
            Native.DeviceApi.Device.WriteFlash(NativePtr, (uint)offset, dataPtr, (uint)dataSizeBytes,
                setDataCallback, async: false, userData: userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<DataSendCallback>.Unregister(userData);
        }
    }

    public void ReadCustomerData(IntPtr bufferPtr, ref int dataSizeBytes)
    {
        uint size = (uint)dataSizeBytes;
        Native.DeviceApi.Device.ReadCustomerData(NativePtr, bufferPtr, ref size, out var error);
        ObException.CheckError(ref error);
        dataSizeBytes = (int)size;
    }

    public void WriteCustomerData(IntPtr dataPtr, int dataSizeBytes)
    {
        Native.DeviceApi.Device.WriteCustomerData(NativePtr, dataPtr, dataSize:(uint)dataSizeBytes, out var error);
        ObException.CheckError(ref error);
    }

    public void SendFileToDestination(string filePath, string dstPath, FileTransferCallback progressCallback)
    {
        var userData = IntPtrToObjectMap<FileTransferCallback>.Register(progressCallback);
        try
        {
            Native.DeviceApi.Device.SendFileToDestination(NativePtr, filePath, dstPath,
                fileSendCallback, async: false, userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<FileTransferCallback>.Unregister(userData);
        }
    }

    private static void OnFileSindingProgress(FileTransferState state, IntPtr message, byte percent, IntPtr userData)
    {
        if (IntPtrToObjectMap<FileTransferCallback>.TryGet(userData, out var callback))
        {
            var msg = Marshal.PtrToStringAnsi(message);
            callback.Invoke(state, msg, percent);
        }
    }

    private static readonly ObFileSendCallback fileSendCallback = OnFileSindingProgress;

    #endregion

    #region Management

    public void Upgrade(string path, UpgradeCallback progressCallback)
    {
        var userData = IntPtrToObjectMap<UpgradeCallback>.Register(progressCallback);
        try
        {
            Native.DeviceApi.Device.Upgrade(NativePtr, path,
                deviceUpgradeCallback, async: false, userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<UpgradeCallback>.Unregister(userData);
        }
    }

    public void UpgradeFromData(IntPtr dataPtr, int dataSizeBytes, UpgradeCallback progressCallback)
    {
        var userData = IntPtrToObjectMap<UpgradeCallback>.Register(progressCallback);
        try
        {
            Native.DeviceApi.Device.UpgradeFromData(NativePtr, dataPtr, (uint)dataSizeBytes,
                deviceUpgradeCallback, async: false, userData, out var error);
            ObException.CheckError(ref error);
        }
        finally
        {
            IntPtrToObjectMap<UpgradeCallback>.Unregister(userData);
        }
    }

    private static void OnDeviceUpgrading(UpgradeState state, IntPtr message, byte percent, IntPtr userData)
    {
        if (IntPtrToObjectMap<UpgradeCallback>.TryGet(userData, out var callback))
            callback.Invoke(state, Marshal.PtrToStringAnsi(message), percent);
    }

    private static readonly ObDeviceUpgradeCallback deviceUpgradeCallback = OnDeviceUpgrading;

    public bool ActivateAuthorization(string authCode)
    {
        var res = Native.DeviceApi.Device.ActivateAuthorization(NativePtr, authCode, out var error);
        ObException.CheckError(ref error);
        return res;
    }

    public void WriteAuthorizationCode(string authCode)
    {
        Native.DeviceApi.Device.WriteAuthorizationCode(NativePtr, authCode, out var error);
        ObException.CheckError(ref error);
    }

    public void Reboot()
    {
        Native.DeviceApi.Device.Reboot(NativePtr, out var error);
        ObException.CheckError(ref error);
    }

    #endregion
}
