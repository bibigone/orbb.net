using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class DeviceProperty
{
    public class Bool : DeviceProperty
    {
        internal Bool(Device device, ObPropertyItem propertyItem)
            : base(device, propertyItem)
        { }

        public bool Value
        {
            get => GetProperty(Native.DeviceApi.Device.GetBoolProperty);
            set => SetProperty(Native.DeviceApi.Device.SetBoolProperty, (Native.NativeBool)value);
        }

        public PropertyRange<bool> Range
        {
            get
            {
                var res = GetProperty(Native.DeviceApi.Device.GetBoolPropertyRange);
                return new PropertyRange<bool>
                {
                    Current = res.Cur,
                    Max = res.Max,
                    Min = res.Min,
                    Step = res.Step,
                    Default = res.Def,
                };
            }
        }

        public override void SetValue<T>(T value)
            => Value = Convert.ToBoolean(value);

        public override T GetValue<T>()
            => CastValue<T>(Value);

        public override PropertyRange<T> GetPropertyRange<T>()
        {
            var range = Range;
            return new PropertyRange<T>
            {
                Current = CastValue<T>(range.Current),
                Max = CastValue<T>(range.Max),
                Min = CastValue<T>(range.Min),
                Step = CastValue<T>(range.Step),
                Default = CastValue<T>(range.Default),
            };
        }

        private static T CastValue<T>(bool value) where T : unmanaged
            => Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.Boolean => (T)(object)value,
                TypeCode.SByte => (T)(object)(value ? (sbyte)1 : (sbyte)0),
                TypeCode.Byte => (T)(object)(value ? (byte)1 : (byte) 0),
                TypeCode.Int16 => (T)(object)(value ? (short)1 : (short)0),
                TypeCode.UInt16 => (T)(object)(value ? (ushort)1 : (ushort)0),
                TypeCode.Int32 => (T)(object)(value ? 1 : 0),
                TypeCode.UInt32 => (T)(object)(value ? 1u : 0u),
                TypeCode.Int64 => (T)(object)(value ? 1L : 0L),
                TypeCode.UInt64 => (T)(object)(value ? 1uL : 0uL),
                TypeCode.Single => (T)(object)(value ? 1f : 0f),
                TypeCode.Double => (T)(object)(value ? 1.0 : 0.0),
                _ => throw new NotSupportedException($"Cannot convert {typeof(bool).Name} value to {typeof(T).Name}."),
            };
    }
}
