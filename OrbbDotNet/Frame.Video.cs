using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

partial class Frame
{
    public class Video : Frame
    {
        internal Video(Native.PtrWrapper<ObFramePtr> ptr, FrameType frameType)
            : base(ptr, frameType)
        { }

        public int Width => (int)Helpers.GetValue(Native.FrameApi.VideoFrame.Width, obFramePtr);

        public int Height => (int)Helpers.GetValue(Native.FrameApi.VideoFrame.Height, obFramePtr);

        public byte PixelAvailableBitSize => Helpers.GetValue(Native.FrameApi.VideoFrame.PixelAvailableBitSize, obFramePtr);

        public IntPtr MetadataPtr => Helpers.GetValue(Native.FrameApi.VideoFrame.Metadata, obFramePtr);

        public int MetadataSizeBytes => (int)Helpers.GetValue(Native.FrameApi.VideoFrame.MetadataSize, obFramePtr);

#if !(NETSTANDARD2_0 || NET461)

        public unsafe Span<T> GetMetadataAsSpan<T>() where T : unmanaged
            => new(MetadataPtr.ToPointer(), MetadataSizeBytes / Marshal.SizeOf<T>());

#endif
    }
}