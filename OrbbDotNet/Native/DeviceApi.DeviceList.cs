using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class DeviceApi
{
    /// <summary>Functions with prefix "ob_device_list_" from the Native SDK.</summary>
    public static class DeviceList
    {
        // uint32_t ob_device_list_device_count(ob_device_list *list, ob_error **error);
        /// <summary>Get the number of devices</summary>
        /// <param name="list">Device list object</param>
        /// <param name="error">Log error messages</param>
        /// <returns>The number of devices</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_device_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint DeviceCount(ObDeviceListPtr list, out ObErrorPtr error);

        // int ob_device_list_get_device_pid(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get the pid of the specified device</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>device pid</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_pid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GetDevicePid(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // int ob_device_list_get_device_vid(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get the pid of the specified device</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>device vid</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_vid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GetDeviceVid(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // const char *ob_device_list_get_device_uid(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get the uid of the specified device</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>the device uid</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_uid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr GetDeviceUid(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // const char *ob_device_list_get_device_serial_number(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get the serial number of the specified device</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>the device serial number</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_serial_number", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr GetDeviceSerialNumber(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // const char *ob_device_list_get_device_connection_type(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get the connection type of the specified device</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>the device connection type，currently supports："USB", "USB1.0", "USB1.1", "USB2.0", "USB2.1", "USB3.0", "USB3.1", "USB3.2", "Ethernet"</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_connection_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr GetDeviceConnectionType(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // const char *ob_device_list_get_device_ip_address(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get device ip address</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>the device ip address，such as "192.168.1.10"</returns>
        /// <remarks>Only valid for network devices, otherwise it will return "0.0.0.0".</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_ip_address", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr GetDeviceIPAddress(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // const char *ob_device_list_get_extension_info(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Get the device extension information.</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>The device extension information</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_extension_info", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern IntPtr GetExtensionInfo(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // ob_device* ob_device_list_get_device(ob_device_list *list, uint32_t index, ob_error **error);
        /// <summary>Create a device.</summary>
        /// <param name="list">Device list object</param>
        /// <param name="index">Device index</param>
        /// <param name="error">Log error message</param>
        /// <returns>The created device.</returns>
        /// <remarks>If the device has already been acquired and created elsewhere, repeated acquisitions will return an error.</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObDevicePtr GetDevice(ObDeviceListPtr list, uint index, out ObErrorPtr error);

        // ob_device* ob_device_list_get_device_by_serial_number(ob_device_list *list, const char *serial_number, ob_error **error);
        /// <summary>Create a device with specified serial number.</summary>
        /// <param name="list">Device list object</param>
        /// <param name="serialNumber">The serial number of the device to create</param>
        /// <param name="error">Log error message</param>
        /// <returns>The created device.</returns>
        /// <remarks>If the device has already been acquired and created elsewhere, repeated acquisitions will return an error.</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_by_serial_number", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObDevicePtr GetDeviceBySerialNumber(ObDeviceListPtr list, [MarshalAs(UnmanagedType.LPStr)] string serialNumber, out ObErrorPtr error);

        // ob_device* ob_device_list_get_device_by_uid(ob_device_list *list, const char *uid, ob_error **error);
        /// <summary>Create a device by UID.</summary>
        /// <param name="list">Device list object</param>
        /// <param name="uid">The UID of the device to create.</param>
        /// <param name="error">Log error message</param>
        /// <returns>The created device.</returns>
        /// <remarks><para>
        /// On Linux platform, the uid of the device is composed of bus-port-dev, for example 1-1.2-1. But the SDK will remove the dev number and only keep the
        /// bus-port as the uid to create the device, for example 1-1.2, so that we can create a device connected to the specified USB port.Similarly, users can also
        /// directly pass in bus-port as uid to create device.
        /// </para><para>
        /// If the device has already been acquired and created elsewhere, repeated acquisitions will return an error.
        /// </para></remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_list_get_device_by_uid", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObDevicePtr GetDeviceByUid(ObDeviceListPtr list, [MarshalAs(UnmanagedType.LPStr)] string uid, out ObErrorPtr error);
    }
}
