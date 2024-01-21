using System;
using System.Collections;
using System.Collections.Generic;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary></summary>
public sealed class StreamProfileList : IDisposablePlus, IReadOnlyList<StreamProfile>
{
    public const int WIDTH_ANY = default;
    public const int HEIGHT_ANY = default;
    public const int OB_FPS_ANY = default;
    public const DataFormat FORMAT_ANY = DataFormat.Unknown;
    public const AccelFullScaleRange ACCEL_FULL_SCALE_RANGE_ANY = default;
    public const GyroFullScaleRange GYRO_FULL_SCALE_RANGE_ANY = default;
    public const SampleRate SAMPLE_RATE_ANY = default;

    private readonly Native.PtrWrapper<ObStreamProfileListPtr> obStreamProfileListPtr;
    private readonly Lazy<int> lazyCount;

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    internal StreamProfileList(Native.PtrWrapper<ObStreamProfileListPtr> ptr)
    {
        lazyCount = new(GetCount, isThreadSafe: true);
        obStreamProfileListPtr = ptr;
        obStreamProfileListPtr.Disposed += obStreamProfileListPtr_Disposed;
    }

    // for lazyCount
    private int GetCount()
        => (int)Helpers.GetValue(Native.StreamProfileApi.StreamProfileList.Count, obStreamProfileListPtr);

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obStreamProfileListPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obStreamProfileListPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obStreamProfileListPtr_Disposed(object? sender, EventArgs e)
    {
        obStreamProfileListPtr.Disposed -= obStreamProfileListPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region IReadOnlyList<StreamProfile>

    /// <summary>Stream profile with specified index.</summary>
    /// <param name="index">Zero-based sensor index.</param>
    /// <returns>Stream profile from the list.</returns>
    /// <exception cref="IndexOutOfRangeException">Index cannot be negative and cannot be greater or equal to <see cref="Count"/>.</exception>
    public StreamProfile this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            var ptr = Native.StreamProfileApi.StreamProfileList.GetProfile(obStreamProfileListPtr.ValueNotDisposed, index, out var error);
            ObException.CheckError(ref error);
            return StreamProfile.FromNativePtr(ptr);
        }
    }

    /// <summary>The number of items in the list.</summary>
    public int Count => lazyCount.Value;

    /// <summary>Implements <see cref="IEnumerable{StreamProfile}"/>.</summary>
    /// <returns>Enumerator through all items in the list</returns>
    public IEnumerator<StreamProfile> GetEnumerator()
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
        => obStreamProfileListPtr.GetHashCode();

    public override string ToString()
        => obStreamProfileListPtr.ToString();

    public StreamProfile.Video GetVideoStreamProfile(
        int width = WIDTH_ANY,
        int height = HEIGHT_ANY,
        DataFormat format = FORMAT_ANY,
        int fps = OB_FPS_ANY)
    {
        var ptr = Native.StreamProfileApi.StreamProfileList.GetVideoStreamProfile(
            obStreamProfileListPtr.ValueNotDisposed, width, height, format, fps, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }

    public StreamProfile.Accel GetAccelStreamProfile(
        AccelFullScaleRange fullScaleRange = ACCEL_FULL_SCALE_RANGE_ANY,
        SampleRate sampleRate = SAMPLE_RATE_ANY)
    {
        var ptr = Native.StreamProfileApi.StreamProfileList.GetAccelStreamProfile(
            obStreamProfileListPtr.ValueNotDisposed, fullScaleRange, sampleRate, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }

    public StreamProfile.Gyro GetGyroStreamProfile(
        GyroFullScaleRange fullScaleRange = GYRO_FULL_SCALE_RANGE_ANY,
        SampleRate sampleRate = SAMPLE_RATE_ANY)
    {
        var ptr = Native.StreamProfileApi.StreamProfileList.GetGyroStreamProfile(
            obStreamProfileListPtr.ValueNotDisposed, fullScaleRange, sampleRate, out var error);
        ObException.CheckError(ref error);
        return new(ptr);
    }
}
