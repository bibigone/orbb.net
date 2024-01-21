using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//     float   fx;
//     float   fy;
//     float   cx;
//     float   cy;
//     int16_t width;
//     int16_t height;
// } OBCameraIntrinsic, ob_camera_intrinsic;
/// <summary>Structure for camera internal parameters</summary>
[StructLayout(LayoutKind.Sequential)]
public struct CameraIntrinsic
{
    /// <summary>Focal length in x direction</summary>
    public float Fx;

    /// <summary>Focal length in y direction</summary>
    public float Fy;

    /// <summary>Optical center abscissa</summary>
    public float Cx;

    /// <summary>Optical center ordinate</summary>
    public float Cy;

    /// <summary>Image width</summary>
    public short Width;

    /// <summary>Image height</summary>
    public short Height;
}