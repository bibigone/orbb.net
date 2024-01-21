using System.Runtime.InteropServices;

namespace OrbbDotNet;

/// <summary>The synchronization configuration of the device.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct MultiDeviceSyncConfig
{
    /// <summary>The sync mode of the device.</summary>
    public MultiDeviceSyncMode SyncMode;

    /// <summary>The delay time of the depth image capture after receiving the capture command or trigger signal in microseconds.</summary>
    /// <remarks>This parameter is only valid for some models. Please refer to the product manual for details.</remarks>
    public int DepthDelayUs;

    /// <summary>The delay time of the color image capture after receiving the capture command or trigger signal in microseconds.</summary>
    /// <remarks>This parameter is only valid for some models， please refer to the product manual for details.</remarks>
    public int ColorDelayUs;

    /// <summary>The delay time of the image capture after receiving the capture command or trigger signal in microseconds.</summary>
    /// <remarks><para>
    /// The depth and color images are captured synchronously
    /// as the product design and can not change the delay between the depth and color images.
    /// </para><para>
    /// For Orbbec Astra 2 device, this parameter is valid only when the <see cref="TriggerOutDelayUs"/>  is set to 0.
    /// </para><para>
    /// This parameter is only valid for some models to replace <see cref="DepthDelayUs"/> and <see cref="ColorDelayUs"/>,
    /// please refer to the product manual for details.
    /// </para></remarks>
    public int Trigger2ImageDelayUs;

    private Native.NativeBool triggerOutEnable;

    /// <summary>Trigger signal output enable flag.</summary>
    /// <remarks><para>
    /// After the trigger signal output is enabled, the trigger signal will be output
    /// when the capture command or trigger signal is received. User can
    /// adjust the delay time of the trigger signal output by <see cref="TriggerOutDelayUs"/>.
    /// </para><para>
    /// For some models, the trigger signal output is always enabled and cannot be disabled.
    /// </para><para>
    /// If device is in the <see cref="MultiDeviceSyncMode.FreeRun"/> or <see cref="MultiDeviceSyncMode.Standalone"/> mode,
    /// the trigger signal output is always disabled.Set this parameter to true will not take effect.
    /// </para></remarks>
    public bool TriggerOutEnable
    {
        get => triggerOutEnable;
        set => triggerOutEnable = value;
    }

    /// <summary>The delay time of the trigger signal output after receiving the capture command or trigger signal in microseconds.</summary>
    /// <remarks>
    /// For Orbbec Astra 2 device, only supported -1 and 0. -1 means the trigger signal output delay
    /// is automatically adjusted by the device, 0 means the trigger signal output is disabled.
    /// </remarks>
    public int TriggerOutDelayUs;

    /// <summary>The frame number of each stream after each trigger in triggering mode.</summary>
    /// <remarks><para>
    /// This parameter is only valid when the triggering mode is set to <see cref="MultiDeviceSyncMode.HardwareTriggering"/>
    /// or <see cref="MultiDeviceSyncMode.SoftwareTriggering"/>.
    /// </para><para>
    /// The trigger frequency multiplied by the number of frames per trigger cannot exceed
    /// the maximum frame rate of the stream profile which is set when starting the stream.
    /// </para></remarks>
    public int FramesPerTrigger;
}