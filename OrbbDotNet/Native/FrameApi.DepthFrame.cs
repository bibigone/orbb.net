using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class DepthFrame
    {
        // float ob_depth_frame_get_value_scale(ob_frame* frame, ob_error** error);
        /// <summary>
        /// Get the value scale of the depth frame.
        /// The pixel value of the depth frame is multiplied by the scale to give a depth value in millimeters.
        /// For example, if <c>valueScale=0.1</c> and a certain coordinate pixel value is <c>pixelValue=10000</c>,
        /// then the depth value = <c>pixelValue * valueScale = 10000 * 0.1 = 1000mm</c>.
        /// </summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The value scale of the depth frame</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_depth_frame_get_value_scale", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GetValueScale(ObFramePtr frame, out ObErrorPtr error);
    }
}