namespace OrbbDotNet;

// typedef enum {
//     OB_GYRO_FS_16dps = 1,
//     OB_GYRO_FS_31dps,
//     OB_GYRO_FS_62dps,
//     OB_GYRO_FS_125dps,
//     OB_GYRO_FS_250dps,
//     OB_GYRO_FS_500dps,
//     OB_GYRO_FS_1000dps,
//     OB_GYRO_FS_2000dps,
// } OBGyroFullScaleRange, ob_gyro_full_scale_range, OB_GYRO_FULL_SCALE_RANGE;
/// <summary>Enumeration of gyroscope ranges</summary>
public enum GyroFullScaleRange : int
{
    /// <summary>16 degrees per second</summary>
    _16dps = 1,

    /// <summary>31 degrees per second</summary>
    _31dps,

    /// <summary>62 degrees per second</summary>
    _62dps,

    /// <summary>125 degrees per second</summary>
    _125dps,

    /// <summary>250 degrees per second</summary>
    _250dps,

    /// <summary>500 degrees per second</summary>
    _500dps,

    /// <summary>1000 degrees per second</summary>
    _1000dps,

    /// <summary>2000 degrees per second</summary>
    _2000dps,
}