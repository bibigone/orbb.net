namespace OrbbDotNet;

// Typedef enum { } OBPropertyID, ob_property_id
/// <summary>Enumeration value describing all attribute control commands of the Device</summary>
public enum PropertyId : int
{
    /// <summary>LDP switch</summary>
    Ldp_Bool = 2,

    /// <summary>Laser switch</summary>
    Laser_Bool = 3,

    /// <summary>laser pulse width</summary>
    LaserPulseWidth_Int = 4,

    /// <summary>Laser Current (uint: mA)</summary>
    LaserCurrentFloat = 5,

    /// <summary>IR flood switch</summary>
    Flood_Bool = 6,

    /// <summary>IR flood level</summary>
    FloodLevel_Int = 7,

    /// <summary>Depth mirror</summary>
    DepthMirror_Bool = 14,

    /// <summary>Depth flip</summary>
    DepthFlip_Bool = 15,

    /// <summary>Depth post-filter</summary>
    DepthPostfilter_Bool = 16,

    /// <summary>Depth hole-filter</summary>
    DepthHolefilter_Bool = 17,

    /// <summary>IR mirror</summary>
    IRMirror_Bool = 18,

    /// <summary>IR flip</summary>
    IRFlip_Bool = 19,

    /// <summary>Minimum depth threshold</summary>
    MinDepth_Int = 22,

    /// <summary>Maximum depth threshold</summary>
    MaxDepth_Int = 23,

    /// <summary>Software filter switch</summary>
    DepthSoftFilter_Bool = 24,

    /// <summary>LDP status</summary>
    LdpStatus_Bool = 32,

    /// <summary>Soft filter MaxDiff param</summary>
    DepthMaxDiff_Int = 40,

    /// <summary>soft filter MaxSpeckleSize</summary>
    DepthMaxMaxSpeckleSize_Int = 41,

    /// <summary>Hardware D2C is on</summary>
    DepthAlignHardware_Bool = 42,

    /// <summary>Timestamp adjustment</summary>
    TimestampOffset_Int = 43,

    /// <summary>Hardware distortion switch Rectify</summary>
    HardwareDistorsionSwitch_Bool = 61,

    /// <summary>Fan mode switch</summary>
    FanWorkMode_Int = 62,

    /// <summary>Multi-resolution D2C Mode</summary>
    DepthAlignHardwareMode_Int = 63,

    /// <summary>Anti-collusion activation status</summary>
    AntiCollusionActivationStatus_Bool = 64,

    /// <summary>The depth precision level, which may change the depth frame data unit,
    /// needs to be confirmed through the <see cref="Frame.Depth.ValueScale"/> property of <see cref="Frame.Depth"/>.
    /// </summary>
    DepthPrecisionLevel_Int = 75,

    /// <summary>ToF filter range configuration</summary>
    ToFFilterRange_Int = 76,

    /// <summary>Laser mode, the firmware terminal currently only return 1: IR Drive, 2: Torch.</summary>
    LaserMode_Int = 79,

    /// <summary>brt2r-rectify function switch (brt2r is a special module on mx6600), 0: Disable, 1: Rectify Enable</summary>
    Rectify2_Bool = 80,

    /// <summary>Color mirror</summary>
    ColorMirror_Bool = 81,

    /// <summary>Color flip</summary>
    ColorFlip_Bool = 82,

    /// <summary>Indicator switch, 0: Disable, 1: Enable</summary>
    IndicatorLight_Bool = 83,

    /// <summary>Disparity to depth switch, 0: off, the depth stream outputs the disparity map; 1. On, the depth stream outputs the depth map.</summary>
    DisparityToDepth_Bool = 85,

    /// <summary>BRT function switch (anti-background interference), 0: Disable, 1: Enable</summary>
    Brt_Bool = 86,

    /// <summary>Watchdog function switch, 0: Disable, 1: Enable</summary>
    Watchdog_Bool = 87,

    /// <summary>External signal trigger restart function switch, 0: Disable, 1: Enable</summary>
    ExternalSignalReset_Bool = 88,

    /// <summary>Heartbeat monitoring function switch, 0: Disable, 1: Enable</summary>
    Heartbeat_Bool = 89,

    /// <summary>Depth cropping mode device: OB_DEPTH_CROPPING_MODE</summary>
    DepthCroppingMode_Int = 90,

    /// <summary>D2C preprocessing switch (such as RGB cropping), 0: off, 1: on</summary>
    D2CPreprocess_Bool = 91,

    /// <summary>Custom RGB cropping switch, 0 is off, 1 is on custom cropping, and the ROI cropping area is issued</summary>
    RgbCustomCrop_Bool = 94,

    /// <summary>Device operating mode (power consumption)</summary>
    DeviceWorkMode_Int = 95,

    /// <summary>Device communication type, 0: USB; 1: Ethernet(RTSP)</summary>
    DeviceCommunicationType_Int = 97,

    /// <summary>Switch infrared imaging mode, 0: active IR mode, 1: passive IR mode</summary>
    SwitchIRMode_Int = 98,

    /// <summary>Laser energy level</summary>
    LaserEnergyLevel_Int = 99,

