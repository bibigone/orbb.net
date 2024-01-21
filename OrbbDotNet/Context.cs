using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>
/// The SDK context class, which serves as the entry point to the underlying SDK.
/// It is used to query device lists and handle device callbacks.
/// </summary>
/// <remarks>
/// <c>Context</c> is a management class that describes the runtime of the SDK and is responsible for resource allocation and release of the SDK.
/// Context has the ability to manage multiple devices. It is responsible for enumerating devices, monitoring device callbacks,
/// and enabling multi-device synchronization.
/// </remarks>
public sealed class Context : IDisposablePlus
{
    private static readonly ObDeviceChangedCallback deviceChangedCallback = OnDeviceChanged;     // to keep pointer to callback in memory

    private readonly Native.PtrWrapper<ObContextPtr> obContextPtr;
    private event EventHandler<DeviceListChangedEventArgs>? deviceListChangedImpl;
    private IntPtr? callbackUserData;
    private readonly object callbackUserDataSync = new();

    /// <summary>Creates managed object from native pointer.</summary>
    /// <param name="ptr">Native pointer.</param>
    private Context(Native.PtrWrapper<ObContextPtr> ptr)
    {
        obContextPtr = ptr;
        obContextPtr.Disposed += obContextPtr_Disposed;
    }

    /// <summary>Creates a context object with default configuration</summary>
    public Context() : this(Create())
    { }

    private static ObContextPtr Create()
    {
        var ptr = Native.ContextApi.CreateContext(out var error);
        ObException.CheckError(ref error);
        return ptr;
    }

    /// <summary>Creates a context object with a specified configuration file.</summary>
    /// <param name="configPath">Path to the configuration file. If file does not exist, the default configuration file will be used.</param>
    public Context(string configPath) : this(Create(configPath))
    { }

    private static ObContextPtr Create(string configPath)
    {
        var ptr = Native.ContextApi.CreateContextWithConfig(configPath, out var error);
        ObException.CheckError(ref error);
        return ptr;
    }

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obContextPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obContextPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obContextPtr_Disposed(object? sender, EventArgs e)
    {
        lock (callbackUserDataSync)
        {
            if (callbackUserData.HasValue)
            {
                IntPtrToObjectMap<Context>.Unregister(callbackUserData.Value);
                callbackUserData = null;
            }
        }

        obContextPtr.Disposed -= obContextPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    /// <summary>Value of native pointer is used as hash.</summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
        => obContextPtr.GetHashCode();

    /// <summary>String representation of native pointer.</summary>
    /// <returns>HEX value of native pointer with type-specific prefix.</returns>
    public override string ToString()
        => obContextPtr.ToString();

    /// <summary>Gets a list of connected devices</summary>
    /// <remarks><para>
    /// It is highly recommended to dispose returned device list object explicitly like:
    /// <code>
    /// using (var devices = context.DeviceList)
    /// {
    ///     // working with the list of devices
    /// }
    /// </code>
    /// </para></remarks>
    public DeviceList DeviceList
        => new(Helpers.GetValue(Native.ContextApi.QueryDeviceList, obContextPtr));

    /// <summary>List of connected devices has been changed.</summary>
    public event EventHandler<DeviceListChangedEventArgs>? DeviceListChanged
    {
        add
        {
            bool notRegistered = false;
            lock (callbackUserDataSync)
            {
                if (!callbackUserData.HasValue)
                {
                    callbackUserData = IntPtrToObjectMap<Context>.Register(this);
                    notRegistered = true;
                }
            }

            if (notRegistered)
            {
                Native.ContextApi.SetDeviceChangedCallback(obContextPtr.ValueNotDisposed, deviceChangedCallback, callbackUserData.Value, out var error);
                ObException.CheckError(ref error);
            }

            deviceListChangedImpl += value;
        }

        remove
        {
            deviceListChangedImpl -= value;
        }
    }

    // Callback from native SDK
    private static void OnDeviceChanged(ObDeviceListPtr removed, ObDeviceListPtr added, IntPtr userData)
    {
        var removedDevices = new DeviceList(removed);
        var addedDevices = new DeviceList(added);
        using (var args = new DeviceListChangedEventArgs(removedDevices, addedDevices))
        {
            if (IntPtrToObjectMap<Context>.TryGet(userData, out var context)
                && context.callbackUserData == userData)
            {
                context.deviceListChangedImpl?.Invoke(context, args);
            }
        }
    }

    /// <summary>Enables or disables network device enumeration.</summary>
    /// <param name="enable"><see langword="true"/> to enable, <see langword="false"/> to disable</param>
    public void EnableNetDeviceEnumeration(bool enable)
    {
        Native.ContextApi.EnableNetDeviceEnumeration(obContextPtr.ValueNotDisposed, enable, out var error);
        ObException.CheckError(ref error);
    }

    /// <summary>Activates device clock synchronization to synchronize the clock of the host and all created devices (if supported).</summary>
    /// <param name="repeatInterval">The interval for auto-repeated synchronization. If the value is <see cref="TimeSpan.Zero"/>, synchronization is performed only once.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="repeatInterval"/> cannot be negative.</exception>
    public void EnableDeviceClockSync(TimeSpan repeatInterval)
    {
        var ms = repeatInterval.TotalMilliseconds;
        if (ms < 0) throw new ArgumentOutOfRangeException(nameof(repeatInterval), $"Repeat interval cannot be negative");
        var msUInt64 = (ulong)Math.Round(ms);
        Native.ContextApi.EnableDeviceClockSync(obContextPtr.ValueNotDisposed, msUInt64, out var error);
        ObException.CheckError(ref error);
    }

    /// <summary>Free idle memory from the internal frame memory pool.</summary>
    public void FreeIdleMemory()
    {
        Native.ContextApi.FreeIdleMemory(obContextPtr.ValueNotDisposed, out var error);
        ObException.CheckError(ref error);
    }
}
