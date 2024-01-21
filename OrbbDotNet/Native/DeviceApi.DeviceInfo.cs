using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class DeviceApi
{
    /// <summary>Functions with prefix "ob_device_info_" from the Native SDK</summary>
    public static class DeviceInfo
    {
        // const char* ob_device_info_name(ob_device_info * info, ob_error * *error);
        /// <summary>Get device name</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>the device name</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_name", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr Name(ObDeviceInfoPtr info, out ObErrorPtr error);

        // int ob_device_info_pid(ob_device_info* info, ob_error** error);
        /// <summary>Get device pid</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the device pid</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_pid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Pid(ObDeviceInfoPtr info, out ObErrorPtr error);

        // int ob_device_info_vid(ob_device_info* info, ob_error** error);
        /// <summary>Get device vid</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the device vid</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_vid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int Vid(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_uid(ob_device_info * info, ob_error * *error);
        /// <summary>Get device uid</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the device uid</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_uid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr Uid(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_serial_number(ob_device_info * info, ob_error * *error);
        /// <summary>Get device serial number</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the device serial number</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_serial_number", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr SerialNumber(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_firmware_version(ob_device_info * info, ob_error * *error);
        /// <summary>Get the firmware version number</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>return the firmware version number</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_firmware_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr FirmwareVersion(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_connection_type(ob_device_info * info, ob_error * *error);
        /// <summary>Get the device connection type</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The connection type： "USB", "USB1.0", "USB1.1", "USB2.0", "USB2.1", "USB3.0", "USB3.1", "USB3.2", "Ethernet"</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_connection_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr ConnectionType(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_ip_address(ob_device_info * info, ob_error * *error);
        /// <summary>Get the device IP address</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The IP address，such as "192.168.1.10"</returns>
        /// <remarks>Only valid for network devices, otherwise it will return "0.0.0.0"</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_ip_address", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr IPAddress(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_hardware_version(ob_device_info * info, ob_error * *error);
        /// <summary>Get the hardware version number</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The hardware version number</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_hardware_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr HardwareVersion(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_get_extension_info(ob_device_info * info, ob_error * *error);
        /// <summary>Get the device extension information.</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The device extension information</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_get_extension_info", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr GetExtensionInfo(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_supported_min_sdk_version(ob_device_info * info, ob_error * *error);
        /// <summary>Get the minimum SDK version number supported by the device</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The minimum SDK version number supported by the device</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_supported_min_sdk_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr SupportedMinSdkVersion(ObDeviceInfoPtr info, out ObErrorPtr error);

        // const char* ob_device_info_asicName(ob_device_info * info, ob_error * *error);
        /// <summary>Get the chip name</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The ASIC name</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_asicName", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr AsicName(ObDeviceInfoPtr info, out ObErrorPtr error);

        // ob_device_type ob_device_info_device_type(ob_device_info* info, ob_error** error);
        /// <summary>Get the device type</summary>
        /// <param name="info">Device Information</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The device type</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_info_device_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DeviceType DeviceType(ObDeviceInfoPtr info, out ObErrorPtr error);
    }
}
