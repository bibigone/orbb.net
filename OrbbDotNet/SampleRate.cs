namespace OrbbDotNet;

// typedef enum {
//     OB_SAMPLE_RATE_1_5625_HZ = 1,
//     OB_SAMPLE_RATE_3_125_HZ,
//     OB_SAMPLE_RATE_6_25_HZ,
//     OB_SAMPLE_RATE_12_5_HZ,
//     OB_SAMPLE_RATE_25_HZ,
//     OB_SAMPLE_RATE_50_HZ,
//     OB_SAMPLE_RATE_100_HZ,
//     OB_SAMPLE_RATE_200_HZ,
//     OB_SAMPLE_RATE_500_HZ,
//     OB_SAMPLE_RATE_1_KHZ,
//     OB_SAMPLE_RATE_2_KHZ,
//     OB_SAMPLE_RATE_4_KHZ,
//     OB_SAMPLE_RATE_8_KHZ,
//     OB_SAMPLE_RATE_16_KHZ,
//     OB_SAMPLE_RATE_32_KHZ,
// } OBGyroSampleRate, ob_gyro_sample_rate, OBAccelSampleRate, ob_accel_sample_rate, OB_SAMPLE_RATE;
/// <summary>Enumeration of IMU sample rate values (gyroscope or accelerometer)</summary>
public enum SampleRate : int
{
    /// <summary>1.5625Hz</summary>
    _1_5625Hz = 1,

    /// <summary>3.125Hz</summary>
    _3_125Hz,

    /// <summary>6.25Hz</summary>
    _6_25Hz,

    /// <summary>12.5Hz</summary>
    _12_5Hz,

    /// <summary>25Hz</summary>
    _25Hz,

    /// <summary>50Hz</summary>
    _50Hz,

    /// <summary>100Hz</summary>
    _100Hz,

    /// <summary>200Hz</summary>
    _200Hz,

    /// <summary>500Hz</summary>
    _500Hz,

    /// <summary>1KHz</summary>
    _1kHz,

    /// <summary>2KHz</summary>
    _2kHz,

    /// <summary>4KHz</summary>
    _4kHz,

    /// <summary>8KHz</summary>
    _8kHz,

    /// <summary>16KHz</summary>
    _16kHz,

    /// <summary>32Hz</summary>
    _32kHz,
}
