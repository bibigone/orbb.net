using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

public abstract partial class DeviceProperty
{
    internal static DeviceProperty Create(Device device, ObPropertyItem propertyItem)
        => propertyItem.Type switch
        {
            PropertyType.Int => new Int(device, propertyItem),
            PropertyType.Float => new Float(device, propertyItem),
            PropertyType.Bool => new Bool(device, propertyItem),
            PropertyType.Struct => new Struct(device, propertyItem),
            _ => throw new NotSupportedException($"Property type {propertyItem.Type} is unknown."),
        };

    private readonly Device device;
    private readonly ObPropertyItem propertyItem;

    private DeviceProperty(Device device, ObPropertyItem propertyItem)
    {
        this.device = device;
        this.propertyItem = propertyItem;
    }

    public PropertyId PropertyId => propertyItem.Id;

    public PropertyType PropertyType => propertyItem.Type;

    public string? Name => propertyItem.Name;

    public PermissionType Permission => propertyItem.Permission;

    public CmdVersion CmdVersion => GetProperty(Native.DeviceApi.Device.GetCmdVersion);

    public abstract void SetValue<T>(T value) where T : unmanaged;

    public abstract T GetValue<T>() where T : unmanaged;

    public abstract PropertyRange<T> GetPropertyRange<T>() where T : unmanaged;

    private delegate void PropertySetter<T>(ObDevicePtr obDevicePtr, PropertyId propertyId, T value, out ObErrorPtr error)
        where T : unmanaged;

    private delegate T PropertyGetter<T>(ObDevicePtr obDevicePtr, PropertyId propertyId, out ObErrorPtr error)
        where T : unmanaged;

    private void SetProperty<T>(PropertySetter<T> setter, T value) where T : unmanaged
    {
        setter(device.NativePtr, PropertyId, value, out var error);
        ObException.CheckError(ref error);
    }

    private T GetProperty<T>(PropertyGetter<T> getter) where T : unmanaged
    {
        var res = getter(device.NativePtr, PropertyId, out var error);
        ObException.CheckError(ref error);
        return res;
    }
}
