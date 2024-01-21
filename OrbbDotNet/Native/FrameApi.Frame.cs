using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class Frame
    {
        // void ob_frame_add_ref(ob_frame* frame, ob_error** error);
        /// <summary>Increase the reference count of a frame object.</summary>
        /// <param name="frame">Frame object to increase the reference count.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_add_ref", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void AddRef(ObFramePtr frame, out ObErrorPtr error);

        // uint64_t ob_frame_index(ob_frame* frame, ob_error** error);
        /// <summary>Get the frame index</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame index</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_index", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong Index(ObFramePtr frame, out ObErrorPtr error);

        // ob_format ob_frame_format(ob_frame* frame, ob_error** error);
        /// <summary>Get the frame format</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame format</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_format", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DataFormat Format(ObFramePtr frame, out ObErrorPtr error);

        // ob_frame_type ob_frame_get_type(ob_frame* frame, ob_error** error);
        /// <summary>Get the frame type</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame type</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_get_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern FrameType GetType(ObFramePtr frame, out ObErrorPtr error);

        // uint64_t ob_frame_time_stamp(ob_frame* frame, ob_error** error);
        /// <summary>Get the hardware timestamp of the frame in milliseconds.
        /// The hardware timestamp is the time point when the frame was captured by the device, on device clock domain.
        /// </summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame hardware timestamp in milliseconds</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_time_stamp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong Timestamp(ObFramePtr frame, out ObErrorPtr error);

        // uint64_t ob_frame_time_stamp_us(ob_frame* frame, ob_error** error);
        /// <summary>Get the hardware timestamp of the frame in microseconds.
        /// The hardware timestamp is the time point when the frame was captured by the device, on device clock domain.
        /// </summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame hardware timestamp in microseconds</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_time_stamp_us", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong TimestampUs(ObFramePtr frame, out ObErrorPtr error);

        // uint64_t ob_frame_system_time_stamp(ob_frame* frame, ob_error** error);
        /// <summary>Get the system timestamp of the frame in milliseconds.
        /// The system timestamp is the time point when the frame was received by the host, on host clock domain.
        /// </summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame system timestamp in milliseconds</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_system_time_stamp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong SystemTimestamp(ObFramePtr frame, out ObErrorPtr error);

        // void* ob_frame_data(ob_frame* frame, ob_error** error);
        /// <summary>Get frame data</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <remarks>return frame data pointer</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr Data(ObFramePtr frame, out ObErrorPtr error);

        // uint32_t ob_frame_data_size(ob_frame* frame, ob_error** error);
        /// <summary>Get the frame data size</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>the frame data size</returns>
        /// <remarks>
        /// If it is point cloud data, it return the number of bytes occupied by all point sets.
        /// If you need to find the number of points, you need to divide dataSize
        /// by the structure size of the corresponding point type.
        /// </remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_data_size", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr DataSize(ObFramePtr frame, out ObErrorPtr error);

        // void ob_frame_set_system_time_stamp(ob_frame* frame, uint64_t system_timestamp, ob_error** error);
        /// <summary>Set the system timestamp of a frame object.</summary>
        /// <param name="frame">Frame object to set the system timestamp for.</param>
        /// <param name="systemTimestamp">System timestamp to set in milliseconds.</param>
        /// <param name="error">Log error messages</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_set_system_time_stamp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetSystemTimestamp(ObFramePtr frame, ulong systemTimestamp, out ObErrorPtr error);

        // void ob_frame_set_device_time_stamp(ob_frame* frame, uint64_t device_timestamp, ob_error** error);
        /// <summary>Set the device timestamp of a frame object.</summary>
        /// <param name="frame">Frame object to set the device timestamp for.</param>
        /// <param name="deviceTimestamp">Device timestamp to set in milliseconds.</param>
        /// <param name="error">Log error messages</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_set_device_time_stamp", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetDeviceTimestamp(ObFramePtr frame, ulong deviceTimestamp, out ObErrorPtr error);

        // void ob_frame_set_device_time_stamp_us(ob_frame* frame, uint64_t device_timestamp_us, ob_error** error);
        /// <summary>Set the device timestamp of a frame object.</summary>
        /// <param name="frame">Frame object to set the device timestamp for.</param>
        /// <param name="deviceTimestampUs">Device timestamp to set in microseconds.</param>
        /// <param name="error">Log error messages</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_frame_set_device_time_stamp_us", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetDeviceTimestampUs(ObFramePtr frame, ulong deviceTimestampUs, out ObErrorPtr error);
    }
}