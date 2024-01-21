namespace OrbbDotNet;

// typedef enum {
//     OB_SENSOR_UNKNOWN = 0,
//     OB_SENSOR_IR = 1,
//     OB_SENSOR_COLOR = 2,
//     OB_SENSOR_DEPTH = 3,
//     OB_SENSOR_ACCEL = 4,
//     OB_SENSOR_GYRO = 5,
//     OB_SENSOR_IR_LEFT = 6,
//     OB_SENSOR_IR_RIGHT = 7,
//     OB_SENSOR_RAW_PHASE = 8,
// } OBSensorType, ob_sensor_type;
/// <summary>Enumeration value describing the sensor type</summary>
public enum SensorType : int
{
    /// <summary>Unknown type of sensor.</summary>
    Unknown = 0,

    /// <summary>InfraRed emitter</summary>
    IR = 1,

    /// <summary>Color camera</summary>
    Color = 2,

    /// <summary>Depth camera</summary>
    Depth = 3,

    /// <summary>Accelerometer</summary>
    Accel = 4,

    /// <summary>Gyro sensor</summary>
    Gyro = 5,

    /// <summary>Left InfraRed emitter</summary>
    IRLeft = 6,

    /// <summary>Right InfraRed emmiter</summary>
    IRRight = 7,

    /// <summary>Raw Phase</summary>
    RawPhase = 8,
}
