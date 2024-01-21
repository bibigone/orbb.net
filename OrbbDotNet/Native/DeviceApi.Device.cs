using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

internal static partial class DeviceApi
{
    /// <summary>Functions with prefix "ob_device_" from the Native SDK</summary>
    public static class Device
    {
        // ob_device_info* ob_device_get_device_info(ob_device* device, ob_error** error);
        /// <summary>Get device information</summary>
        /// <param name="device">The device to obtain information from.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The device information.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_device_info", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObDeviceInfoPtr GetDeviceInfo(ObDevicePtr device, out ObErrorPtr error);

        // ob_sensor_list* ob_device_get_sensor_list(ob_device* device, ob_error** error);
        /// <summary>List all sensors.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The list of all sensors.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_sensor_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObSensorListPtr GetSensorList(ObDevicePtr device, out ObErrorPtr error);

        // ob_sensor* ob_device_get_sensor(ob_device* device, ob_sensor_type type, ob_error** error);
        /// <summary>Get a device's sensor.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="type">The type of sensor to get.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The acquired sensor.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_sensor", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObSensorPtr GetSensor(ObDevicePtr device, SensorType type, out ObErrorPtr error);

        // void ob_device_set_int_property(ob_device* device, ob_property_id property_id, int32_t property, ob_error** error);
        /// <summary>Set an integer type of device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property to be set.</param>
        /// <param name="property">The property value to be set.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_int_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetIntProperty(ObDevicePtr device, PropertyId propertyId, int property, out ObErrorPtr error);

        // int32_t ob_device_get_int_property(ob_device* device, ob_property_id property_id, ob_error** error);
        /// <summary>Get an integer type of device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The property value.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_int_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int GetIntProperty(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // void ob_device_set_float_property(ob_device* device, ob_property_id property_id, float property, ob_error** error);
        /// <summary>Set a float type of device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property to be set.</param>
        /// <param name="property">The property value to be set.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_float_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetFloatProperty(ObDevicePtr device, PropertyId propertyId, float property, out ObErrorPtr error);

        // float ob_device_get_float_property(ob_device* device, ob_property_id property_id, ob_error** error);
        /// <summary>Get a float type of device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The property value.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_float_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float GetFloatProperty(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // void ob_device_set_bool_property(ob_device* device, ob_property_id property_id, bool property, ob_error** error);
        /// <summary>Set a boolean type of device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property to be set.</param>
        /// <param name="property">The property value to be set.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_bool_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetBoolProperty(ObDevicePtr device, PropertyId propertyId, NativeBool property, out ObErrorPtr error);

        // bool ob_device_get_bool_property(ob_device* device, ob_property_id property_id, ob_error** error);
        /// <summary>Get a boolean type of device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property ID.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The property value.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_bool_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool GetBoolProperty(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // void ob_device_set_structured_data(ob_device* device, ob_property_id property_id, const void* data, uint32_t data_size, ob_error** error);
        /// <summary>Set structured data.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property to be set.</param>
        /// <param name="data">The property data to be set.</param>
        /// <param name="dataSize">The size of the property to be set.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_structured_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetStructuredData(ObDevicePtr device, PropertyId propertyId, IntPtr data, uint dataSize, out ObErrorPtr error);

        // void ob_device_get_structured_data(ob_device* device, ob_property_id property_id, void* data, uint32_t* data_size, ob_error** error);
        /// <summary>Get structured data of a device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property.</param>
        /// <param name="data">The obtained property data.</param>
        /// <param name="dataSize">The size of the obtained property data.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_structured_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GetStructuredData(ObDevicePtr device, PropertyId propertyId, IntPtr data, ref uint dataSize, out ObErrorPtr error);

        // void ob_device_set_raw_data(ob_device* device, ob_property_id property_id,
        //                             void* data, uint32_t data_size, ob_set_data_callback cb, bool async, void* user_data,
        //                             ob_error** error);
        /// <summary>Set raw data of a device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property to be set.</param>
        /// <param name="data">The property data to be set.</param>
        /// <param name="dataSize">The size of the property data to be set.</param>
        /// <param name="cb">The set data callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-define data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_raw_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SetRawData(ObDevicePtr device, PropertyId propertyId, IntPtr data, uint dataSize,
            ObSetDataCallback cb, NativeBool async, IntPtr userData, out ObErrorPtr error);

