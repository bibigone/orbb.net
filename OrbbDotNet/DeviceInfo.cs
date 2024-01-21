using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>Information about device.</summary>
public sealed class DeviceInfo : IDisposablePlus, IBasicDeviceInfo
{
    private readonly Native.PtrWrapper<ObDeviceInfoPtr> obDeviceInfoPtr;

    /// <summary>Creates object from native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    internal DeviceInfo(Native.PtrWrapper<ObDeviceInfoPtr> ptr)
    {
        obDeviceInfoPtr = ptr;
        obDeviceInfoPtr.Disposed += obDeviceInfoPtr_Disposed;
    }

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obDeviceInfoPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obDeviceInfoPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obDeviceInfoPtr_Disposed(object? sender, EventArgs e)
    {
        obDeviceInfoPtr.Disposed -= obDeviceInfoPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    public override int GetHashCode()
        => obDeviceInfoPtr.GetHashCode();

    public override string ToString()
        => obDeviceInfoPtr.ToString();

    private delegate T NativeGetter<T>(ObDeviceInfoPtr info, out ObErrorPtr error);

    private T GetValue<T>(NativeGetter<T> nativeGetter)
    {
        var res = nativeGetter(obDeviceInfoPtr.ValueNotDisposed, out var error);
        ObException.CheckError(ref error);
        return res;
    }

    private string? GetValue(NativeGetter<IntPtr> nativeGetter)
        => Marshal.PtrToStringAnsi(GetValue<IntPtr>(nativeGetter));

    /// <summary>Device name.</summary>
    public string? Name => GetValue(Native.DeviceApi.DeviceInfo.Name);

    /// <summary>Minimum SDK version number supported by the device</summary>
    public string? SupportedMinSdkVersion => GetValue(Native.DeviceApi.DeviceInfo.SupportedMinSdkVersion);

    /// <summary>Device chip name.</summary>
    public string? AsicName => GetValue(Native.DeviceApi.DeviceInfo.AsicName);

    /// <summary>Device type.</summary>
    public DeviceType DeviceType => GetValue(Native.DeviceApi.DeviceInfo.DeviceType);

    /// <summary>Device firmware version.</summary>
    public string? FirmwareVersion => GetValue(Native.DeviceApi.DeviceInfo.FirmwareVersion);

    /// <summary>Device hardware version.</summary>
    public string? HardwareVersion => GetValue(Native.DeviceApi.DeviceInfo.HardwareVersion);

    #region IBasicDeviceInfo

    /// <summary>Device PID (Product ID).</summary>
    public int Pid => GetValue(Native.DeviceApi.DeviceInfo.Pid);

    /// <summary>Device VID (Vendor ID).</summary>
    public int Vid => GetValue(Native.DeviceApi.DeviceInfo.Vid);

    /// <summary>Device UID.</summary>
    public string? Uid => GetValue(Native.DeviceApi.DeviceInfo.Uid);

    /// <summary>Device serial number.</summary>
    public string? SerialNumber => GetValue(Native.DeviceApi.DeviceInfo.SerialNumber);

    /// <summary>The connection type： "USB", "USB1.0", "USB1.1", "USB2.0", "USB2.1", "USB3.0", "USB3.1", "USB3.2", "Ethernet".</summary>
    public string? ConnectionType => GetValue(Native.DeviceApi.DeviceInfo.ConnectionType);

    /// <summary>Device IP address like "192.168.1.10"</summary>
    /// <remarks>Only valid for network devices, otherwise it will return "0.0.0.0".</remarks>
    public string? IPAddress => GetValue(Native.DeviceApi.DeviceInfo.IPAddress);

    /// <summary>Device extension information.</summary>
    public string? ExtensionInfo => GetValue(Native.DeviceApi.DeviceInfo.GetExtensionInfo);

    #endregion
}
