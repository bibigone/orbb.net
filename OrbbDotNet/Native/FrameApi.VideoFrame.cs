using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class VideoFrame
    {
        // uint32_t ob_video_frame_width(ob_frame* frame, ob_error** error);
        /// <summary>Get video frame width</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return frame width</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_frame_width", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Width(ObFramePtr frame, out ObErrorPtr error);

        // uint32_t ob_video_frame_height(ob_frame* frame, ob_error** error);
        /// <summary>Get video frame height</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return frame height</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_frame_height", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Height(ObFramePtr frame, out ObErrorPtr error);

        // void* ob_video_frame_metadata(ob_frame* frame, ob_error** error);
        /// <summary>Get the metadata of the frame</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the metadata pointer of the frame</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_frame_metadata", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr Metadata(ObFramePtr frame, out ObErrorPtr error);

        // uint32_t ob_video_frame_metadata_size(ob_frame* frame, ob_error** error);
        /// <summary>Get the metadata size of the frame</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the metadata size of the frame</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_frame_metadata_size", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint MetadataSize(ObFramePtr frame, out ObErrorPtr error);

        // uint8_t ob_video_frame_pixel_available_bit_size(ob_frame* frame, ob_error** error);
        /// <summary>Get the effective number of pixels (such as Y16 format frame, but only the lower 10 bits are effective bits, and the upper 6 bits are filled with 0)</summary>
        /// <remarks>Only valid for Y8/Y10/Y11/Y12/Y14/Y16 format</remarks>
        /// <param name="frame">video frame object</param>
        /// <param name="error">log error messages</param>
        /// <returns>return the effective number of pixels in the pixel, or 0 if it is an unsupported format</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_frame_pixel_available_bit_size", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte PixelAvailableBitSize(ObFramePtr frame, out ObErrorPtr error);
    }
}