using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class FrameApi
{
    public static class PointsFrame
    {
        // float ob_points_frame_get_position_value_scale(ob_frame* frame, ob_error** error);
        /// <summary>
        /// Get the point position value scale of the points frame.
        /// The point position value of the points frame is multiplied by the scale to give a position value in millimeters.
        /// For example, if <c>scale=0.1</c>, the x-coordinate value of a point is <c>x = 10000</c>,
        /// which means that the actual x-coordinate value <c>= x * scale = 10000 * 0.1 = 1000mm</c>.
        /// </summary>
        /// <param name="frame">Frame object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The position value scale of the points frame</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_points_frame_get_position_value_scale", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GetPositionValueScale(ObFramePtr frame, out ObErrorPtr error);
    }
}