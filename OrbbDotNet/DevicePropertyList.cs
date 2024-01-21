using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace OrbbDotNet;

public sealed class DevicePropertyList : IReadOnlyList<DeviceProperty>, IDisposable
{
    private readonly Device device;
    private readonly DeviceProperty?[] items;
    private readonly ReaderWriterLockSlim itemsSync = new();

    internal DevicePropertyList(Device device)
    {
        this.device = device;

        Count = (int)Native.DeviceApi.Device.GetSupportedPropertyCount(device.NativePtr, out var error);
        ObException.CheckError(ref error);
        items = new DeviceProperty?[Count];
    }

    public void Dispose() => itemsSync.Dispose();

    public int Count { get; }

    public DeviceProperty this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            itemsSync.EnterUpgradeableReadLock();
            try
            {
                var item = items[index];
                if (item is null)
                {
                    var propItem = Native.DeviceApi.Device.GetSupportedProperty(device.NativePtr, (uint)index, out var error);
                    ObException.CheckError(ref error);
                    item = DeviceProperty.Create(device, propItem);
                    if (itemsSync.TryEnterWriteLock(100))
                    {
                        items[index] = item;
                        itemsSync.ExitWriteLock();
                    }
                }

                return item;
            }
            finally
            {
                itemsSync.ExitUpgradeableReadLock();
            }
        }
    }

    public DeviceProperty? this[PropertyId propertyId]
    {
        get
        {
            if (IsPropertySupported(propertyId, PermissionType.Any))
            {
                foreach (var prop in this)
                    if (prop.PropertyId == propertyId)
                        return prop;
            }

            return null;
        }
    }

    public IEnumerator<DeviceProperty> GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
            yield return this[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (var i = 0; i < Count; i++)
            yield return this[i];
    }

    public bool IsPropertySupported(PropertyId propertyId, PermissionType permission)
    {
        var res = Native.DeviceApi.Device.IsPropertySupported(device.NativePtr, propertyId, permission, out var error);
        ObException.CheckError(ref error);
        return res;
    }
}
