using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class Depth : Video
    {
        internal Depth(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.Depth)
            : base(ptr, frameType)
        { }

        public float ValueScale => Helpers.GetValue(Native.FrameApi.DepthFrame.GetValueScale, obFramePtr);
    }
}