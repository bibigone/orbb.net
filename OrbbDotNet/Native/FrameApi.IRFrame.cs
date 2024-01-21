using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class IRFrame
    {
        // ob_sensor_type ob_ir_frame_get_source_sensor_type(ob_frame* frame, ob_error** ob_error);
        /// <summary>Get the source sensor type of the IR frame (left or right for dual camera)</summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the source sensor type of the IR frame</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_ir_frame_get_source_sensor_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern SensorType GetSourceSensorType(ObFramePtr frame, out ObErrorPtr error);
    }
}