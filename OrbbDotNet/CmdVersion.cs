namespace OrbbDotNet;

// typedef enum {
//     OB_CMD_VERSION_V0 = (uint16_t)0,
//     OB_CMD_VERSION_V1 = (uint16_t)1,
//     OB_CMD_VERSION_V2 = (uint16_t)2,
//     OB_CMD_VERSION_V3 = (uint16_t)3,
//     OB_CMD_VERSION_NOVERSION = (uint16_t)0xfffe,
//     OB_CMD_VERSION_INVALID = (uint16_t)0xffff,
// } OB_CMD_VERSION, OBCmdVersion, ob_cmd_version;
/// <summary>Command version associated with property id</summary>
public enum CmdVersion : ushort
{
    /// <summary>Version 1.0</summary>
    V0 = 0,

    /// <summary>Version 2.0</summary>
    V1 = 1,

    /// <summary>Version 3.0</summary>
    V2 = 2,

    /// <summary>Version 4.0</summary>
    V3 = 3,

    /// <summary></summary>
    NoVersion = 0xFFFE,

    /// <summary>Invalid version</summary>
    Invalid = 0xFFFF,
}
