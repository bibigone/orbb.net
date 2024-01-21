using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;
using static System.Net.Mime.MediaTypeNames;

namespace OrbbDotNet;

/// <summary></summary>
public abstract partial class Frame : IDisposablePlus, IReferenceDuplicable<Frame>, IEquatable<Frame>
{
    private readonly Native.PtrWrapper<ObFramePtr> obFramePtr;

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    private Frame(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType)
    {
        FrameType = frameType;
        obFramePtr = ptr;
        obFramePtr.Disposed += obFramePtr_Disposed;
    }

    private static FrameType GetFrameType(Native.PtrWrapper<ObFramePtr> ptr)
        => Helpers.GetValue(Native.FrameApi.Frame.GetType, ptr);

    internal static Frame FromNativePtr(Native.PtrWrapper<ObFramePtr> ptr)
        => FromNativePtr(ptr, GetFrameType(ptr));

    internal static Frame FromNativePtr(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType)
        => frameType switch
        {
            FrameType.Accel => new Accel(ptr),
            FrameType.Color => new Color(ptr),
            FrameType.Depth => new Depth(ptr),
            FrameType.Gyro => new Gyro(ptr),
            FrameType.IR => new IR(ptr, FrameType.IR),
            FrameType.IRLeft => new IR(ptr, FrameType.IRLeft),
            FrameType.IRRight => new IR(ptr, FrameType.IRRight),
            FrameType.Points => new Points(ptr),
            FrameType.RawPhase => new RawPhase(ptr),
            FrameType.Video => new Video(ptr, FrameType.Video),
            FrameType.Set => new Set(ptr),
            _ => throw new NotSupportedException(),
        };

    internal static Frame? FromNativePtrNullable(ObFramePtr ptr)
        => ptr.UnsafeValue != IntPtr.Zero ? FromNativePtr(ptr) : null;

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obFramePtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obFramePtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obFramePtr_Disposed(object? sender, EventArgs e)
    {
        obFramePtr.Disposed -= obFramePtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region IReferenceDuplicable

    public Frame DuplicateReference()
    {
        var ptr = obFramePtr.ValueNotDisposed;
        ptr.AddRef();
        var refPtr = new Native.PtrWrapper<ObFramePtr>(ptr);
        try
        {
            return FromNativePtr(refPtr);
        }
        catch
        {
            refPtr.Dispose();
            throw;
        }
    }

    public T ReinterpretAs<T>() where T : Frame
    {
        var ptr = obFramePtr.ValueNotDisposed;
        ptr.AddRef();
        var refPtr = new Native.PtrWrapper<ObFramePtr>(ptr);
        try
        {
            if (typeof(T) == typeof(Color)) return (T)(Frame)new Color(refPtr, FrameType);
            if (typeof(T) == typeof(Depth)) return (T)(Frame)new Depth(refPtr, FrameType);
            if (typeof(T) == typeof(IR)) return (T)(Frame)new IR(refPtr, FrameType);
            if (typeof(T) == typeof(Points)) return (T)(Frame)new Points(refPtr, FrameType);
            if (typeof(T) == typeof(RawPhase)) return (T)(Frame)new RawPhase(refPtr, FrameType);
            if (typeof(T) == typeof(Video)) return (T)(Frame)new Video(refPtr, FrameType);
            if (typeof(T) == typeof(Accel)) return (T)(Frame)new Accel(refPtr, FrameType);
            if (typeof(T) == typeof(Gyro)) return (T)(Frame)new Gyro(refPtr, FrameType);
            if (typeof(T) == typeof(Set)) return (T)(Frame)new Set(refPtr, FrameType);
            throw new NotSupportedException();
        }
        catch
        {
            refPtr.Dispose();
            throw;
        }
    }

    #endregion

    #region Equality

    public override bool Equals(object? obj)
        => Equals(obj as Frame);

    public bool Equals(Frame? other)
        => other is not null && other.obFramePtr.Value.UnsafeValue == obFramePtr.Value.UnsafeValue;

    public static bool operator ==(Frame? left, Frame? right)
        => (left is null && right is null) || (left is not null && left.Equals(right));

    public static bool operator !=(Frame? left, Frame? right)
        => !(left == right);

    #endregion

    internal ObFramePtr NativePtr => obFramePtr.ValueNotDisposed;

    public override int GetHashCode()
        => obFramePtr.GetHashCode();

    public override string ToString()
        => obFramePtr.ToString();

    public long Index => (long)Helpers.GetValue(Native.FrameApi.Frame.Index, obFramePtr);

    public DataFormat DataFormat => Helpers.GetValue(Native.FrameApi.Frame.Format, obFramePtr);

    public FrameType FrameType { get; }

    public TimeSpan DeviceTimestamp
    {
        get => TimeSpan.FromMilliseconds(Helpers.GetValue(Native.FrameApi.Frame.Timestamp, obFramePtr));

        set
        {
            var ms = value.TotalMilliseconds;
            if (ms < 0)
                throw new ArgumentOutOfRangeException(nameof(DeviceTimestamp), "Value cannot be negative");
            var v = (ulong)Math.Round(ms);
            Native.FrameApi.Frame.SetDeviceTimestamp(obFramePtr.ValueNotDisposed, v, out var error);
            ObException.CheckError(ref error);
        }
    }

    public long DeviceTimestampUsec
    {
        get => (long)Helpers.GetValue(Native.FrameApi.Frame.TimestampUs, obFramePtr);

        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(DeviceTimestampUsec), "Value cannot be negative");
            Native.FrameApi.Frame.SetDeviceTimestampUs(obFramePtr.ValueNotDisposed, (ulong)value, out var error);
            ObException.CheckError(ref error);
        }
    }

    public TimeSpan SystemTimestamp
    {
        get => TimeSpan.FromMilliseconds(Helpers.GetValue(Native.FrameApi.Frame.SystemTimestamp, obFramePtr));

        set
        {
            var ms = value.TotalMilliseconds;
            if (ms < 0)
                throw new ArgumentOutOfRangeException(nameof(SystemTimestamp), "Value cannot be negative");
            var v = (ulong)Math.Round(ms);
            Native.FrameApi.Frame.SetSystemTimestamp(obFramePtr.ValueNotDisposed, v, out var error);
            ObException.CheckError(ref error);
        }
    }

    public IntPtr DataPtr => Helpers.GetValue(Native.FrameApi.Frame.Data, obFramePtr);

    public int DataSizeBytes => (int)Helpers.GetValue(Native.FrameApi.Frame.DataSize, obFramePtr);

