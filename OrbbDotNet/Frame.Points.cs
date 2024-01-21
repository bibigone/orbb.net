using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class Points : Video
    {
        internal Points(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.Points)
            : base(ptr, frameType)
        { }

        public float PositionValueScale => Helpers.GetValue(Native.FrameApi.PointsFrame.GetPositionValueScale, obFramePtr);
    }
}