using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//     float k1;  ///< Radial distortion factor 1
//     float k2;  ///< Radial distortion factor 2
//     float k3;  ///< Radial distortion factor 3
//     float k4;  ///< Radial distortion factor 4
//     float k5;  ///< Radial distortion factor 5
//     float k6;  ///< Radial distortion factor 6
//     float p1;  ///< Tangential distortion factor 1
//     float p2;  ///< Tangential distortion factor 2
// } OBCameraDistortion, ob_camera_distortion;
/// <summary>Structure for distortion parameters</summary>
[StructLayout(LayoutKind.Sequential)]
public struct CameraDistortion
{
    /// <summary>Radial distortion factor 1</summary>
    public float K1;

    /// <summary>Radial distortion factor 2</summary>
    public float K2;

    /// <summary>Radial distortion factor 3</summary>
    public float K3;

    /// <summary>Radial distortion factor 4</summary>
    public float K4;

    /// <summary>Radial distortion factor 5</summary>
    public float K5;

    /// <summary>Radial distortion factor 6</summary>
    public float K6;

    /// <summary>Tangential distortion factor 1</summary>
    public float P1;

    /// <summary>Tangential distortion factor 2</summary>
    public float P2;
}