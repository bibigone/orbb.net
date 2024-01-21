using System.Runtime.InteropServices;
using System;

namespace OrbbDotNet.Native;

/// <summary>Types from <c>ObTypes.h</c> header file.</summary>
internal static class ObTypes
{
    #region Type-safe pointers to native objects

    // ob_error*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObErrorPtr : IDisposable
    {
        private readonly IntPtr value;
        public bool IsZero => value == IntPtr.Zero;
        public void Dispose()
        {
            if (!IsZero)
                ErrorApi.DeleteError(this);
        }
    }

    // ob_context*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObContextPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            ContextApi.DeleteContext(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_device_list*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObDeviceListPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            DeviceApi.DeleteDeviceList(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_device_info*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObDeviceInfoPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            DeviceApi.DeleteDeviceInfo(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_device*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObDevicePtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            DeviceApi.DeleteDevice(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_sensor_list*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObSensorListPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            SensorApi.DeleteSensorList(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_sensor*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObSensorPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            SensorApi.DeleteSensor(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_stream_profile_list*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObStreamProfileListPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            StreamProfileApi.DeleteStreamProfileList(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_stream_profile*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObStreamProfilePtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            StreamProfileApi.DeleteStreamProfile(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_frame*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObFramePtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            FrameApi.DeleteFrame(this, out var error);
            using (error) return error.IsZero;
        }
        public void AddRef()
        {
            FrameApi.Frame.AddRef(this, out var error);
            ObException.CheckError(ref error);
        }
    }

    // ob_camera_param_list*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObCameraParamListPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            DeviceApi.DeleteCameraParamList(this, out var error);
            using (error) return error.IsZero;
        }
    }

    // ob_depth_work_mode_list*
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObDepthWorkModeListPtr : INativePtr
    {
        private readonly IntPtr value;
        public IntPtr UnsafeValue => value;
        public bool Release()
        {
            DeviceApi.DeleteDepthWorkModeList(this, out var error);
            using (error) return error.IsZero;
        }
    }

    #endregion

    #region Enumerations

    // typedef enum {
    //     OB_EXCEPTION_TYPE_UNKNOWN,
    //     OB_EXCEPTION_TYPE_CAMERA_DISCONNECTED,
    //     OB_EXCEPTION_TYPE_PLATFORM,
    //     OB_EXCEPTION_TYPE_INVALID_VALUE,
    //     OB_EXCEPTION_TYPE_WRONG_API_CALL_SEQUENCE,
    //     OB_EXCEPTION_TYPE_NOT_IMPLEMENTED,
    //     OB_EXCEPTION_TYPE_IO,
    //     OB_EXCEPTION_TYPE_MEMORY,
    //     OB_EXCEPTION_TYPE_UNSUPPORTED_OPERATION,
    // } OBExceptionType, ob_exception_type;
    /// <summary>The exception types in the SDK, through the exception type, you can easily determine the specific type of error.</summary>
    public enum ObExceptionType : int
    {
        /// <summary>Unknown error, an error not clearly defined by the SDK</summary>
        Unknown,

        /// <summary>SDK device disconnection exception</summary>
        CameraDisconnected,

        /// <summary>An error in the SDK adaptation platform layer means an error in the implementation of a specific system platform</summary>
        Platform,

        /// <summary>Invalid parameter type exception, need to check input parameter</summary>
        InvalidValue,

        /// <summary>Exception caused by API version mismatch</summary>
        WrongApiCallSequence,

        /// <summary>SDK and firmware have not yet implemented functions</summary>
        NotImplemented,

        /// <summary>SDK access IO exception error</summary>
        IO,

        /// <summary>SDK access and use memory errors, which means that the frame fails to allocate memory</summary>
        Memory,

        /// <summary>Unsupported operation type error by SDK or RGBD device</summary>
        UnsupportedOperation,
    }

    // typedef enum {
    //     OB_LOG_SEVERITY_DEBUG,
    //     OB_LOG_SEVERITY_INFO,
    //     OB_LOG_SEVERITY_WARN,
    //     OB_LOG_SEVERITY_ERROR,
    //     OB_LOG_SEVERITY_FATAL,
    //     OB_LOG_SEVERITY_OFF
    // } OBLogSeverity, ob_log_severity, DEVICE_LOG_SEVERITY_LEVEL, OBDeviceLogSeverityLevel, ob_device_log_severity_level;
    /// <summary>log level, the higher the level, the stronger the log filter</summary>
    public enum ObLogSeverity : int
    {
        /// <summary>debug</summary>
        Debug,

        /// <summary>information</summary>
        Info,

        /// <summary>warning</summary>
        Warn,

        /// <summary>error</summary>
        Error,

        /// <summary>fatal error</summary>
        Fatal,

        /// <summary>off (close LOG)</summary>
        Off,
    }

    // typedef enum {
    //     OB_STATUS_OK    = 0,
    //     OB_STATUS_ERROR = 1,
    // } OBStatus, ob_status;
    /// <summary>Error code.</summary>
    public enum ObStatus : int
    {
        /// <summary>status ok</summary>
        Ok = 0,

        /// <summary>status error</summary>
        Error = 1,
    }

    #endregion

    #region Delegates for callbacks from native SDK

    // typedef void (*ob_device_changed_callback)(ob_device_list *removed, ob_device_list *added, void *user_data);
    /// <summary>Callback for device change</summary>
    /// <param name="removed">List of deleted (dropped) devices</param>
    /// <param name="added">List of added (online) devices</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObDeviceChangedCallback(ObDeviceListPtr removed, ObDeviceListPtr added, IntPtr userData);

    // typedef void (ob_log_callback) (ob_log_severity severity, const char* message, void* user_data);
    /// <summary>Callback for receiving log</summary>
    /// <param name="severity">Current log level</param>
    /// <param name="message">Log message</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObLogCallback(ObLogSeverity severity, [MarshalAs(UnmanagedType.LPStr)] string message, IntPtr userData);

    // typedef void (* ob_frame_callback) (ob_frame* frame, void* user_data);
    /// <summary>Callback for frame</summary>
    /// <param name="frame">Frame object</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObFrameCallback(ObFramePtr frame, IntPtr userData);

    // typedef void (ob_frame_destroy_callback) (void* buffer, void* user_data);
    /// <summary>Customize the delete callback</summary>
    /// <param name="buffer">Data that needs to be deleted</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObFrameDestroyCallback(IntPtr buffer, IntPtr userData);

    // typedef void (* ob_set_data_callback) (ob_data_tran_state state, uint8_t percent, void* user_data);
    /// <summary>Callback for writing data</summary>
    /// <param name="state">Write data status</param>
    /// <param name="percent">Write data percent</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObSetDataCallback(DataTransferState state, byte percent, IntPtr userData);

    // typedef void (* ob_get_data_callback) (ob_data_tran_state state, ob_data_chunk* dataChunk, void* user_data);
    /// <summary>Callback for reading data</summary>
    /// <param name="state">Read data status</param>
    /// <param name="dataChunk">Read the returned data block</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObGetDataCallback(DataTransferState state, DataChunk dataChunk, IntPtr userData);

    // typedef void (* ob_device_state_callback) (ob_device_state state, const char* message, void* user_data);
    /// <summary>Callback for device status</summary>
    /// <param name="state">Device status</param>
    /// <param name="message">Device status information</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObDeviceStateCallback(DeviceState state, IntPtr message, IntPtr userData);

    // typedef void (* ob_file_send_callback) (ob_file_tran_state state, const char* message, uint8_t percent, void* user_data);
    /// <summary>Callback for file transfer</summary>
    /// <param name="state">Transmission status</param>
    /// <param name="message">Transfer status information</param>
    /// <param name="percent">Transfer progress percentage</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObFileSendCallback(FileTransferState state, IntPtr message, byte percent, IntPtr userData);

    // typedef void (* ob_device_upgrade_callback) (ob_upgrade_state state, const char* message, uint8_t percent, void* user_data);
    /// <summary>Callback for firmware upgrade</summary>
    /// <param name="state">Upgrade status</param>
    /// <param name="message">Upgrade status information</param>
    /// <param name="percent">Upgrade progress percentage</param>
    /// <param name="userData">User-defined data</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ObDeviceUpgradeCallback(UpgradeState state, IntPtr message, byte percent, IntPtr userData);

    #endregion

    #region Structures

    // typedef struct OBPropertyItem {
    //     OBPropertyID id;
    //     const char* name;
    //     OBPropertyType type;
    //     OBPermissionType permission;
    // } OBPropertyItem, ob_property_item;
    /// <summary>Used to describe the characteristics of each property</summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObPropertyItem
    {
        /// <summary>Property ID</summary>
        public readonly PropertyId Id;

        private readonly IntPtr namePtr;

        /// <summary>Property name</summary>
        public string? Name => Marshal.PtrToStringAnsi(namePtr);

        /// <summary>Property type</summary>
        public readonly PropertyType Type;

        /// <summary>Property read and write permission</summary>
        public readonly PermissionType Permission;
    }

    // typedef struct {
    //     int32_t cur;
    //     int32_t max;
    //     int32_t min;
    //     int32_t step;
    //     int32_t def;
    // } OBIntPropertyRange, ob_int_property_range;
    /// <summary>Structure for integer range</summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObIntPropertyRange
    {
        /// <summary>Current value</summary>
        public readonly int Cur;

        /// <summary>Maximum value</summary>
        public readonly int Max;

        /// <summary>Minimum value</summary>
        public readonly int Min;

        /// <summary>Step value</summary>
        public readonly int Step;

        /// <summary>Default value</summary>
        public readonly int Def;
    }

    // typedef struct {
    //     float cur;
    //     float max;
    //     float min;
    //     float step;
    //     float def;
    // } OBFloatPropertyRange, ob_float_property_range;
    /// <summary>Structure for float range</summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObFloatPropertyRange
    {
        /// <summary>Current value</summary>
        public readonly float Cur;

        /// <summary>Maximum value</summary>
        public readonly float Max;

        /// <summary>Minimum value</summary>
        public readonly float Min;

        /// <summary>Step value</summary>
        public readonly float Step;

        /// <summary>Default value</summary>
        public readonly float Def;
    }

    // typedef struct {
    //     float cur;
    //     float max;
    //     float min;
    //     float step;
    //     float def;
    // } OBBoolPropertyRange, ob_bool_property_range;
    /// <summary>Structure for boolean range</summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ObBoolPropertyRange
    {
        /// <summary>Current value</summary>
        public readonly NativeBool Cur;

        /// <summary>Maximum value</summary>
        public readonly NativeBool Max;

        /// <summary>Minimum value</summary>
        public readonly NativeBool Min;

        /// <summary>Step value</summary>
        public readonly NativeBool Step;

        /// <summary>Default value</summary>
        public readonly NativeBool Def;
    }

    #endregion
}
