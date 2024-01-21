using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

public abstract partial class StreamProfile
{
    public sealed class Video : StreamProfile
    {
        public static bool IsCompatibleWith(StreamType streamType)
            => streamType == StreamType.Color || streamType == StreamType.Depth || streamType == StreamType.IR
            || streamType == StreamType.IRLeft || streamType == StreamType.IRRight || streamType == StreamType.RawPhase
            || streamType == StreamType.Video;

        internal Video(Native.PtrWrapper<ObStreamProfilePtr> ptr)
            : base(ptr)
        { }

        internal Video(Native.PtrWrapper<ObStreamProfilePtr> ptr, StreamType streamType)
            : base(ptr, streamType)
        { }

        protected override bool IsSupportedStreamType(StreamType streamType)
            => IsCompatibleWith(streamType);

        public int Fps
            => (int)Helpers.GetValue(Native.StreamProfileApi.VideoStreamProfile.Fps, obStreamProfilePtr);

        public int Width
            => (int)Helpers.GetValue(Native.StreamProfileApi.VideoStreamProfile.Width, obStreamProfilePtr);

        public int Height
            => (int)Helpers.GetValue(Native.StreamProfileApi.VideoStreamProfile.Height, obStreamProfilePtr);
    }
}
