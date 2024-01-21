using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class Accel : Frame
    {
        internal Accel(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.Accel)
            : base(ptr, frameType)
        { }

        public Float3 Value => Helpers.GetValue(Native.FrameApi.AccelFrame.Value, obFramePtr);

        public float Temperature => Helpers.GetValue(Native.FrameApi.AccelFrame.Temperature, obFramePtr);
    }
}