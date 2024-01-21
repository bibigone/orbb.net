using System;
using System.Collections;
using System.Collections.Generic;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>List of depth work modes.</summary>
public sealed class DepthWorkModeList : IReadOnlyList<DepthWorkMode>, IDisposablePlus
{
    private readonly Native.PtrWrapper<ObDepthWorkModeListPtr> obDepthWorkModeListPtr;
    private readonly Lazy<int> lazyCount;

    /// <summary>Creates managed wrapper from native pointer.</summary>
    /// <param name="ptr"></param>
    internal DepthWorkModeList(Native.PtrWrapper<ObDepthWorkModeListPtr> ptr)
    {
        lazyCount = new(GetCount, isThreadSafe: true);
        obDepthWorkModeListPtr = ptr;
        obDepthWorkModeListPtr.Disposed += obDepthWorkModeListPtr_Disposed;
    }

    // for lazyCount
    private int GetCount()
        => (int)Helpers.GetValue(Native.DeviceApi.DepthWorkModeList.Count, obDepthWorkModeListPtr);

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obDepthWorkModeListPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obDepthWorkModeListPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obDepthWorkModeListPtr_Disposed(object? sender, EventArgs e)
    {
        obDepthWorkModeListPtr.Disposed -= obDepthWorkModeListPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region IReadOnlyList<DepthWorkMode>

    /// <summary>Indexed-based access to list items.</summary>
    /// <param name="index">Zero-based index of item.</param>
    /// <returns>List item with specified index.</returns>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public DepthWorkMode this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            var res = Native.DeviceApi.DepthWorkModeList.GetItem(obDepthWorkModeListPtr.ValueNotDisposed, (uint)index, out var error);
            ObException.CheckError(ref error);
            return res;
        }
    }

    /// <summary>The number of items in the list.</summary>
    public int Count => lazyCount.Value;

    /// <summary>Implements <see cref="IEnumerable{DepthWorkMode}"/>.</summary>
    /// <returns>Enumerator through all items in the list</returns>
    public IEnumerator<DepthWorkMode> GetEnumerator()
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
        => obDepthWorkModeListPtr.GetHashCode();

    /// <summary>String representation of native pointer.</summary>
    /// <returns>HEX value of native pointer with type-specific prefix.</returns>
    public override string ToString()
        => obDepthWorkModeListPtr.ToString();
}
