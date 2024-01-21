using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

public abstract partial class StreamProfile : IDisposablePlus
{
    private readonly Native.PtrWrapper<ObStreamProfilePtr> obStreamProfilePtr;

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    private StreamProfile(Native.PtrWrapper<ObStreamProfilePtr> ptr, StreamType streamType)
    {
        if (!IsSupportedStreamType(streamType))
            throw new ArgumentException($"The {GetType().Name} stream is not compatible with the stream type {streamType}.", nameof(streamType));
        StreamType = streamType;
        obStreamProfilePtr = ptr;
        obStreamProfilePtr.Disposed += obStreamProfilePtr_Disposed;
    }

    private StreamProfile(Native.PtrWrapper<ObStreamProfilePtr> ptr)
        : this(ptr, GetStreamType(ptr.ValueNotDisposed))
    { }

    private static StreamType GetStreamType(ObStreamProfilePtr ptr)
    {
        var res = Native.StreamProfileApi.StreamProfile.Type(ptr, out var error);
        ObException.CheckError(ref error);
        return res;
    }

    internal static StreamProfile FromNativePtr(Native.PtrWrapper<ObStreamProfilePtr> ptr)
    {
        var type = GetStreamType(ptr.ValueNotDisposed);
        if (Video.IsCompatibleWith(type))
            return new Video(ptr, type);
        if (Accel.IsCompatibleWith(type))
            return new Accel(ptr, type);
        if (Gyro.IsCompatibleWith(type))
            return new Gyro(ptr, type);
        throw new NotSupportedException();
    }

    protected abstract bool IsSupportedStreamType(StreamType streamType);

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obStreamProfilePtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obStreamProfilePtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obStreamProfilePtr_Disposed(object? sender, EventArgs e)
    {
        obStreamProfilePtr.Disposed -= obStreamProfilePtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    public StreamType StreamType { get; }

    public DataFormat DataFormat
        => Helpers.GetValue(Native.StreamProfileApi.StreamProfile.Format, obStreamProfilePtr);

    internal ObStreamProfilePtr NativePtr => obStreamProfilePtr.ValueNotDisposed;

    public override int GetHashCode()
        => obStreamProfilePtr.GetHashCode();

    public override string ToString()
        => obStreamProfilePtr.ToString();
}
