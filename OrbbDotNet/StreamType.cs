namespace OrbbDotNet;

// typedef enum {
//     OB_STREAM_UNKNOWN = -1,
//     OB_STREAM_VIDEO = 0,
//     OB_STREAM_IR = 1,
//     OB_STREAM_COLOR = 2,
//     OB_STREAM_DEPTH = 3,
//     OB_STREAM_ACCEL = 4,
//     OB_STREAM_GYRO = 5,
//     OB_STREAM_IR_LEFT = 6,
//     OB_STREAM_IR_RIGHT = 7,
//     OB_STREAM_RAW_PHASE = 8,
// } OBStreamType, ob_stream_type;
/// <summary>Enumeration value describing the type of data stream</summary>
public enum StreamType : int
{
    /// <summary>Unknown type stream</summary>
    Unknown = -1,

    /// <summary>Video stream (infrared, color, depth streams are all video streams)</summary>
    Video = 0,

    /// <summary>IR stream</summary>
    IR = 1,

    /// <summary>color stream</summary>
    Color = 2,

    /// <summary>depth stream</summary>
    Depth = 3,

    /// <summary>Accelerometer data stream</summary>
    Accel = 4,

    /// <summary>Gyroscope data stream</summary>
    Gyro = 5,

    /// <summary>Left IR stream</summary>
    IRLeft = 6,

    /// <summary>Right IR stream</summary>
    IRRight = 7,

    /// <summary>RawPhase Stream</summary>
    RawPhase = 8,
}
