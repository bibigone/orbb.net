using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class SensorApi
{
    /// <summary>Functions with prefix "ob_sensor_" from the Native SDK</summary>
    public static class Sensor
    {
        // ob_sensor_type ob_sensor_get_type(ob_sensor* sensor, ob_error** error);
        /// <summary>Get the type of the sensor.</summary>
        /// <param name="sensor">The sensor object.</param>
        /// <param name="error">Logs error messages.</param>
        /// <returns>The sensor type.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_get_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SensorType GetType(ObSensorPtr sensor, out ObErrorPtr error);

        // ob_stream_profile_list* ob_sensor_get_stream_profile_list(ob_sensor* sensor, ob_error** error);
        /// <summary>Get a list of all supported stream profiles.</summary>
        /// <param name="sensor">The sensor object.</param>
        /// <param name="error">Logs error messages.</param>
        /// <returns>A list of stream profiles.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_get_stream_profile_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStreamProfileListPtr GetStreamProfileList(ObSensorPtr sensor, out ObErrorPtr error);

        // void ob_sensor_start(ob_sensor* sensor, ob_stream_profile* profile, ob_frame_callback callback, void* user_data, ob_error** error);
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_start", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Start(ObSensorPtr sensor, ObStreamProfilePtr profile, ObFrameCallback callback, IntPtr userData, out ObErrorPtr error);

        // void ob_sensor_stop(ob_sensor* sensor, ob_error** error);
        /// <summary>Stop the sensor stream.</summary>
        /// <param name="sensor">The sensor object.</param>
        /// <param name="error">Logs error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_stop", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Stop(ObSensorPtr sensor, out ObErrorPtr error);

        // void ob_sensor_switch_profile(ob_sensor* sensor, ob_stream_profile* profile, ob_error** error);
        /// <summary>Dynamically switch resolutions.</summary>
        /// <param name="sensor">The sensor object.</param>
        /// <param name="profile">The stream configuration information.</param>
        /// <param name="error">Logs error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_switch_profile", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SwitchProfile(ObSensorPtr sensor, ObStreamProfilePtr profile, out ObErrorPtr error);
    }
}
