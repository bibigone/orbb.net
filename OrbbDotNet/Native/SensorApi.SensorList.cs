using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class SensorApi
{
    /// <summary>Functions with prefix "ob_sensor_list_" from the Native SDK</summary>
    public static class SensorList
    {
        // uint32_t ob_sensor_list_get_sensor_count(ob_sensor_list* sensor_list, ob_error** error);
        /// <summary>Get the number of sensors in the sensor list.</summary>
        /// <param name="list">The list of sensor objects.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The number of sensors in the list.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_list_get_sensor_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint GetSensorCount(ObSensorListPtr list, out ObErrorPtr error);

        // ob_sensor_type ob_sensor_list_get_sensor_type(ob_sensor_list* sensor_list, uint32_t index, ob_error** error);
        /// <summary>Get the sensor type.</summary>
        /// <param name="list">The list of sensor objects.</param>
        /// <param name="index">The index of the sensor on the list.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The sensor type.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_list_get_sensor_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SensorType GetSensorType(ObSensorListPtr list, uint index, out ObErrorPtr error);

        // ob_sensor* ob_sensor_list_get_sensor_by_type(ob_sensor_list* sensor_list, ob_sensor_type sensorType, ob_error** error);
        /// <summary>Get a sensor by sensor type.</summary>
        /// <param name="list">The list of sensor objects.</param>
        /// <param name="type">The sensor type to be obtained.</param>
        /// <param name="error">Logs error messages.</param>
        /// <returns>The sensor pointer. If the specified type of sensor does not exist, it will return <see cref="IntPtr.Zero"/>.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_list_get_sensor_by_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObSensorPtr GetSensorByType(ObSensorListPtr list, SensorType type, out ObErrorPtr error);

        // ob_sensor* ob_sensor_list_get_sensor(ob_sensor_list* sensor_list, uint32_t index, ob_error** error);
        /// <summary>Get a sensor by index number.</summary>
        /// <param name="list">The list of sensor objects.</param>
        /// <param name="index">The index of the sensor on the list.</param>
        /// <param name="error">Logs error messages.</param>
        /// <returns>The sensor object.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_sensor_list_get_sensor", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObSensorPtr GetSensor(ObSensorListPtr list, uint index, out ObErrorPtr error);
    }
}
