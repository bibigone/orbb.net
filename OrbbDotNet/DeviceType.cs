namespace OrbbDotNet;

// typedef enum {
//     OB_STRUCTURED_LIGHT_MONOCULAR_CAMERA = 0,
//     OB_STRUCTURED_LIGHT_BINOCULAR_CAMERA = 1,
//     OB_TOF_CAMERA = 2,
// } OBDeviceType, ob_device_type, OB_DEVICE_TYPE;
/// <summary>Enumeration for device types</summary>
public enum DeviceType : int
{
    /// <summary>Monocular structured light camera</summary>
    MonocularCamera = 0,

    /// <summary>Binocular structured light camera</summary>
    BinocularCamera = 1,

    /// <summary>Time-of-Flight camera</summary>
    ToFCamera = 2,
}
