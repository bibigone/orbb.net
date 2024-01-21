namespace OrbbDotNet;

// typedef enum {
//     OB_FRAME_UNKNOWN = -1,
//     OB_FRAME_VIDEO = 0,
//     OB_FRAME_IR = 1,
//     OB_FRAME_COLOR = 2,
//     OB_FRAME_DEPTH = 3,
//     OB_FRAME_ACCEL = 4,
//     OB_FRAME_SET = 5,
//     OB_FRAME_POINTS = 6,
//     OB_FRAME_GYRO = 7,
//     OB_FRAME_IR_LEFT = 8,
//     OB_FRAME_IR_RIGHT = 9,
//     OB_FRAME_RAW_PHASE = 10,
// } OBFrameType, ob_frame_type;
/// <summary>Enumeration value describing the type of frame</summary>
public enum FrameType : int
{
    /// <summary>Unknown frame type</summary>
    Unknown = -1,

    /// <summary>Video frame</summary>
    Video = 0,

    /// <summary>IR frame</summary>
    IR = 1,

    /// <summary>Color frame</summary>
    Color = 2,

    /// <summary>Depth frame</summary>
    Depth = 3,

    /// <summary>Accelerometer data frame</summary>
    Accel = 4,

    /// <summary>Frame collection (internally contains a variety of data frames)</summary>
    Set = 5,

    /// <summary>Point cloud frame</summary>
    Points = 6,

    /// <summary>Gyroscope data frame</summary>
    Gyro = 7,

    /// <summary>Left IR frame</summary>
    IRLeft = 8,

    /// <summary>Right IR frame</summary>
    IRRight = 9,

    /// <summary>Rawphase frame</summary>
    RawPhase = 10,
}
