using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class DeviceApi
{
    public static class CameraParamList
    {
        // uint32_t ob_camera_param_list_count(ob_camera_param_list* param_list, ob_error** error);
        /// <summary>Get the number of camera parameter lists</summary>
        /// <param name="paramList">Camera param list</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The number of lists</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_camera_param_list_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Count(ObCameraParamListPtr paramList, out ObErrorPtr error);

        // ob_camera_param ob_camera_param_list_get_param(ob_camera_param_list* param_list, uint32_t index, ob_error** error);
        /// <summary>Get camera parameters from the camera parameter list</summary>
        /// <param name="paramList">Camera parameter list</param>
        /// <param name="index">Parameter index</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The camera parameters. Since it returns the structure object directly, there is no need to provide a delete interface.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_camera_param_list_get_param", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern CameraParam GetParam(ObCameraParamListPtr paramList, uint index, out ObErrorPtr error);
    }
}
