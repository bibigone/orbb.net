using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class Gyro : Frame
    {
        internal Gyro(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.Gyro)
            : base(ptr, frameType)
        { }

        public Float3 Value => Helpers.GetValue(Native.FrameApi.GyroFrame.Value, obFramePtr);

        public float Temperature => Helpers.GetValue(Native.FrameApi.GyroFrame.Temperature, obFramePtr);
    }
}