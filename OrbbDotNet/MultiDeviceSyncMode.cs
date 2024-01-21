namespace OrbbDotNet;

// typedef enum { ... } } ob_multi_device_sync_mode, OBMultiDeviceSyncMode;
/// <summary>The synchronization mode of the device.</summary>
public enum MultiDeviceSyncMode
{
    /// <summary>free run mode</summary>
    /// <remarks>
    /// The device does not synchronize with other devices,
    /// The Color and Depth can be set to different frame rates.
    /// </remarks>
    FreeRun = 1 << 0,

    /// <summary>standalone mode</summary>
    /// <remarks>The Color and Depth should be set to same frame rates, the Color and Depth will be synchronized.</remarks>
    Standalone = 1 << 1,

    /// <summary>primary mode</summary>
    /// <remarks>
    /// The device is the primary device in the multi-device system,
    /// it will output the trigger signal via VSYNC_OUT pin on synchronization port by default.
    /// The Color and Depth should be set to same frame rates,
    /// the Color and Depth will be synchronized and can be adjusted by colorDelayUs, depthDelayUs or trigger2ImageDelayUs.
    /// </remarks>
    Primary = 1 << 2,

    /// <summary>secondary mode</summary>
    /// <remarks><para>
    /// The device is the secondary device in the multi-device system,
    /// it will receive the trigger signal via VSYNC_IN pin on synchronization port.
    /// It will out the trigger signal via VSYNC_OUT pin on synchronization port by default.
    /// </para><para>
    /// The Color and Depth should be set to same frame rates, the Color and Depth will be synchronized
    /// and can be adjusted by colorDelayUs, depthDelayUs or trigger2ImageDelayUs.
    /// </para><para>
    /// After starting the stream, the device will wait for the trigger signal to start capturing images,
    /// and will stop capturing images when the trigger signal is stopped.
    /// </para><para>
    /// The frequency of the trigger signal should be same as the frame rate of the stream profile which is set when starting the stream.
    /// </para></remarks>
    Secondary = 1 << 3,

    /// <summary>secondary synced mode</summary>
    /// <remarks><para>
    /// The device is the secondary device in the multi-device system,
    /// it will receive the trigger signal via VSYNC_IN pin on synchronization port.
    /// It will out the trigger signal via VSYNC_OUT pin on synchronization port by default.
    /// </para><para>
    /// The Color and Depth should be set to same frame rates, the Color and Depth will be synchronized
    /// and can be adjusted by colorDelayUs, depthDelayUs or trigger2ImageDelayUs.
    /// </para><para>
    /// After starting the stream, the device will be immediately start capturing images,
    /// and will adjust the capture time when the trigger signal is received to synchronize with the primary device.
    /// If the trigger signal is stopped, the device will still capture images.
    /// </para><para>
    /// The frequency of the trigger signal should be same as the frame rate of the stream profile which is set when starting the stream.
    /// </para></remarks>
    SecondarySynced = 1 << 4,

    /// <summary>software triggering mode</summary>
    /// <remarks><para>
    /// The device will start one time image capture after receiving the capture command
    /// and will output the trigger signal via VSYNC_OUT pin by default.
    /// The capture command can be sent form host by call ob_device_trigger_capture.
    /// The number of images captured each time can be set by framesPerTrigger.
    /// </para><para>
    /// The Color and Depth should be set to same frame rates, the Color and Depth will be synchronized
    /// and can be adjusted by colorDelayUs, depthDelayUs or trigger2ImageDelayUs.
    /// </para><para>
    /// The frequency of the user call ob_device_trigger_capture to send the capture command
    /// multiplied by the number of frames per trigger should be
    /// less than the frame rate of the stream profile which is set when starting the stream.
    /// </para></remarks>
    SoftwareTriggering = 1 << 5,

    /// <summary>hardware triggering mode</summary>
    /// <remarks><para>
    /// The device will start one time image capture after receiving the trigger signal via VSYNC_IN pin on synchronization port
    /// and will output the trigger signal via VSYNC_OUT pin by default.
    /// The number of images captured each time can be set by framesPerTrigger.
    /// </para><para>
    /// The Color and Depth should be set to same frame rates, the Color and Depth will be synchronized
    /// and can be adjusted by colorDelayUs, depthDelayUs or trigger2ImageDelayUs.
    /// </para><para>
    /// The frequency of the trigger signal multiplied by the number of frames per trigger should be less than
    /// the frame rate of the stream profile which is set when starting the stream.
    /// </para><para>
    /// The trigger signal input via VSYNC_IN pin on synchronization port should be ouput by other device
    /// via VSYNC_OUT pin in hardware triggering mode or software triggering mode.
    /// </para><para>
    /// Due to different models may have different signal input requirements,
    /// please do not use different models to output trigger signal as input-trigger signal.
    /// </para></remarks>
    HardwareTriggering = 1 << 6,
}