        // void ob_device_get_raw_data(ob_device* device, ob_property_id property_id,
        //                             ob_get_data_callback cb, bool async, void* user_data,
        //                             ob_error** error);
        /// <summary>Get raw data of a device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The ID of the property.</param>
        /// <param name="cb">The get data callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-define data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_raw_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void GetRawData(ObDevicePtr device, PropertyId propertyId,
            ObGetDataCallback cb, NativeBool async, IntPtr userData, out ObErrorPtr error);

        /// <summary>Get the protocol version of the device.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The protocol version of the device.</returns>
        // ob_protocol_version ob_device_get_protocol_version(ob_device *device, ob_error **error);
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_protocol_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ProtocolVersion GetProtocolVersion(ObDevicePtr device, out ObErrorPtr error);

        // ob_cmd_version ob_device_get_cmd_version(ob_device *device, ob_property_id property_id, ob_error **error);
        /// <summary>Get the cmdVersion of a property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property id.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The cmdVersion of the property.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_cmd_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern CmdVersion GetCmdVersion(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // uint32_t ob_device_get_supported_property_count(ob_device *device, ob_error **error);
        /// <summary>Get the number of properties supported by the device.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The number of properties supported by the device.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_supported_property_count", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint GetSupportedPropertyCount(ObDevicePtr device, out ObErrorPtr error);

        // ob_property_item ob_device_get_supported_property(ob_device *device, uint32_t index, ob_error **error);
        /// <summary>Get the type of property supported by the device.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="index">The property index.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The type of property supported by the device.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_supported_property", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObPropertyItem GetSupportedProperty(ObDevicePtr device, uint index, out ObErrorPtr error);

        // bool ob_device_is_property_supported(ob_device *device, ob_property_id property_id, ob_permission_type permission, ob_error **error);
        /// <summary>Check if a device property permission is supported.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property id.</param>
        /// <param name="permission">The type of permission that needs to be interpreted.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>Whether the property permission is supported.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_is_property_supported", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool IsPropertySupported(ObDevicePtr device, PropertyId propertyId, PermissionType permission, out ObErrorPtr error);

        // ob_int_property_range ob_device_get_int_property_range(ob_device *device, ob_property_id property_id, ob_error **error);
        /// <summary>Get the integer type of device property range.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property id.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The property range.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_int_property_range", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObIntPropertyRange GetIntPropertyRange(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // ob_float_property_range ob_device_get_float_property_range(ob_device *device, ob_property_id property_id, ob_error **error);
        /// <summary>Get the float type of device property range.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property id.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The property range.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_float_property_range", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObFloatPropertyRange GetFloatPropertyRange(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // ob_bool_property_range ob_device_get_bool_property_range(ob_device *device, ob_property_id property_id, ob_error **error);
        /// <summary>Get the boolean type of device property range.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="propertyId">The property id.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The property range.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_bool_property_range", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObBoolPropertyRange GetBoolPropertyRange(ObDevicePtr device, PropertyId propertyId, out ObErrorPtr error);

        // void ob_device_write_ahb(ob_device *device, uint32_t reg, uint32_t mask, uint32_t value, ob_error **error);
        /// <summary>Write to an AHB register.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="reg">The register to be written.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="value">The value to be written</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_write_ahb", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void WriteAhb(ObDevicePtr device, uint reg, uint mask, uint value, out ObErrorPtr error);

        // void ob_device_read_ahb(ob_device *device, uint32_t reg, uint32_t mask, uint32_t *value, ob_error **error);
        /// <summary>Read an AHB register.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="reg">The register to be read.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="value">The value to be read.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_read_ahb", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ReadAhb(ObDevicePtr device, uint reg, uint mask, out uint value, out ObErrorPtr error);

        // void ob_device_write_i2c(ob_device *device, uint32_t module_id, uint32_t reg, uint32_t mask, uint32_t value, ob_error **error);
        /// <summary>Write to an I2C register.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="moduleId">The I2C module id to be written.</param>
        /// <param name="reg">The register to be written.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="value">The value to be written</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_write_i2c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void WriteI2C(ObDevicePtr device, uint moduleId, uint reg, uint mask, uint value, out ObErrorPtr error);

        // void ob_device_read_i2c(ob_device *device, uint32_t module_id, uint32_t reg, uint32_t mask, uint32_t *value, ob_error **error);
        /// <summary>Read an I2C register.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="moduleId">The id of the I2C module to be read.</param>
        /// <param name="reg">The register to be read.</param>
        /// <param name="mask">The mask.</param>
        /// <param name="value">The value to be read</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_read_i2c", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ReadI2C(ObDevicePtr device, uint moduleId, uint reg, uint mask, out uint value, out ObErrorPtr error);

        // void ob_device_write_flash(ob_device *device, uint32_t offset, const void *data, uint32_t data_size, ob_set_data_callback cb,
        //                            bool async, void *user_data, ob_error **error);
        /// <summary>Set the properties of writing to Flash [Asynchronous Callback].</summary>
        /// <param name="device">The device object.</param>
        /// <param name="offset">The flash offset address.</param>
        /// <param name="data">The property data to be written.</param>
        /// <param name="dataSize">The size of the property to be written.</param>
        /// <param name="cb">The set data callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-defined data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_write_flash", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void WriteFlash(ObDevicePtr device, uint offset, IntPtr data, uint dataSize, ObSetDataCallback cb,
            NativeBool async, IntPtr userData, out ObErrorPtr error);

        // void ob_device_read_flash(ob_device *device, uint32_t offset, uint32_t data_size, ob_get_data_callback cb,
        //                           bool async, void *user_data, ob_error **error);
        /// <summary>Read Flash properties [asynchronous callback].</summary>
        /// <param name="device">The device object.</param>
        /// <param name="offset">The flash offset address.</param>
        /// <param name="dataSize">The size of the data to be read.</param>
        /// <param name="cb">The read flash data and progress callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-defined data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_read_flash", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ReadFlash(ObDevicePtr device, uint offset, uint dataSize,ObGetDataCallback cb,
            NativeBool async, IntPtr userData, out ObErrorPtr error);

        // void ob_device_write_customer_data(ob_device *device, const void *data, uint32_t data_size, ob_error **error);
        /// <summary>Set customer data.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="data">The property data to be set.</param>
        /// <param name="dataSize">The size of the property to be set,the maximum length cannot exceed 65532 bytes.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_write_customer_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void WriteCustomerData(ObDevicePtr device, IntPtr data, uint dataSize, out ObErrorPtr error);

        // void ob_device_read_customer_data(ob_device *device, void *data, uint32_t *data_size, ob_error **error);
        /// <summary>Get customer data of a device property.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="data">The obtained property data.</param>
        /// <param name="dataSize">The size of the obtained property data.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_read_customer_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void ReadCustomerData(ObDevicePtr device, IntPtr data, ref uint dataSize, out ObErrorPtr error);

        // void ob_device_upgrade(ob_device *device, const char *path, ob_device_upgrade_callback callback,
        //                        bool async, void *user_data, ob_error **error);
        /// <summary>Upgrade the device firmware.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="path">The firmware path.</param>
        /// <param name="callback">The firmware upgrade progress callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-defined data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_upgrade", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Upgrade(ObDevicePtr device, [MarshalAs(UnmanagedType.LPStr)] string path,
            ObDeviceUpgradeCallback callback, NativeBool async, IntPtr userData, out ObErrorPtr error);

        // void ob_device_upgrade_from_data(ob_device *device, const char *file_data, uint32_t file_size,
        //                                  ob_device_upgrade_callback callback, bool async, void *user_data, ob_error **error);
        /// <summary>Upgrade the device firmware.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="fileData">The firmware file data.</param>
        /// <param name="fileSize">The firmware file size.</param>
        /// <param name="callback">The firmware upgrade progress callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-defined data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_upgrade_from_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void UpgradeFromData(ObDevicePtr device, IntPtr fileData, uint fileSize,
            ObDeviceUpgradeCallback callback, NativeBool async, IntPtr userData, out ObErrorPtr error);

        // ob_device_state ob_device_get_device_state(ob_device *device, ob_error **error);
        /// <summary>Get the current device status.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_device_state", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DeviceState GetDeviceState(ObDevicePtr device, out ObErrorPtr error);

        // void ob_device_state_changed(ob_device *device, ob_device_state_callback callback, void *user_data, ob_error **error);
        /// <summary>Monitor device state changes.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="callback">The callback function to be called when the device status changes.</param>
        /// <param name="userData">User-defined data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_state_changed", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void StateChanged(ObDevicePtr device, ObDeviceStateCallback callback, IntPtr userData, out ObErrorPtr error);


        // void ob_device_send_file_to_destination(ob_device *device, const char *file_path, const char *dst_path,
        //                                         ob_file_send_callback callback, bool async,
        //                                         void *user_data, ob_error **error);
        /// <summary>Send files to the specified path on the device.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="filePath">The source file path.</param>
        /// <param name="dstPath">The destination path on the device.</param>
        /// <param name="callback">The file sending progress callback.</param>
        /// <param name="async">Whether to execute asynchronously.</param>
        /// <param name="userData">User-defined data that will be returned in the callback.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_send_file_to_destination", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void SendFileToDestination(ObDevicePtr device,
            [MarshalAs(UnmanagedType.LPStr)] string filePath, [MarshalAs(UnmanagedType.LPStr)] string dstPath,
            ObFileSendCallback callback, NativeBool async, IntPtr userData, out ObErrorPtr error);

        // bool ob_device_activate_authorization(ob_device *device, const char *auth_code, ob_error **error);
        /// <summary>Verify the device authorization code.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="authCode">The authorization code.</param>
        /// <param name="error">Log error messages.</param>
        /// <remarks>Whether the activation is successful.</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_activate_authorization", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern NativeBool ActivateAuthorization(ObDevicePtr device, [MarshalAs(UnmanagedType.LPStr)] string authCode, out ObErrorPtr error);

        // void ob_device_write_authorization_code(ob_device *device, const char *auth_code, ob_error **error);
        /// <summary><Write the device authorization code./summary>
        /// <param name="device">The device object.</param>
        /// <param name="authCode">The authorization code.</param>
        /// <param name="error">Log error messages.</param>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_write_authorization_code", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void WriteAuthorizationCode(ObDevicePtr device, [MarshalAs(UnmanagedType.LPStr)] string authCode, out ObErrorPtr error);

        // ob_camera_param_list* ob_device_get_calibration_camera_param_list(ob_device *device, ob_error **error);
        /// <summary>Get the original parameter list of camera calibration saved on the device.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The camera parameter list.</returns>
        /// <remarks>
        /// The parameters in the list do not correspond to the current open-stream configuration.
        /// You need to select the parameters according to the actual situation,
        /// and may need to do scaling, mirroring and other processing.
        /// Non-professional users are recommended to use the ob_pipeline_get_camera_param() interface.
        /// </remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_calibration_camera_param_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObCameraParamListPtr GetCalibrationCameraParamList(ObDevicePtr device, out ObErrorPtr error);

        // ob_depth_work_mode ob_device_get_current_depth_work_mode(ob_device *device, ob_error **error);
        /// <summary>Get the current depth work mode.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The current depth work mode.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_current_depth_work_mode", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern DepthWorkMode GetCurrentDepthWorkMode(ObDevicePtr device, out ObErrorPtr error);

        // ob_status ob_device_switch_depth_work_mode(ob_device *device, const ob_depth_work_mode *work_mode, ob_error **error);
        /// <summary>Switch the depth work mode by ob_depth_work_mode.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="workMode">The depth work mode from ob_depth_work_mode_list which is returned by ob_device_get_depth_work_mode_list.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The switch result. OB_STATUS_OK: success, other failed.</returns>
        /// <remarks>Prefer to use ob_device_switch_depth_work_mode_by_name to switch depth mode when the complete name of the depth work mode is known.</remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_switch_depth_work_mode", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStatus SwitchDepthWorkMode(ObDevicePtr device, [In] ref DepthWorkMode workMode, out ObErrorPtr error);

        // ob_status ob_device_switch_depth_work_mode_by_name(ob_device *device, const char *mode_name, ob_error **error);
        /// <summary>Switch the depth work mode by work mode name.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="modeName">The depth work mode name which is equal to ob_depth_work_mode.name.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The switch result. OB_STATUS_OK: success, other failed.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_switch_depth_work_mode_by_name", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObStatus SwitchDepthWorkModeByName(ObDevicePtr device, [MarshalAs(UnmanagedType.LPStr)] string modeName, out ObErrorPtr error);

        // ob_depth_work_mode_list* ob_device_get_depth_work_mode_list(ob_device *device, ob_error **error);
        /// <summary>Request the list of supported depth work modes.</summary>
        /// <param name="device">The device object.</param>
        /// <param name="error">Log error messages.</param>
        /// <returns>The list of ob_depth_work_mode.</returns>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_depth_work_mode_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ObDepthWorkModeListPtr GetDepthWorkModeList(ObDevicePtr device, out ObErrorPtr error);

        // void ob_device_reboot(ob_device *device, ob_error **error);
        /// <summary>Device reboot</summary>
        /// <param name="device">Device object</param>
        /// <param name="error">Log error messages</param>
        /// <remarks>
        /// The device will be disconnected and reconnected.
        /// After the device is disconnected, the interface access to the device handle may be abnormal.
        /// Please use the <see cref="DeleteDevice(ObDevicePtr, out ObErrorPtr)"/> interface to delete the handle directly.
        /// After the device is reconnected, it can be obtained again.
        /// </remarks>
        [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_reboot", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void Reboot(ObDevicePtr device, out ObErrorPtr error);
    }
}
