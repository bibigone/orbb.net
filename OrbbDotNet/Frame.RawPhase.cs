using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class RawPhase : Video
    {
        internal RawPhase(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.RawPhase)
            : base(ptr, frameType)
        { }
    }
}