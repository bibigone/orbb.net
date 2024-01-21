using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

public abstract partial class StreamProfile
{
    public sealed class Accel : StreamProfile
    {
        public static bool IsCompatibleWith(StreamType streamType)
            => streamType == StreamType.Accel;

        internal Accel(Native.PtrWrapper<ObStreamProfilePtr> ptr)
            : base(ptr)
        { }

        internal Accel(Native.PtrWrapper<ObStreamProfilePtr> ptr, StreamType streamType)
            : base(ptr, streamType)
        { }

        protected override bool IsSupportedStreamType(StreamType streamType)
            => IsCompatibleWith(streamType);

        public AccelFullScaleRange FullScaleRange
            => Helpers.GetValue(Native.StreamProfileApi.AccelStreamProfile.FullScaleRange, obStreamProfilePtr);

        public SampleRate SampleRate
            => Helpers.GetValue(Native.StreamProfileApi.AccelStreamProfile.SampleRate, obStreamProfilePtr);
    }
}