    /// <summary>LDP's measure distance, unit: mm</summary>
    LdpMeasureDistance_Int = 100,

    /// <summary>Reset device time to zero</summary>
    TimerResetSignal_Bool = 104,

    /// <summary>Enable send reset device time signal to other device. true: enable, false: disable</summary>
    TimerResetTriggerOutEnable_Bool = 105,

    /// <summary>Delay to reset device time, unit: us (microseconds)</summary>
    TimerResetDelayUs_Int = 106,

    /// <summary>Signal to capture image</summary>
    CaptureImageSignal_Bool = 107,

    /// <summary>Right IR sensor mirror state</summary>
    IRRightMirror_Bool = 112,

    /// <summary>Number frame to capture once a 'Capture_Image_Signal_Bool' effect. range: [1, 255]</summary>
    CaptureImageFrameNumber_Int = 113,

    /// <summary>Right IR sensor Flip state. true: flip image, false: origin, default: false</summary>
    IRRightFlip_Bool = 114,

    /// <summary>Color sensor rotation, angle{0, 90, 180, 270}</summary>
    ColorRotate_Int = 115,

    /// <summary>IR/Left-IR sensor rotation, angle{0, 90, 180, 270}</summary>
    IRRotate_Int = 116,

    /// <summary>Right IR sensor rotation, angle{0, 90, 180, 270}</summary>
    IRRightRotate_Int = 117,

    /// <summary>Right IR sensor rotation, angle{0, 90, 180, 270}</summary>
    DepthRotate_Int = 118,

    /// <summary>Get hardware laser energy level which real state of laser element.
    /// <see cref="LaserEnergyLevel_Int"/> (99) will effect this command
    /// which it setting and changed the hardware laser energy level.
    /// </summary>
    LaserHWEnergyLevel_Int = 119,

    /// <summary>USB's power state, enum type: OBUSBPowerState</summary>
    UsbPowerState_Int = 121,

    /// <summary>DC's power state, enum type: OBDCPowerState</summary>
    DCPowerState_Int = 122,

    /// <summary>Device development mode switch, optional modes can refer to the definition in @ref OBDeviceDevelopmentMode,
    /// the default mode is @ref OB_USER_Mode</summary>
    /// <remarks>The device takes effect after rebooting when switching modes.</remarks>
    DeviceDevelopmentMode_Int = 129,

    /// <summary>Multi-DeviceSync synchronized signal trigger out is enable state. true: enable, false: disable</summary>
    SyncSignalTriggerOut_Bool = 130,

    /// <summary>Restore factory settings and factory parameters</summary>
    /// <remarks>This command can only be written, and the parameter value must be true. The command takes effect after restarting the device.</remarks>
    RestoreFactorySettings_Bool = 131,

    /// <summary>Enter recovery mode (flashing mode) when boot the device</summary>
    /// <remarks>The device will take effect after rebooting with the enable option.
    /// After entering recovery mode, you can upgrade the device system.
    /// Upgrading the system may cause system damage, please use it with caution.</remarks>
    Boot_IntoRecoveryMode_Bool = 132,

    /// <summary>Query whether the current device is running in recovery mode (read-only)</summary>
    DeviceInRecoveryMode_Bool = 133,

    /// <summary>Capture interval mode, 0:time interval, 1:number interval</summary>
    Capture_IntervalMode_Int = 134,

    /// <summary>Capture time interval</summary>
    CaptureImageTime_Interval_Int = 135,

    /// <summary>Capture number interval</summary>
    CaptureImageNumber_Interval_Int = 136,

    /// <summary>Timer reset function enable</summary>
    TimerResetEnable_Bool = 140,

    /// <summary>Enable switch for USB3.0 repeated recognition on the device.</summary>
    DeviceUsb3RepeatIdentify_Bool = 141,

    /// <summary>Reboot device delay mode. Delay time unit: ms, range: [0, 8000).</summary>
    DeviceRebootDelay_Int = 142,

    /// <summary>Query the status of laser over-current protection (read-only)</summary>
    LaserOverCurrentProtectionStatus_Bool = 148,

    /// <summary>Query the status of laser pulse width protection (read-only)</summary>
    LaserPulseWidthProtectionStatus_Bool = 149,

    /// <summary>Baseline calibration parameters</summary>
    BaselineCalibrationParam = 1002,

    /// <summary>Device temperature information</summary>
    DeviceTemperature = 1003,

    /// <summary>TOF exposure threshold range</summary>
    ToFExposureThresholdControl = 1024,

    /// <summary>get/set serial number</summary>
    DeviceSerialNumber = 1035,

    /// <summary>get/set device time</summary>
    DeviceTime = 1037,

    /// <summary>Multi-device synchronization Mode and parameter configuration</summary>
    MultiDeviceSyncConfig = 1038,

    /// <summary>RGB cropping ROI</summary>
    RgbCropRoI = 1040,

    /// <summary>Device IP address configuration</summary>
    DeviceIPAddrConfig = 1041,

    /// <summary>The current camera depth mode</summary>
    CurrentDepthAlgMode = 1043,

