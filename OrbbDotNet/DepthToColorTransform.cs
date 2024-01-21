using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//     float rot[9];    ///< Rotation matrix
//     float trans[3];  ///< Transformation matrix
// } OBD2CTransform, ob_d2c_transform;
/// <summary>Structure for rotation/transformation</summary>
[StructLayout(LayoutKind.Sequential)]
public struct DepthToColorTransform
{
    /// <summary>3x3 rotation matrix.</summary>
    public Float3x3 Rotation;

    /// <summary>Translation vector.</summary>
    public Float3 Translation;
}