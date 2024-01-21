using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

public abstract partial class StreamProfile
{
    public sealed class Gyro : StreamProfile
    {
        public static bool IsCompatibleWith(StreamType streamType)
            => streamType == StreamType.Gyro;

        internal Gyro(Native.PtrWrapper<ObStreamProfilePtr> ptr)
            : base(ptr)
        { }

        internal Gyro(Native.PtrWrapper<ObStreamProfilePtr> ptr, StreamType streamType)
            : base(ptr, streamType)
        { }

        protected override bool IsSupportedStreamType(StreamType streamType)
            => IsCompatibleWith(streamType);

        public GyroFullScaleRange FullScaleRange
            => Helpers.GetValue(Native.StreamProfileApi.GyroStreamProfile.FullScaleRange, obStreamProfilePtr);

        public SampleRate SampleRate
            => Helpers.GetValue(Native.StreamProfileApi.GyroStreamProfile.SampleRate, obStreamProfilePtr);
    }
}
