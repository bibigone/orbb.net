using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public sealed class Set : Frame
    {
        internal Set(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType = FrameType.Set)
            : base(ptr, frameType)
        { }

        public Set()
            : this(Create())
        { }

        private static ObFramePtr Create()
        {
            var ptr = Native.FrameApi.CreateFrameSet(out var error);
            ObException.CheckError(ref error);
            return ptr;
        }

        public int Count => (int)Helpers.GetValue(Native.FrameApi.FrameSet.FrameCount, obFramePtr);

        public Depth? DepthFrame => FromNativePtrNullable(Helpers.GetValue(Native.FrameApi.FrameSet.DepthFrame, obFramePtr)) as Depth;

        public Color? ColorFrame => FromNativePtrNullable(Helpers.GetValue(Native.FrameApi.FrameSet.ColorFrame, obFramePtr)) as Color;

        public IR? IRFrame => FromNativePtrNullable(Helpers.GetValue(Native.FrameApi.FrameSet.IRFrame, obFramePtr)) as IR;

        public Points? PointsFrame => FromNativePtrNullable(Helpers.GetValue(Native.FrameApi.FrameSet.PointsFrame, obFramePtr)) as Points;

        public Frame? this[FrameType frameType]
        {
            get
            {
                var ptr = Native.FrameApi.FrameSet.GetFrame(obFramePtr.ValueNotDisposed, frameType, out var error);
                ObException.CheckError(ref error);
                return FromNativePtrNullable(ptr);
            }
        }

        public void PushFrame(Frame frame)
        {
            Native.FrameApi.FrameSet.PushFrame(obFramePtr.ValueNotDisposed, frame.FrameType, frame.NativePtr, out var error);
            ObException.CheckError(ref error);
        }

        public void PushFrame(Frame frame, FrameType frameType)
        {
            Native.FrameApi.FrameSet.PushFrame(obFramePtr.ValueNotDisposed, frameType, frame.NativePtr, out var error);
            ObException.CheckError(ref error);
        }
    }
}