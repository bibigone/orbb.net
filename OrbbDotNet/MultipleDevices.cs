using System;
using System.Collections.Generic;

namespace OrbbDotNet;

/// <summary>
/// This class contains the multiple devices related extension methods
/// that are used to control the synchronization between multiple devices and the synchronization
/// between different sensor within single device.
/// </summary>
/// <remarks><para>
/// The synchronization between multiple devices is complex, and different models have different synchronization modes and limitations.
/// Please refer to the product manual for details.
/// </para><para>
/// As the Depth and Infrared are the same sensor physically,
/// the behavior of the Infrared is same as the Depth in the synchronization mode.
/// </para></remarks>
public static class MultipleDevices
{
    /// <summary>Gets the supported multi device sync mode bitmap of the device.</summary>
    /// <param name="device">Device object.</param>
    /// <returns>Supported multi device sync modes by the device.</returns>
    public static IEnumerable<MultiDeviceSyncMode> GetSupportedMultiDeviceSyncModes(this Device device)
    {
        var modes = Native.MultipleDevicesApi.GetSupportedMultiDeviceSyncModeBitmap(device.NativePtr, out var error);
        ObException.CheckError(ref error);

        foreach (MultiDeviceSyncMode mode in Enum.GetValues(typeof(MultiDeviceSyncMode)))
        {
            if ((modes & (int)mode) != 0)
                yield return mode;
        }
    }

    /// <summary>Sets the multi device sync configuration of the device.</summary>
    /// <param name="device">Device object.</param>
    /// <param name="config">The multi device sync configuration.</param>
    public static void SetMultiDeviceSyncConfig(this Device device, MultiDeviceSyncConfig config)
    {
        Native.MultipleDevicesApi.SetMultiDeviceSyncConfig(device.NativePtr, ref config, out var error);
        ObException.CheckError(ref error);
    }

    /// <summary>Gets the multi device sync configuration of the device.</summary>
    /// <param name="device">Device object.</param>
    /// <returns>The multi device sync configuration of the device.</returns>
    public static MultiDeviceSyncConfig GetMultiDeviceSyncConfig(this Device device)
    {
        var res = Native.MultipleDevicesApi.GetMultiDeviceSyncConfig(device.NativePtr, out var error);
        ObException.CheckError(ref error);
        return res;
    }

    /// <summary>Sends the capture command to the device.</summary>
    /// <param name="device">Device object.</param>
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
    public static void TriggerCapture(this Device device)
    {
        Native.MultipleDevicesApi.TriggerCapture(device.NativePtr, out var error);
        ObException.CheckError(ref error);
    }

    /// <summary>Set the timestamp reset configuration of the device.</summary>
    /// <param name="device">Device object.</param>
    /// <param name="config">The timestamp reset configuration.</param>
    public static void SetTimestampResetConfig(this Device device, DeviceTimestampConfig config)
    {
        Native.MultipleDevicesApi.SetTimestampResetConfig(device.NativePtr, ref config, out var error);
        ObException.CheckError(ref error);
    }

    /// <summary>Get the timestamp reset configuration of the device.</summary>
    /// <param name="device">Device object.</param>
    /// <returns>The timestamp reset configuration of the device.</returns>
    public static DeviceTimestampConfig GetTimestampResetConfig(this Device device)
    {
        var res = Native.MultipleDevicesApi.GetTimestampResetConfig(device.NativePtr, out var error);
        ObException.CheckError(ref error);
        return res;
    }

    /// <summary>Synchronizes the timer of the device with the host.</summary>
    /// <param name="device">Device object.</param>
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
    public static void SyncTimeWithHost(this Device device)
    {
        Native.MultipleDevicesApi.TimerSyncWithHost(device.NativePtr, out var error);
        ObException.CheckError(ref error);
    }
}
