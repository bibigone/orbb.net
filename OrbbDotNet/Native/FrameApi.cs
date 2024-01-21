using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    // void ob_delete_frame(ob_frame* frame, ob_error** error);
    /// <summary>Delete a frame object</summary>
    /// <param name="frame">The frame object to be deleted</param>
    /// <param name="error">Log error messages</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteFrame(ObFramePtr frame, out ObErrorPtr error);

    // ob_frame* ob_create_frameset(ob_error** error);
    /// <summary>Create an empty frameset object.</summary>
    /// <param name="error">Log error messages.</param>
    /// <returns>Return the frameset object.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_create_frameset", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObFramePtr CreateFrameSet(out ObErrorPtr error);

    // ob_frame* ob_create_frame(ob_format frame_format, int width, int height, int stride_bytes, ob_frame_type frame_type, ob_error** error);
    /// <summary>Create an empty frame object based on the specified parameters.</summary>
    /// <param name="format">Frame object format.</param>
    /// <param name="width">Frame object width.</param>
    /// <param name="height">Frame object height.</param>
    /// <param name="strideBytes">Buffer row span.</param>
    /// <param name="frameType">Frame object type.</param>
    /// <param name="error">Log error messages.</param>
    /// <returns>Return an empty frame object.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_create_frame", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObFramePtr CreateFrame(DataFormat format, int width, int height, int strideBytes, FrameType frameType, out ObErrorPtr error);

    // ob_frame* ob_create_frame_from_buffer(ob_format frame_format, uint32_t frame_width, uint32_t frame_height, uint8_t* buffer, uint32_t buffer_size,
    //                                       ob_frame_destroy_callback* buffer_destroy_cb, void* buffer_destroy_context, ob_error** error);
    /// <summary>Create a frame object based on an externally created buffer.</summary>
    /// <param name="format">Frame object format.</param>
    /// <param name="width">Frame object width.</param>
    /// <param name="height">Frame object height.</param>
    /// <param name="buffer">Frame object buffer.</param>
    /// <param name="bufferSize">Frame object buffer size.</param>
    /// <param name="bufferDestroyCallback">Destroy callback.</param>
    /// <param name="bufferDestroyContext">Destroy context.</param>
    /// <param name="error">Log error messages.</param>
    /// <returns>Return the frame object.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_create_frame_from_buffer", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObFramePtr CreateFrameFromBuffer(DataFormat format, uint width, uint height,
        IntPtr buffer, uint bufferSize, ObFrameDestroyCallback bufferDestroyCallback, IntPtr bufferDestroyContext,
        out ObErrorPtr error);
}