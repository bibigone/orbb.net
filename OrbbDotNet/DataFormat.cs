namespace OrbbDotNet;

// typedef enum {
//     OB_FORMAT_YUYV = 0,
//     OB_FORMAT_YUY2 = 1,
//     OB_FORMAT_UYVY = 2,
//     OB_FORMAT_NV12 = 3,
//     OB_FORMAT_NV21 = 4,
//     OB_FORMAT_MJPG = 5,
//     OB_FORMAT_H264 = 6,
//     OB_FORMAT_H265 = 7,
//     OB_FORMAT_Y16 = 8,
//     OB_FORMAT_Y8 = 9,
//     OB_FORMAT_Y10 = 10,
//     OB_FORMAT_Y11 = 11,
//     OB_FORMAT_Y12 = 12,
//     OB_FORMAT_GRAY = 13,
//     OB_FORMAT_HEVC = 14,
//     OB_FORMAT_I420 = 15,
//     OB_FORMAT_ACCEL = 16,
//     OB_FORMAT_GYRO = 17,
//     OB_FORMAT_POINT = 19,
//     OB_FORMAT_RGB_POINT = 20,
//     OB_FORMAT_RLE = 21,
//     OB_FORMAT_RGB = 22,
//     OB_FORMAT_BGR = 23,
//     OB_FORMAT_Y14 = 24,
//     OB_FORMAT_BGRA = 25,
//     OB_FORMAT_COMPRESSED = 26,
//     OB_FORMAT_RVL = 27,
//     OB_FORMAT_UNKNOWN = 0xff,
// } OBFormat, ob_format;
/// <summary>Enumeration value describing the pixel format and other data formats read from a stream.</summary>
public enum DataFormat : int
{
    /// <summary>YUYV format</summary>
    Yuyv = 0,

    /// <summary>YUY2 format (the actual format is the same as YUYV)</summary>
    Yuy2 = 1,

    /// <summary>UYVY format</summary>
    Uyvy = 2,

    /// <summary>NV12 format</summary>
    Nv12 = 3,

    /// <summary>NV21 format</summary>
    Nv21 = 4,

    /// <summary>MJPEG encoding format</summary>
    Mjpeg = 5,

    /// <summary>H.264 encoding format</summary>
    H264 = 6,

    /// <summary>H.265 encoding format</summary>
    H265 = 7,

    /// <summary>Y16 format, single channel 16-bit depth</summary>
    Y16 = 8,

    /// <summary>Y8 format, single channel 8-bit depth</summary>
    Y8 = 9,

    /// <summary>Y10 format, single channel 10-bit depth (SDK will unpack into Y16 by default)</summary>
    Y10 = 10,

    /// <summary>Y11 format, single channel 11-bit depth (SDK will unpack into Y16 by default)</summary>
    Y11 = 11,

    /// <summary>Y12 format, single channel 12-bit depth (SDK will unpack into Y16 by default)</summary>
    Y12 = 12,

    /// <summary>GRAY (the actual format is the same as YUYV)</summary>
    Gray = 13,

    /// <summary>HEVC encoding format (the actual format is the same as H265)</summary>
    Hevc = 14,

    /// <summary>I420 format</summary>
    I420 = 15,

    /// <summary>Acceleration data format</summary>
    Accel = 16,

    /// <summary>Gyroscope data format</summary>
    Gyro = 17,

    /// <summary>XYZ 3D coordinate point format</summary>
    Point = 19,

    /// <summary>XYZ 3D coordinate point format with RGB information</summary>
    RgbPoint = 20,

    /// <summary>LE pressure test format (SDK will be unpacked into Y16 by default)</summary>
    Rle = 21,

    /// <summary>RGB format (actual RGB888)</summary>
    Rgb = 22,

    /// <summary>BGR format (actual BGR888)</summary>
    Bgr = 23,

    /// <summary>Y14 format, single channel 14-bit depth (SDK will unpack into Y16 by default)</summary>
    Y14 = 24,

    /// <summary>BGRA format</summary>
    Bgra = 25,

    /// <summary>Compression format</summary>
    Compressed = 26,

    /// <summary>RVL pressure test format (SDK will be unpacked into Y16 by default)</summary>
    Rvl = 27,

    /// <summary>Unknown format</summary>
    Unknown = 0xFF,
}
