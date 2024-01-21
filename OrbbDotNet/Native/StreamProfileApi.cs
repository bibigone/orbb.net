using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static class StreamProfileApi
{
    // void ob_delete_stream_profile_list(ob_stream_profile_list* profile_list, ob_error** error);
    /// <summary>Delete the stream profile list.</summary>
    /// <param name="list">Stream configuration list.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_stream_profile_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteStreamProfileList(ObStreamProfileListPtr list, out ObErrorPtr error);

    //void ob_delete_stream_profile(ob_stream_profile* profile, ob_error** error);
    /// <summary>Delete the stream configuration.</summary>
    /// <param name="profile">Stream configuration object.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_stream_profile", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteStreamProfile(ObStreamProfilePtr profile, out ObErrorPtr error);

    public static class StreamProfileList
    {
        // uint32_t ob_stream_profile_list_count(ob_stream_profile_list* profile_list, ob_error** error);
        /// <summary>Get the number of StreamProfile lists.</summary>
        /// <param name="list">List of stream profiles.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The number of stream profiles.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_list_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Count(ObStreamProfileListPtr list, out ObErrorPtr error);

        // ob_stream_profile* ob_stream_profile_list_get_profile(ob_stream_profile_list* profile_list, int index, ob_error** error);
        /// <summary>Get the corresponding StreamProfile by subscripting.</summary>
        /// <param name="list">List of stream profiles.</param>
        /// <param name="index">Index.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The matching profile.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_list_get_profile", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStreamProfilePtr GetProfile(ObStreamProfileListPtr list, int index, out ObErrorPtr error);

        // ob_stream_profile* ob_stream_profile_list_get_video_stream_profile(ob_stream_profile_list* profile_list, int width, int height, ob_format format, int fps,
        //                                                                    ob_error** error);
        /// <summary>Match the corresponding <see cref="ObStreamProfilePtr"/> through the passed parameters.
        /// If there are multiple matches, the first one in the list will be returned by default.
        /// If no matched profile is found, an error will be returned.
        /// </summary>
        /// <param name="list">Resolution list.</param>
        /// <param name="width">Width. If you don't need to add matching conditions, you can pass OB_WIDTH_ANY.</param>
        /// <param name="height">If you don't need to add matching conditions, you can pass OB_HEIGHT_ANY.</param>
        /// <param name="format">If you don't need to add matching conditions, you can pass OB_FORMAT_ANY.</param>
        /// <param name="fps">Frame rate. If you don't need to add matching conditions, you can pass OB_FPS_ANY.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The matching profile.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_list_get_video_stream_profile", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStreamProfilePtr GetVideoStreamProfile(ObStreamProfileListPtr list,
            int width, int height, DataFormat format, int fps,
            out ObErrorPtr error);

        // ob_stream_profile* ob_stream_profile_list_get_accel_stream_profile(ob_stream_profile_list* profile_list, ob_accel_full_scale_range fullScaleRange,
        //                                                                    ob_accel_sample_rate sampleRate, ob_error** error);
        /// <summary>Match the corresponding ob_stream_profile through the passed parameters.
        /// If there are multiple matches, the first one in the list will be returned by default.
        /// If no matched profile is found, an error will be returned.
        /// </summary>
        /// <param name="list">Resolution list.</param>
        /// <param name="fullScaleRange">Full-scale range. If you don't need to add matching conditions, you can pass 0.</param>
        /// <param name="sampleRate">If you don't need to add matching conditions, you can pass 0.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The matching profile.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_list_get_accel_stream_profile", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStreamProfilePtr GetAccelStreamProfile(ObStreamProfileListPtr list,
            AccelFullScaleRange fullScaleRange, SampleRate sampleRate,
            out ObErrorPtr error);

        // ob_stream_profile* ob_stream_profile_list_get_gyro_stream_profile(ob_stream_profile_list* profile_list, ob_gyro_full_scale_range fullScaleRange,
        //                                                                   ob_gyro_sample_rate sampleRate, ob_error** error);
        /// <summary>Match the corresponding ob_stream_profile through the passed parameters.
        /// If there are multiple matches, the first one in the list will be returned by default.
        /// If no matched profile is found, an error will be returned.
        /// </summary>
        /// <param name="list">Resolution list.</param>
        /// <param name="fullScaleRange">Full-scale range. If you don't need to add matching conditions, you can pass 0.</param>
        /// <param name="sampleRate">If you don't need to add matching conditions, you can pass 0.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The matching profile.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_list_get_gyro_stream_profile", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStreamProfilePtr GetGyroStreamProfile(ObStreamProfileListPtr list,
            GyroFullScaleRange fullScaleRange, SampleRate sampleRate,
            out ObErrorPtr error);
    }

    public static class StreamProfile
    {
        // ob_format ob_stream_profile_format(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get stream profile format</summary>
        /// <param name="profile">Stream configuration object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the format of the stream</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_format", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DataFormat Format(ObStreamProfilePtr profile, out ObErrorPtr error);

        // ob_stream_type ob_stream_profile_type(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get stream profile type</summary>
        /// <param name="profile">Stream configuration object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>stream type</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_stream_profile_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern StreamType Type(ObStreamProfilePtr profile, out ObErrorPtr error);
    }

    public static class VideoStreamProfile
    {
        // uint32_t ob_video_stream_profile_fps(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the frame rate of the video stream configuration</summary>
        /// <param name="profile">Stream configuration object, if the configuration is not a video stream configuration, an error will be returned</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the frame rate of the stream</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_stream_profile_fps", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Fps(ObStreamProfilePtr profile, out ObErrorPtr error);

        // uint32_t ob_video_stream_profile_width(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the width of the video stream configuration</summary>
        /// <param name="profile">Stream configuration object, if the configuration is not a video stream configuration, an error will be returned</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the width of the stream</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_stream_profile_width", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Width(ObStreamProfilePtr profile, out ObErrorPtr error);

        // uint32_t ob_video_stream_profile_height(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the height of the video stream configuration</summary>
        /// <param name="profile">Stream configuration object, if the configuration is not a video stream configuration, an error will be returned</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the height of the stream</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_video_stream_profile_height", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Height(ObStreamProfilePtr profile, out ObErrorPtr error);
    }

    public static class AccelStreamProfile
    {
        // ob_accel_full_scale_range ob_accel_stream_profile_full_scale_range(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the full-scale range of the accelerometer stream.</summary>
        /// <param name="profile">Stream configuration object. If the configuration is not for the accelerometer stream, an error will be returned.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The full-scale range of the accelerometer stream.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_accel_stream_profile_full_scale_range", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AccelFullScaleRange FullScaleRange(ObStreamProfilePtr profile, out ObErrorPtr error);

        // ob_accel_sample_rate ob_accel_stream_profile_sample_rate(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the sampling frequency of the accelerometer frame.</summary>
        /// <param name="profile">Stream configuration object. If the configuration is not for the accelerometer stream, an error will be returned.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The sampling frequency of the accelerometer frame.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_accel_stream_profile_sample_rate", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SampleRate SampleRate(ObStreamProfilePtr profile, out ObErrorPtr error);
    }

    public static class GyroStreamProfile
    {
        // ob_gyro_full_scale_range ob_gyro_stream_profile_full_scale_range(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the full-scale range of the gyroscope stream.</summary>
        /// <param name="profile">Stream configuration object. If the configuration is not for the gyroscope stream, an error will be returned.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The full-scale range of the gyroscope stream.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_gyro_stream_profile_full_scale_range", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern GyroFullScaleRange FullScaleRange(ObStreamProfilePtr profile, out ObErrorPtr error);

        // ob_gyro_sample_rate ob_gyro_stream_profile_sample_rate(ob_stream_profile* profile, ob_error** error);
        /// <summary>Get the sampling frequency of the gyroscope stream.</summary>
        /// <param name="profile">Stream configuration object. If the configuration is not for the gyroscope stream, an error will be returned.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The sampling frequency of the gyroscope stream.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_gyro_stream_profile_sample_rate", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SampleRate SampleRate(ObStreamProfilePtr profile, out ObErrorPtr error);
    }
}
