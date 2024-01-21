using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>List of devices.</summary>
public sealed class DeviceList : IDisposablePlus, IReadOnlyList<IBasicDeviceInfo>
{
    private readonly Native.PtrWrapper<ObDeviceListPtr> obDeviceListPtr;
    private readonly Lazy<int> lazyCount;

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    internal DeviceList(Native.PtrWrapper<ObDeviceListPtr> ptr)
    {
        lazyCount = new(GetCount, isThreadSafe: true);
        obDeviceListPtr = ptr;
        obDeviceListPtr.Disposed += obDeviceListPtr_Disposed;
    }

    // for lazyCount
    private int GetCount()
        => (int)Helpers.GetValue(Native.DeviceApi.DeviceList.DeviceCount, obDeviceListPtr);

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obDeviceListPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obDeviceListPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obDeviceListPtr_Disposed(object? sender, EventArgs e)
    {
        obDeviceListPtr.Disposed -= obDeviceListPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region IReadOnlyList<IBasicDeviceInfo>

    /// <summary>Information about device with specified index.</summary>
    /// <param name="index">Zero-based device index.</param>
    /// <returns>Information about device in the list.</returns>
    /// <exception cref="IndexOutOfRangeException">Index cannot be negative and cannot be greater or equal to <see cref="Count"/>.</exception>
    public IBasicDeviceInfo this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            return new DeviceListItem(this, index);
        }
    }

    /// <summary>The number of items in the list.</summary>
    public int Count => lazyCount.Value;

    /// <summary>Implements <see cref="IEnumerable{IBasicDeviceInfo}"/>.</summary>
    /// <returns>Enumerator through all items in the list</returns>
    public IEnumerator<IBasicDeviceInfo> GetEnumerator()
    {
        var count = Count;
        for (var i = 0; i < count; i++)
            yield return this[i];
    }

    /// <summary>Implements <see cref="IEnumerable"/>.</summary>
    /// <returns>Enumerator through all items in the list</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        var count = Count;
        for (var i = 0; i < count; i++)
            yield return this[i];
    }

    #endregion

    public override int GetHashCode()
        => obDeviceListPtr.GetHashCode();

    public override string ToString()
        => obDeviceListPtr.ToString();

    /// <summary>Creates <see cref="Device"/> object for specified index in the list.</summary>
    /// <param name="index">Zero-based index of device.</param>
    /// <returns>The created device.</returns>
    /// <exception cref="IndexOutOfRangeException">Index cannot be negative and cannot be greater or equal to <see cref="Count"/>.</exception>
    /// <remarks>If the device has already been acquired and created elsewhere, repeated acquisitions will return an error.</remarks>
    public Device GetDevice(int index)
    {
        if (index < 0 | index >= Count)
            throw new IndexOutOfRangeException();
        var ptr = Native.DeviceApi.DeviceList.GetDevice(obDeviceListPtr.ValueNotDisposed, (uint)index, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }

    /// <summary>Creates <see cref="Device"/> object with specified serial number.</summary>
    /// <param name="serialNumber">The serial number of the device to be created</param>
    /// <returns>The created device.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="serialNumber"/> cannot be <see langword="null"/> or empty string.</exception>
    /// <remarks>If the device has already been acquired and created elsewhere, repeated acquisitions will return an error.</remarks>
    public Device GetDeviceBySerialNumber(string serialNumber)
    {
        if (string.IsNullOrWhiteSpace(serialNumber))
            throw new ArgumentNullException(nameof(serialNumber));
        var ptr = Native.DeviceApi.DeviceList.GetDeviceBySerialNumber(obDeviceListPtr.ValueNotDisposed, serialNumber, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }

    /// <summary>Creates <see cref="Device"/> object by UID.</summary>
    /// <param name="uid">The UID of the device to be created.</param>
    /// <returns>The created device.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uid"/> cannot be <see langword="null"/> or empty string.</exception>
    /// <remarks><para>
    /// On Linux platform, the UID of the device is composed as "{bus}-{port}-{dev}". For example: "1-1.2-1".
    /// But the SDK will remove the {dev} number and only keep the "{bus}-{port}" as the UID to create the device.
    /// For example: "1-1.2", so that we can create a device connected to the specified USB port.
    /// Similarly, users can also directly pass in "{bus}-{port}" as UID to create device.
    /// </para><para>
    /// If the device has already been acquired and created elsewhere, repeated acquisitions will return an error.
    /// </para></remarks>
    public Device GetDeviceByUid(string uid)
    {
        if (string.IsNullOrWhiteSpace(uid))
            throw new ArgumentNullException(nameof(uid));
        var ptr = Native.DeviceApi.DeviceList.GetDeviceByUid(obDeviceListPtr.ValueNotDisposed, uid, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }

    // Implements collection item
    private sealed class DeviceListItem : IBasicDeviceInfo
    {
        private readonly DeviceList owner;
        private readonly int index;

        public DeviceListItem(DeviceList owner, int index)
            => (this.owner, this.index) = (owner, index);

        private delegate T NativeGetter<T>(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        private T GetValue<T>(NativeGetter<T> nativeGetter)
        {
            var res = nativeGetter(owner.obDeviceListPtr.ValueNotDisposed, (uint)index, out var error);
            ObException.CheckError(ref error);
            return res;
        }

        private string? GetStringValue(NativeGetter<IntPtr> nativeGetter)
            => Marshal.PtrToStringAnsi(GetValue<IntPtr>(nativeGetter));

        int IBasicDeviceInfo.Pid => GetValue(Native.DeviceApi.DeviceList.GetDevicePid);
        int IBasicDeviceInfo.Vid => GetValue(Native.DeviceApi.DeviceList.GetDeviceVid);
        string? IBasicDeviceInfo.Uid => GetStringValue(Native.DeviceApi.DeviceList.GetDeviceUid);
        string? IBasicDeviceInfo.SerialNumber => GetStringValue(Native.DeviceApi.DeviceList.GetDeviceSerialNumber);
        string? IBasicDeviceInfo.ConnectionType => GetStringValue(Native.DeviceApi.DeviceList.GetDeviceConnectionType);
        string? IBasicDeviceInfo.IPAddress => GetStringValue(Native.DeviceApi.DeviceList.GetDeviceIPAddress);
        string? IBasicDeviceInfo.ExtensionInfo => GetStringValue(Native.DeviceApi.DeviceList.GetExtensionInfo);
    }
}
