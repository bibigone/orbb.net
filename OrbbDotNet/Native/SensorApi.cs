using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

/// <summary>DLL imports from <c>Sensor.h</c> header file.</summary>
internal static partial class SensorApi
{
    // void ob_delete_sensor_list(ob_sensor_list* sensor_list, ob_error** error);
    /// <summary>Delete a list of sensor objects.</summary>
    /// <param name="info">The list of sensor objects to be deleted.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_sensor_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteSensorList(ObSensorListPtr list, out ObErrorPtr error);

    // void ob_delete_sensor(ob_sensor* sensor, ob_error** error);
    /// <summary>Delete a sensor object.</summary>
    /// <param name="sensor">The sensor objects to be deleted.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_sensor", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteSensor(ObSensorPtr sensor, out ObErrorPtr error);
}