#if !(NETSTANDARD2_0 || NET461)

    /// <summary>Access to the unmanaged data buffer via typed span.</summary>
    /// <typeparam name="T">Unmanaged type that is going to use for memory access.</typeparam>
    /// <returns>Span view to the underlying memory buffer.</returns>
    public unsafe Span<T> GetDataAsSpan<T>() where T : unmanaged
        => new(DataPtr.ToPointer(), DataSizeBytes / Marshal.SizeOf<T>());

#endif

    public static Frame Create(DataFormat format, int width, int height, int strideBytes, FrameType frameType)
    {
        var ptr = Native.FrameApi.CreateFrame(format, width, height, strideBytes, frameType, out var error);
        ObException.CheckError(ref error);
        return FromNativePtr(ptr);
    }

    public static Frame CreateFromArray<T>(T[] buffer, DataFormat format, int width, int height)
        where T : struct
    {
        var sizeBytes = buffer.Length * Marshal.SizeOf<T>();

        var bufferPin = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        var bufferPtr = bufferPin.AddrOfPinnedObject();

        var ptr = Native.FrameApi.CreateFrameFromBuffer(format, (uint)width, (uint)height, bufferPtr, (uint)sizeBytes,
            pinnedArrayReleaseCallback, (IntPtr)bufferPin, out var error);
        ObException.CheckError(ref error);

        return FromNativePtr(ptr);
    }

#if !(NETSTANDARD2_0 || NET461)

    public static unsafe Frame CreateFromMemory<T>(System.Buffers.IMemoryOwner<T> memoryOwner,
        DataFormat format, int width, int height)
        where T : unmanaged
    {
        if (memoryOwner is null)
            throw new ArgumentNullException(nameof(memoryOwner));

        var memory = memoryOwner.Memory;
        var sizeBytes = memory.Length * Marshal.SizeOf<T>();

        var memoryPin = memory.Pin();
        var memoryPtr = new IntPtr(memoryPin.Pointer);

        var ptr = Native.FrameApi.CreateFrameFromBuffer(format, (uint)width, (uint)height, memoryPtr, (uint)sizeBytes,
            pinnedMemoryReleaseCallback, PinnedMemoryContext.Create(memoryOwner, memoryPin),
            out var error);

        ObException.CheckError(ref error);

        return FromNativePtr(ptr);
    }

#endif

    #region Memory management

    // This field is required to keep callback delegate in memory
    private static readonly ObFrameDestroyCallback pinnedArrayReleaseCallback
        = new(ReleasePinnedArray);

    private static void ReleasePinnedArray(IntPtr buffer, IntPtr context)
        => ((GCHandle)context).Free();

#if !(NETSTANDARD2_0 || NET461)

    private readonly struct PinnedMemoryContext
    {
        private static readonly ConcurrentDictionary<int, PinnedMemoryContext> contexts
            = new();

        private readonly IDisposable memoryOwner;
        private readonly System.Buffers.MemoryHandle memoryHandle;

        private PinnedMemoryContext(IDisposable memoryOwner, System.Buffers.MemoryHandle memoryHandle)
        {
            this.memoryOwner = memoryOwner;
            this.memoryHandle = memoryHandle;
        }

        public static unsafe IntPtr Create(IDisposable memoryOwner, System.Buffers.MemoryHandle memoryHandle)
        {
            var context = new PinnedMemoryContext(memoryOwner, memoryHandle);
            var key = System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(memoryOwner);
            while (!contexts.TryAdd(key, context))
                key = key < int.MaxValue ? key + 1 : int.MinValue;
            return new(key);
        }

        public static void Destroy(IntPtr ptr)
        {
            var key = ptr.ToInt32();
            if (!contexts.TryRemove(key, out var context))
            {
                System.Diagnostics.Trace.TraceWarning($"K4AdotNet.{nameof(Image)}: Cannot find {nameof(PinnedMemoryContext)} object for key {key}");
                return;
            }
            context.memoryHandle.Dispose();
            context.memoryOwner.Dispose();
        }
    }

    // This field is required to keep callback delegate in memory
    private static readonly ObFrameDestroyCallback pinnedMemoryReleaseCallback = new(ReleasePinnedMemory);

    private static void ReleasePinnedMemory(IntPtr _, IntPtr context)
        => PinnedMemoryContext.Destroy(context);

#endif

    #endregion

}