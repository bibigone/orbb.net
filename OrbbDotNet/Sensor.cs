using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

public sealed class Sensor : IDisposablePlus
{
    private static readonly ObFrameCallback frameReadyCallback = OnFrameReady;     // to keep pointer to callback in memory

    private readonly Native.PtrWrapper<ObSensorPtr> obSensorPtr;
    private IntPtr? callbackUserData;
    private readonly object callbackUserDataSync = new();

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    internal Sensor(Native.PtrWrapper<ObSensorPtr> ptr)
    {
        obSensorPtr = ptr;
        obSensorPtr.Disposed += obSensorPtr_Disposed;
    }

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obSensorPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obSensorPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obSensorPtr_Disposed(object? sender, EventArgs e)
    {
        lock (callbackUserDataSync)
        {
            if (callbackUserData.HasValue)
            {
                IntPtrToObjectMap<Sensor>.Unregister(callbackUserData.Value);
                callbackUserData = null;
            }
        }

        obSensorPtr.Disposed -= obSensorPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    public override int GetHashCode()
        => obSensorPtr.GetHashCode();

    public override string ToString()
        => obSensorPtr.ToString();

    public SensorType SensorType
        => Helpers.GetValue(Native.SensorApi.Sensor.GetType, obSensorPtr);

    public StreamProfileList StreamProfileList
        => new(Helpers.GetValue(Native.SensorApi.Sensor.GetStreamProfileList, obSensorPtr));

    public void Start(StreamProfile streamProfile)
    {
        var userData = IntPtr.Zero;
        lock (callbackUserDataSync)
        {
            if (!callbackUserData.HasValue)
                callbackUserData = IntPtrToObjectMap<Sensor>.Register(this);
            userData = callbackUserData.Value;
        }

        Native.SensorApi.Sensor.Start(obSensorPtr.ValueNotDisposed, streamProfile.NativePtr, frameReadyCallback, userData, out var error);
        ObException.CheckError(ref error);
    }

    public void Stop()
    {
        Native.SensorApi.Sensor.Stop(obSensorPtr.ValueNotDisposed, out var error);
        ObException.CheckError(ref error);
    }

    public void SwitchProfile(StreamProfile streamProfile)
    {
        Native.SensorApi.Sensor.SwitchProfile(obSensorPtr.ValueNotDisposed, streamProfile.NativePtr, out var error);
        ObException.CheckError(ref error);
    }

    public event EventHandler<FrameReadyEventArgs>? FrameReady;

    private static void OnFrameReady(ObFramePtr frame, IntPtr userData)
    {
        using (var args = new FrameReadyEventArgs(Frame.FromNativePtr(frame)))
        {
            if (IntPtrToObjectMap<Sensor>.TryGet(userData, out var sensor) && sensor.callbackUserData == userData)
                sensor.FrameReady?.Invoke(sensor, args);
        }
    }
}
