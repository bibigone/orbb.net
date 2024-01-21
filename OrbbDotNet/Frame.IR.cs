using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class IR : Video
    {
        internal IR(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType)
            : base(ptr, frameType)
        { }

        public SensorType SourceSensorType => Helpers.GetValue(Native.FrameApi.IRFrame.GetSourceSensorType, obFramePtr);
    }
}