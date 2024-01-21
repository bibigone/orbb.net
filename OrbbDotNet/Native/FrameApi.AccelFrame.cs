using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class AccelFrame
    {
        // ob_accel_value ob_accel_frame_value(ob_frame* frame, ob_error** error);
        /// <summary>Get accelerometer frame data.</summary>
        /// <param name="frame">Accelerometer frame.</param>
        /// <param name="error">Log error messages.</param>
        /// <remarks>Return the accelerometer data.</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_accel_frame_value", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Float3 Value(ObFramePtr frame, out ObErrorPtr error);

        // float ob_accel_frame_temperature(ob_frame* frame, ob_error** error);
        /// <summary>Get the temperature when acquiring the accelerometer frame.</summary>
        /// <param name="frame">Accelerometer frame.</param>
        /// <param name="error">Log error messages.</param>
        /// <remarks>Return the temperature value.</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_accel_frame_temperature", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float Temperature(ObFramePtr frame, out ObErrorPtr error);
    }
}