using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//    uint8_t major;
//    uint8_t minor;
//    uint8_t patch;
// } OBProtocolVersion, ob_protocol_version;
/// <summary>Control command protocol version number</summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct ProtocolVersion
{
    /// <summary>Major version number</summary>
    public readonly byte Major;

    /// <summary>Minor version number</summary>
    public readonly byte Minor;

    /// <summary>Patch version number</summary>
    public readonly byte Patch;
}
