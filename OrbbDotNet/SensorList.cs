using System;
using System.Collections;
using System.Collections.Generic;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>List of devices.</summary>
public sealed class SensorList : IDisposablePlus, IReadOnlyList<ISensorListItem>
{
    private readonly Native.PtrWrapper<ObSensorListPtr> obSensorListPtr;
    private readonly Lazy<int> lazyCount;

    /// <summary>Creates object from a native pointer.</summary>
    /// <param name="ptr">Native pointer</param>
    internal SensorList(Native.PtrWrapper<ObSensorListPtr> ptr)
    {
        lazyCount = new(GetCount, isThreadSafe: true);
        obSensorListPtr = ptr;
        obSensorListPtr.Disposed += obSensorListPtr_Disposed;
    }

    // for lazyCount
    private int GetCount()
        => (int)Helpers.GetValue(Native.SensorApi.SensorList.GetSensorCount, obSensorListPtr);

    #region IDisposablePlus

    /// <summary>Frees unmanaged resources associated with this context object.</summary>
    /// <remarks>Can be called multiple times.</remarks>
    public void Dispose()
        => obSensorListPtr.Dispose();

    /// <summary>Gets a value indicating whether the object has been disposed of.</summary>
    /// <seealso cref="Dispose"/>
    public bool IsDisposed => obSensorListPtr.IsDisposed;

    /// <summary>Raised on object disposing (only once).</summary>
    /// <seealso cref="Dispose"/>
    public event EventHandler? Disposed;

    private void obSensorListPtr_Disposed(object? sender, EventArgs e)
    {
        obSensorListPtr.Disposed -= obSensorListPtr_Disposed;
        Disposed?.Invoke(this, EventArgs.Empty);
    }

    #endregion

    #region IReadOnlyList<ISensorListItem>

    /// <summary>Information about sensor with specified index.</summary>
    /// <param name="index">Zero-based sensor index.</param>
    /// <returns>Information about sensor in the list.</returns>
    /// <exception cref="IndexOutOfRangeException">Index cannot be negative and cannot be greater or equal to <see cref="Count"/>.</exception>
    public ISensorListItem this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            return new SensorListItem(this, index);
        }
    }

    /// <summary>The number of items in the list.</summary>
    public int Count => lazyCount.Value;

    /// <summary>Implements <see cref="IEnumerable{ISensorListItem}"/>.</summary>
    /// <returns>Enumerator through all items in the list</returns>
    public IEnumerator<ISensorListItem> GetEnumerator()
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
        => obSensorListPtr.GetHashCode();

    public override string ToString()
        => obSensorListPtr.ToString();

    public Sensor? this[SensorType sensorType]
    {
        get
        {
            var ptr = Native.SensorApi.SensorList.GetSensorByType(obSensorListPtr.ValueNotDisposed, sensorType, out var error);
            ObException.CheckError(ref error);
            return ptr.UnsafeValue != IntPtr.Zero
                ? new(ptr)
                : null;
        }
    }

    private sealed class SensorListItem : ISensorListItem
    {
        private readonly SensorList owner;
        private readonly uint index;

        public SensorListItem(SensorList owner, int index)
        {
            this.owner = owner;
            this.index = (uint)index;
        }

        public SensorType SensorType
        {
            get
            {
                var res = Native.SensorApi.SensorList.GetSensorType(owner.obSensorListPtr.ValueNotDisposed, index, out var error);
                ObException.CheckError(ref error);
                return res;
            }
        }

        public Sensor Sensor
        {
            get
            {
                var ptr = Native.SensorApi.SensorList.GetSensor(owner.obSensorListPtr.ValueNotDisposed, index, out var error);
                ObException.CheckError(ref error);
                return new(ptr);
            }
        }
    }
}
