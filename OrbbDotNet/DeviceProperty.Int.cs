using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class DeviceProperty
{
    public class Int : DeviceProperty
    {
        internal Int(Device device, ObPropertyItem propertyItem)
            : base(device, propertyItem)
        { }

        public int Value
        {
            get => GetProperty(Native.DeviceApi.Device.GetIntProperty);
            set => SetProperty(Native.DeviceApi.Device.SetIntProperty, value);
        }

        public PropertyRange<int> Range
        {
            get
            {
                var res = GetProperty(Native.DeviceApi.Device.GetIntPropertyRange);
                return new PropertyRange<int>
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
            => Value = Convert.ToInt32(value);

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

        private static T CastValue<T>(int value) where T : unmanaged
            => Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.Int32 => (T)(object)value,
                TypeCode.UInt32 => (T)(object)(uint)value,
                TypeCode.Int16 => (T)(object)(short)value,
                TypeCode.UInt16 => (T)(object)(ushort)value,
                TypeCode.Int64 => (T)(object)(long)value,
                TypeCode.UInt64 => (T)(object)(ulong)value,
                TypeCode.SByte => (T)(object)(sbyte)value,
                TypeCode.Byte => (T)(object)(byte)value,
                TypeCode.Single => (T)(object)(float)value,
                TypeCode.Double => (T)(object)(double)value,
                _ => throw new NotSupportedException($"Cannot convert {typeof(int).Name} value to {typeof(T).Name}."),
            };
    }
}
