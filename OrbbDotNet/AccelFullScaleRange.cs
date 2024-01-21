namespace OrbbDotNet;

// typedef enum {
//     OB_ACCEL_FS_2g = 1,
//     OB_ACCEL_FS_4g,
//     OB_ACCEL_FS_8g,
//     OB_ACCEL_FS_16g,
// } OBAccelFullScaleRange, ob_accel_full_scale_range, OB_ACCEL_FULL_SCALE_RANGE;
/// <summary>Enumeration of accelerometer ranges</summary>
public enum AccelFullScaleRange : int
{
    /// <summary>1x the acceleration of gravity</summary>
    _2g = 1,

    /// <summary>4x the acceleration of gravity</summary>
    _4g,

    /// <summary>8x the acceleration of gravity</summary>
    _8g,

    /// <summary>16x the acceleration of gravity</summary>
    _16g,
}
