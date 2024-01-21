using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

/// <summary>DLL imports from <c>Device.h</c> header file.</summary>
internal static partial class DeviceApi
{
    // void ob_delete_device_list(ob_device_list *list, ob_error **error);
    /// <summary>Delete a device list.</summary>
    /// <param name="info">The device list object to be deleted.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_device_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteDeviceList(ObDeviceListPtr list, out ObErrorPtr error);

    // void ob_delete_device(ob_device *device, ob_error **error);
    /// <summary>Delete a device.</summary>
    /// <param name="device">The device to be deleted.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_device", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteDevice(ObDevicePtr device, out ObErrorPtr error);

    // void ob_delete_device_info(ob_device_info *info, ob_error **error);
    /// <summary>Delete device information.</summary>
    /// <param name="info">The device information to be deleted.</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_device_info", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteDeviceInfo(ObDeviceInfoPtr info, out ObErrorPtr error);

    // void ob_delete_camera_param_list(ob_camera_param_list* param_list, ob_error** error);
    /// <summary>Delete the camera parameter list</summary>
    /// <param name="paramList">Camera parameter list</param>
    /// <param name="error">Log error messages</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_camera_param_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteCameraParamList(ObCameraParamListPtr paramList, out ObErrorPtr error);

    // void ob_delete_depth_work_mode_list(ob_depth_work_mode_list* work_mode_list, ob_error** error);
    /// <summary>Free the resources of ob_depth_work_mode_list</summary>
    /// <param name="workModeList">Data structure containing a list of ob_depth_work_mode</param>
    /// <param name="error">Log error messages.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_depth_work_mode_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteDepthWorkModeList(ObDepthWorkModeListPtr workModeList, out ObErrorPtr error);
}
