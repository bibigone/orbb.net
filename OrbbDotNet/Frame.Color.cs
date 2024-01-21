using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class Color : Video
    {
        internal Color(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.Color)
            : base(ptr, frameType)
        { }
    }
}