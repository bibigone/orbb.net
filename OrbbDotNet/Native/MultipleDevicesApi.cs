using static OrbbDotNet.Native.ObTypes;
using System.Runtime.InteropServices;

namespace OrbbDotNet.Native;

/// <summary>DLL imports from <c>MultipleDevices.h</c> header file.</summary>
internal static class MultipleDevicesApi
{
    // uint16_t ob_device_get_supported_multi_device_sync_mode_bitmap(ob_device *device, ob_error **error);
    /// <summary>Get the supported multi device sync mode bitmap of the device.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="error">Log error messages.</param>
    /// <returns>return the supported multi device sync mode bitmap of the device.</returns>
    /// <remarks>
    /// For example, if the return value is 0b00001100, it means the device supports OB_MULTI_DEVICE_SYNC_MODE_PRIMARY
    /// and OB_MULTI_DEVICE_SYNC_MODE_SECONDARY.
    /// </remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_supported_multi_device_sync_mode_bitmap", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ushort GetSupportedMultiDeviceSyncModeBitmap(ObDevicePtr device, out ObErrorPtr error);

    // void ob_device_set_multi_device_sync_config(ob_device* device, const ob_multi_device_sync_config* config, ob_error **error);
    /// <summary>set the multi device sync configuration of the device.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="config">The multi device sync configuration.</param>
    /// <param name="error">The error information.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_multi_device_sync_config", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMultiDeviceSyncConfig(ObDevicePtr device, [In] ref MultiDeviceSyncConfig config, out ObErrorPtr error);

    // ob_multi_device_sync_config ob_device_get_multi_device_sync_config(ob_device* device, ob_error** error);
    /// <summary>get the multi device sync configuration of the device.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="error">The error information.</param>
    /// <returns>return the multi device sync configuration of the device.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_multi_device_sync_config", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern MultiDeviceSyncConfig GetMultiDeviceSyncConfig(ObDevicePtr device, out ObErrorPtr error);

    // void ob_device_trigger_capture(ob_device* device, ob_error** error);
    /// <summary>send the capture command to the device.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="error">The error information.</param>
    /// <remarks><para>
    /// The device will start one time image capture after receiving the capture command when it is in the <see cref="MultiDeviceSyncMode.SoftwareTriggering"/>.
    /// </para><para>
    /// The frequency of the user call this function multiplied by the number of frames per trigger
    /// should be less than the frame rate of the stream. The number of frames per trigger can be set by <see cref="MultiDeviceSyncConfig.FramesPerTrigger"/>.
    /// </para><para>
    /// For some models，receive and execute the capture command will have a certain delay and performance consumption,
    /// so the frequency of calling this function should not be too high,
    /// please refer to the product manual for the specific supported frequency.
    /// </para><para>
    /// If the device is not in the <see cref="MultiDeviceSyncMode.HardwareTriggering"/> mode, device will ignore the capture command.
    /// </para></remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_trigger_capture", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TriggerCapture(ObDevicePtr device, out ObErrorPtr error);

    //void ob_device_set_timestamp_reset_config(ob_device* device, const ob_device_timestamp_reset_config* config, ob_error **error);
    /// <summary>set the timestamp reset configuration of the device.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="config">The timestamp reset configuration.</param>
    /// <param name="error">The error information.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_set_timestamp_reset_config", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTimestampResetConfig(ObDevicePtr device, [In] ref DeviceTimestampConfig config, out ObErrorPtr error);

    // ob_device_timestamp_reset_config ob_device_get_timestamp_reset_config(ob_device* device, ob_error** error);
    /// <summary>get the timestamp reset configuration of the device.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="error">The error information.</param>
    /// <returns>return the timestamp reset configuration of the device.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_get_timestamp_reset_config", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern DeviceTimestampConfig GetTimestampResetConfig(ObDevicePtr device, out ObErrorPtr error);

    // void ob_device_timer_sync_with_host(ob_device* device, ob_error** error);
    /// <summary>synchronize the timer of the device with the host.</summary>
    /// <param name="device">The device handle.</param>
    /// <param name="error">The error information.</param>
    /// <remarks><para>
    /// After calling this function, the timer of the device will be synchronized with the host.
    /// User can call this function to multiple devices to synchronize all timers of the devices.
    /// </para><para>
    /// If the stream of the device is started,
    /// the timestamp of the continuous frames output by the stream will may jump once after the timer sync.
    /// </para><para>
    /// Due to the timer of device is not high-accuracy, the timestamp of the continuous frames output
    /// by the stream will drift after a long time. User can call this function periodically to synchronize
    /// the timer to avoid the timestamp drift, the recommended interval time is 60 minutes.
    /// </para></remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_device_timer_sync_with_host", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TimerSyncWithHost(ObDevicePtr device, out ObErrorPtr error);
}
