using System;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class DeviceProperty
{
    public class Float : DeviceProperty
    {
        internal Float(Device device, ObPropertyItem propertyItem)
            : base(device, propertyItem)
        { }

        public float Value
        {
            get => GetProperty(Native.DeviceApi.Device.GetFloatProperty);
            set => SetProperty(Native.DeviceApi.Device.SetFloatProperty, value);
        }

        public PropertyRange<float> Range
        {
            get
            {
                var res = GetProperty(Native.DeviceApi.Device.GetFloatPropertyRange);
                return new PropertyRange<float>
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
            => Value = Convert.ToSingle(value);

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

        private static T CastValue<T>(float value)
            => Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.Single => (T)(object)value,
                TypeCode.Double => (T)(object)(double)value,
                _ => throw new NotSupportedException($"Cannot convert {typeof(float).Name} value to {typeof(T).Name}."),
            };


    }
}
