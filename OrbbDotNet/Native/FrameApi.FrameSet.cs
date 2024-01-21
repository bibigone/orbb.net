using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class FrameSet
    {
        // uint32_t ob_frameset_frame_count(ob_frame* frameset, ob_error** error);
        /// <summary>Get the number of frames contained in the frameset</summary>
        /// <param name="frameset">frameset object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the number of frames</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_frame_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint FrameCount(ObFramePtr frameset, out ObErrorPtr error);

        // ob_frame* ob_frameset_depth_frame(ob_frame* frameset, ob_error** error);
        /// <summary>Get the depth frame from the frameset.</summary>
        /// <param name="frameset">frameset object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>Return the depth frame.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_depth_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObFramePtr DepthFrame(ObFramePtr frameset, out ObErrorPtr error);

        // ob_frame* ob_frameset_color_frame(ob_frame* frameset, ob_error** error);
        /// <summary>Get the color frame from the frameset.</summary>
        /// <param name="frameset">frameset object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>Return the color frame.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_color_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObFramePtr ColorFrame(ObFramePtr frameset, out ObErrorPtr error);

        // ob_frame* ob_frameset_ir_frame(ob_frame* frameset, ob_error** error);
        /// <summary>Get the infrared frame from the frameset.</summary>
        /// <param name="frameset">frameset object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>Return the infrared frame.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_ir_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObFramePtr IRFrame(ObFramePtr frameset, out ObErrorPtr error);

        // ob_frame* ob_frameset_points_frame(ob_frame* frameset, ob_error** error);
        /// <summary>Get the point cloud frame from the frameset.</summary>
        /// <param name="frameset">frameset object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>Return the point cloud frame.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_points_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObFramePtr PointsFrame(ObFramePtr frameset, out ObErrorPtr error);

        // ob_frame* ob_frameset_get_frame(ob_frame* frameset, ob_frame_type frame_type, ob_error** error);
        /// <summary>Get a frame of a specific type from the frameset.</summary>
        /// <param name="frameset">frameset object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>Return the frame of the specified type, or nullptr if it does not exist.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_get_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObFramePtr GetFrame(ObFramePtr frameset, FrameType frameType, out ObErrorPtr error);

        // void ob_frameset_push_frame(ob_frame* frameset, ob_frame_type type, ob_frame* frame, ob_error** error);
        /// <summary>Add a frame of the specified type to the frameset.</summary>
        /// <param name="frameset">Frameset object.</param>
        /// <param name="type">Type of frame to add.</param>
        /// <param name="frame">Frame object to add.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frameset_push_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void PushFrame(ObFramePtr frameset, FrameType type, ObFramePtr frame, out ObErrorPtr error);
    }
}