    /// <summary>A list of depth accuracy levels, returning an array of uin16_t, corresponding to the enumeration</summary>
    DepthPrecisionSupportList = 1045,

    /// <summary>Device network static IP config record (read-only)</summary>
    /// <remarks>Using for get last static IP config，witch is record in device flash when user set static IP config</remarks>
    DeviceStaticIPConfigRecord = 1053,

    /// <summary>Color camera auto exposure</summary>
    ColorAutoExposure_Bool = 2000,

    /// <summary>Color camera exposure adjustment</summary>
    ColorExposure_Int = 2001,

    /// <summary>Color camera gain adjustment</summary>
    ColorGain_Int = 2002,

    /// <summary>Color camera Automatic white balance</summary>
    ColorAutoWhiteBalance_Bool = 2003,

    /// <summary>Color camera white balance adjustment</summary>
    ColorWhiteBalance_Int = 2004,

    /// <summary>Color camera brightness adjustment</summary>
    ColorBrightness_Int = 2005,

    /// <summary>Color camera sharpness adjustment</summary>
    ColorSharpness_Int = 2006,

    /// <summary>Color camera shutter adjustment</summary>
    ColorShutter_Int = 2007,

    /// <summary>Color camera saturation adjustment</summary>
    ColorSaturation_Int = 2008,

    /// <summary>Color camera contrast adjustment</summary>
    ColorContrast_Int = 2009,

    /// <summary>Color camera gamma adjustment</summary>
    ColorGamma_Int = 2010,

    /// <summary>Color camera image rotation</summary>
    ColorRoll_Int = 2011,

    /// <summary>Color camera auto exposure priority</summary>
    ColorAutoExposurePriority_Int = 2012,

    /// <summary>Color camera brightness compensation</summary>
    ColorBacklightCompensation_Int = 2013,

    /// <summary>Color camera color tint</summary>
    ColorHue_Int = 2014,

    /// <summary>Color camera power line frequency</summary>
    ColorPowerLineFrequency_Int = 2015,

    /// <summary>Automatic exposure of depth camera (infrared camera will be set synchronously under some models of devices)</summary>
    DepthAutoExposure_Bool = 2016,

    /// <summary>Depth camera exposure adjustment (infrared cameras will be set synchronously under some models of devices)</summary>
    DepthExposure_Int = 2017,

    /// <summary>Depth camera gain adjustment (infrared cameras will be set synchronously under some models of devices)</summary>
    DepthGain_Int = 2018,

    /// <summary>Infrared camera auto exposure (depth camera will be set synchronously under some models of devices)</summary>
    IRAutoExposure_Bool = 2025,

    /// <summary>Infrared camera exposure adjustment (some models of devices will set the depth camera synchronously)</summary>
    IRExposure_Int = 2026,

    /// <summary>Infrared camera gain adjustment (the depth camera will be set synchronously under some models of devices)</summary>
    IRGain_Int = 2027,

    /// <summary>Select infrared camera data source channel. If not support throw exception. 0 : IR stream from IR left sensor; 1 : IR stream from IR right sensor;</summary>
    IRChannelDataSource_Int = 2028,

    /// <summary>Depth effect dedistortion, true: on, false: off. mutually exclusive with D2C function, RM_Filter disable when hardware or software D2C is enabled.</summary>
    Depth_RM_FILTER_Bool = 2029,

    /// <summary>Color camera maximal gain</summary>
    ColorMaximalGain_Int = 2030,

    /// <summary>Color camera shutter gain</summary>
    ColorMaximalShutter_Int = 2031,

    /// <summary>The enable/disable switch for IR short exposure function, supported only by a few Devices.</summary>
    IRShortExposure_Bool = 2032,

    /// <summary>Color camera HDR</summary>
    ColorHdr_Bool = 2034,

    /// <summary>Software disparity to depth</summary>
    SdkDisparityToDepth_Bool = 3004,

    /// <summary>Depth data unpacking function switch (each open stream will be turned on by default, support RLE/Y10/Y11/Y12/Y14 format)</summary>
    SdkDepthFrameUnpack_Bool = 3007,

    /// <summary>IR data unpacking function switch (each Current will be turned on by default, support RLE/Y10/Y11/Y12/Y14 format)</summary>
    SdkIRFrameUnpack_Bool = 3008,

    /// <summary>Accel data conversion function switch (on by default)</summary>
    SdkAccelFrameTransformed_Bool = 3009,

    /// <summary>Gyro data conversion function switch (on by default)</summary>
    SdkGyroFrameTransformed_Bool = 3010,

    /// <summary>Left IR frame data unpacking function switch (each current will be turned on by default, support RLE/Y10/Y11/Y12/Y14 format)</summary>
    SdkIRLeftFrameUnpack_Bool = 3011,

    /// <summary>Right IR frame data unpacking function switch (each current will be turned on by default, support RLE/Y10/Y11/Y12/Y14 format)</summary>
    SdkIRRightFrameUnpack_Bool = 3012,

    /// <summary>Calibration JSON file read from device (Femto Mega, read only)</summary>
    RawDataCameraCalib_JsonFile = 4029,
}
