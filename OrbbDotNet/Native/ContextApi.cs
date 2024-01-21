using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

/// <summary>DLL imports from <c>Context.h</c> header file.</summary>
internal static class ContextApi
{
    // ob_context* ob_create_context(ob_error** error);
    /// <summary>Create a context object</summary>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during context creation</param>
    /// <returns>Pointer to the created context object</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_create_context", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObContextPtr CreateContext(out ObErrorPtr error);

    // ob_context *ob_create_context_with_config(const char *config_path, ob_error **error);
    /// <summary>Create a context object with a specified configuration file</summary>
    /// <param name="configPath">Path to the configuration file. If NULL, the default configuration file will be used.</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during context creation</param>
    /// <returns>Pointer to the created context object</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_create_context_with_config", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObContextPtr CreateContextWithConfig([MarshalAs(UnmanagedType.LPStr)] string configPath, out ObErrorPtr error);

    // void ob_delete_context(ob_context* context, ob_error** error);
    /// <summary>Delete a context object</summary>
    /// <param name="context">Pointer to the context object to be deleted</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during context deletion</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_context", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteContext(ObContextPtr context, out ObErrorPtr error);

    // ob_device_list *ob_query_device_list(ob_context *context, ob_error **error);
    /// <summary>Get a list of enumerated devices</summary>
    /// <param name="context">Pointer to the context object</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during device enumeration</param>
    /// <remarks>Pointer to the device list object</remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_query_device_list", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObDeviceListPtr QueryDeviceList(ObContextPtr context, out ObErrorPtr error);

    // void ob_enable_net_device_enumeration(ob_context *context, bool enable, ob_error **error);
    /// <summary>Enable or disable network device enumeration</summary>
    /// <param name="context">Pointer to the context object</param>
    /// <param name="enable"><see langword="true"/> to enable, <see langword="false"/> to disable</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs.</param>
    /// <remarks><para>
    /// After enabling, the network device will be automatically discovered and can be retrieved through
    /// <see cref="QueryDeviceList(ObContextPtr, out ObErrorPtr)"/>.
    /// The default state can be set in the configuration file.
    /// </para><para>
    /// Network device enumeration is performed through the GVCP protocol.
    /// If the device is not in the same subnet as the host, it will be discovered but cannot be connected.
    /// </para></remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_enable_net_device_enumeration", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EnableNetDeviceEnumeration(ObContextPtr context, NativeBool enable, out ObErrorPtr error);

    // ob_device* ob_create_net_device(ob_context *context, const char *address, uint16_t port, ob_error **error);
    /// <summary>Create a network device object</summary>
    /// <param name="context">Pointer to the context object</param>
    /// <param name="address">IP address of the device</param>
    /// <param name="port">Port number of the device</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during device creation</param>
    /// <returns>Pointer to the created device object</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_create_net_device", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObDevicePtr CreateNetDevice(ObContextPtr context, [MarshalAs(UnmanagedType.LPStr)] string address, ushort port, out ObErrorPtr error);

    // void ob_set_device_changed_callback(ob_context *context, ob_device_changed_callback callback, void *user_data, ob_error **error);
    /// <summary>Set a device plug-in callback function</summary>
    /// <param name="context">Pointer to the context object</param>
    /// <param name="callback">Pointer to the callback function triggered when a device is plugged or unplugged</param>
    /// <param name="userData">Pointer to user data that can be passed to and retrieved from the callback function</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during callback function setting</param>
    /// <remarks>The added and removed device lists returned through the callback interface need to be released manually</remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_set_device_changed_callback", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetDeviceChangedCallback(ObContextPtr context, ObDeviceChangedCallback callback, IntPtr userData, out ObErrorPtr error);

    // void ob_enable_device_clock_sync(ob_context *context, uint64_t repeatInterval, ob_error **error);
    /// <summary>Activates device clock synchronization to synchronize the clock of the host and all created devices (if supported).</summary>
    /// <param name="context">Pointer to the context object</param>
    /// <param name="repeatInterval">The interval for auto-repeated synchronization, in milliseconds. If the value is 0, synchronization is performed only once.</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during execution</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_enable_device_clock_sync", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EnableDeviceClockSync(ObContextPtr context, ulong repeatInterval, out ObErrorPtr error);

    // void ob_free_idle_memory(ob_context *context, ob_error **error);
    /// <summary>Free idle memory from the internal frame memory pool</summary>
    /// <param name="context">Pointer to the context object</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during memory freeing</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_free_idle_memory", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void FreeIdleMemory(ObContextPtr context, out ObErrorPtr error);

    // void ob_set_logger_severity(ob_log_severity severity, ob_error **error);
    /// <summary>Set the global log level</summary>
    /// <param name="severity">Log level to set</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during log level setting</param>
    /// <remarks>This interface setting will affect the output level of all logs (terminal, file, callback)</remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_set_logger_severity", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoggerSeverity(ObLogSeverity severity, out ObErrorPtr error);

    // void ob_set_logger_to_file(ob_log_severity severity, const char *directory, ob_error **error);
    /// <summary>Set the log output to a file</summary>
    /// <param name="severity">Log level to output to file</param>
    /// <param name="directory">
    /// Path to the log file output directory.
    /// If the path is empty, the existing settings will continue to be used
    /// (if the existing configuration is also empty, the log will not be output to the file)
    /// </param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during log level setting</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_set_logger_to_file", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoggerToFile(ObLogSeverity severity, [MarshalAs(UnmanagedType.LPStr)] string directory, out ObErrorPtr error);

    // void ob_set_logger_callback(ob_log_severity severity, ob_log_callback callback, void *user_data, ob_error **error);
    /// <summary>Set the log callback function</summary>
    /// <param name="severity">Log level to set for the callback function</param>
    /// <param name="callback">Pointer to the callback function. Cannot be <see langword="null"/>.</param>
    /// <param name="userData">Pointer to user data that can be passed to and retrieved from the callback function</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during log callback function setting</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_set_logger_callback", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoggerCallback(ObLogSeverity severity, ObLogCallback callback, IntPtr userData, out ObErrorPtr error);

    // void ob_set_logger_to_console(ob_log_severity severity, ob_error **error);
    /// <summary>Set the log output to the console</summary>
    /// <param name="severity">Log level to output to the console</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during log output setting</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_set_logger_to_console", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoggerToConsole(ObLogSeverity severity, out ObErrorPtr error);

    // void ob_load_license(const char *filePath, const char *key, ob_error **error);
    /// <summary>Load a license file</summary>
    /// <param name="filePath">Path to the license file</param>
    /// <param name="key">Decryption key. "OB_DEFAULT_DECRYPT_KEY" can be used to represent the default key.</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during license loading</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_load_license", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadLicense([MarshalAs(UnmanagedType.LPStr)] string filePath, [MarshalAs(UnmanagedType.LPStr)] string key, out ObErrorPtr error);

    // void ob_load_license_from_data(const char *data, uint32_t dataLen, const char *key, ob_error **error);
    /// <summary>Load a license from data</summary>
    /// <param name="data">Pointer to the license data</param>
    /// <param name="dataLen">Length of the license data</param>
    /// <param name="key">Decryption key. "OB_DEFAULT_DECRYPT_KEY" can be used to represent the default key.</param>
    /// <param name="error">Pointer to an error object that will be populated if an error occurs during license loading</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_load_license_from_data", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadLicenseFromData(IntPtr data, uint dataLen, IntPtr key, out ObErrorPtr error);
}
