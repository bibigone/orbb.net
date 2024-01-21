using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//     uint8_t checksum[16];
//     char name[32];
// } OBDepthWorkMode, ob_depth_work_mode;
/// <summary>Depth work mode</summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct DepthWorkMode
{
    /// <summary>Checksum of work mode</summary>
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] Checksum;

    /// <summary>Name of work mode</summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string Name;
}
