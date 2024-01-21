using System;
using System.Collections;
using System.Collections.Generic;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>List of camera parameters (intrinsic, extrinsic).</summary>
public sealed class CameraParamList : IReadOnlyList<CameraParam>, IDisposablePlus
{
    private readonly Native.PtrWrapper<ObCameraParamListPtr> obCameraParamListPtr;
    private readonly Lazy<int> lazyCount;

    /// <summary>Creates managed object from native pointer specified.</summary>
    /// <param name="ptr">Native pointer.</param>
    internal CameraParamList(Native.PtrWrapper<ObCameraParamListPtr> ptr)
    {
        lazyCount = new(GetCount, isThreadSafe: true);
        obCameraParamListPtr = ptr;
        obCameraParamListPtr.Disposed += obCameraParamListPtr_Disposed;
    }

    // for lazyCount
    private int GetCount()
        => (int)Helpers.GetValue(Native.DeviceApi.CameraParamList.Count, obCameraParamListPtr);

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obCameraParamListPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obCameraParamListPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obCameraParamListPtr_Disposed(object? sender, EventArgs e)
    {
        obCameraParamListPtr.Disposed -= obCameraParamListPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region IReadOnlyList<CameraParam>

    /// <summary>Indexed access to camera parameters.</summary>
    /// <param name="index">Zero-based index of item.</param>
    /// <returns>Camera parameters with specified index.</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public CameraParam this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            var res = Native.DeviceApi.CameraParamList.GetParam(obCameraParamListPtr.ValueNotDisposed, (uint)index, out var error);
            ObException.CheckError(ref error);
            return res;
        }
    }

    /// <summary>The number of items in the list.</summary>
    public int Count => lazyCount.Value;

    /// <summary>Implements <see cref="IEnumerable{CameraParam}"/>.</summary>
    /// <returns>Enumerator through all items in the list</returns>
    public IEnumerator<CameraParam> GetEnumerator()
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

    /// <summary>Value of native pointer is used as hash.</summary>
    /// <returns>Hash code.</returns>
    public override int GetHashCode()
        => obCameraParamListPtr.GetHashCode();

    /// <summary>String representation of native pointer.</summary>
    /// <returns>HEX value of native pointer with type-specific prefix.</returns>
    public override string ToString()
        => obCameraParamListPtr.ToString();
}
