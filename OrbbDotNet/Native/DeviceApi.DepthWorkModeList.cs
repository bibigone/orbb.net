using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class DeviceApi
{
    public static class  DepthWorkModeList
    {
        // uint32_t ob_depth_work_mode_list_count(ob_depth_work_mode_list* work_mode_list, ob_error** error);
        /// <summary>Get the depth work mode count that ob_depth_work_mode_list hold</summary>
        /// <param name="workModeList">data struct contain list of ob_depth_work_mode</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The total number contained in ob_depth_work_mode_list</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_depth_work_mode_list_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint Count(ObDepthWorkModeListPtr workModeList, out ObErrorPtr error);

        // ob_depth_work_mode ob_depth_work_mode_list_get_item(ob_depth_work_mode_list* work_mode_list, uint32_t index, ob_error** error);
        /// <summary>Get the index target of ob_depth_work_mode from work_mode_list</summary>
        /// <param name="workModeList">Data structure containing a list of ob_depth_work_mode</param>
        /// <param name="index">Index of the target ob_depth_work_mode</param>
        /// <param name="error">Log error messages</param>
        /// <returns>ob_depth_work_mode</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_depth_work_mode_list_get_item", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DepthWorkMode GetItem(ObDepthWorkModeListPtr workModeList, uint index, out ObErrorPtr error);
    }
}
