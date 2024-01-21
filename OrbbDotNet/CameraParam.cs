using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef struct {
//     OBCameraIntrinsic depthIntrinsic;
//     OBCameraIntrinsic rgbIntrinsic;
//     OBCameraDistortion depthDistortion;
//     OBCameraDistortion rgbDistortion;
//     OBD2CTransform transform;
//     bool isMirrored;
// } OBCameraParam, ob_camera_param;
/// <summary>Structure for camera parameters</summary>
[StructLayout(LayoutKind.Sequential)]
public struct CameraParam
{
    /// <summary>Depth camera internal parameters</summary>
    public CameraIntrinsic DepthIntrinsic;   ///< Depth camera internal parameters

    /// <summary>Color camera internal parameters</summary>
    public CameraIntrinsic RgbIntrinsic;

    /// <summary>Depth camera distortion parameters</summary>
    public CameraDistortion DepthDistortion;

    /// <summary>Color camera distortion parameters</summary>
    public CameraDistortion RgbDistortion;

    /// <summary>Rotation/transformation matrix</summary>
    public DepthToColorTransform Transform;

    private Native.NativeBool isMirrored;

    /// <summary>Whether the image frame corresponding to this group of parameters is mirrored</summary>
    public bool IsMirrored
    {
        get => isMirrored;
        set => isMirrored = value;
    }
}
