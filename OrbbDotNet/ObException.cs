using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>Base class for all Orbbec SDK related exceptions.</summary>
[Serializable]
public partial class ObException : Exception
{
    internal static void CheckError(ref ObErrorPtr error, bool deleteError = true)
    {
        if (error.IsZero)
            return;

        try
        {
            var status = Native.ErrorApi.GetStatus(error);
            if (status == ObStatus.Ok)
                return;

            var excType = Native.ErrorApi.GetErrorExceptionType(error);
            var message = Marshal.PtrToStringAnsi(Native.ErrorApi.GetErrorMessage(error));
            var funcName = Marshal.PtrToStringAnsi(Native.ErrorApi.GetErrorFunction(error));
            var funcParams = Marshal.PtrToStringAnsi(Native.ErrorApi.GetErrorArgs(error));

            throw excType switch
            {
                ObExceptionType.CameraDisconnected => new CameraDisconnected(message, funcName, funcParams),
                ObExceptionType.Platform => new Platform(message, funcName, funcParams),
                ObExceptionType.InvalidValue => new InvalidParameter(message, funcName, funcParams),
                ObExceptionType.WrongApiCallSequence => new VersionMismatch(message, funcName, funcParams),
                ObExceptionType.NotImplemented => new NotImplemented(message, funcName, funcParams),
                ObExceptionType.IO => new IO(message, funcName, funcParams),
                ObExceptionType.Memory => new Memory(message, funcName, funcParams),
                ObExceptionType.UnsupportedOperation => new UnsupportedOperation(message, funcName, funcParams),
                _ => new ObException(message, funcName, funcParams),
            };
        }
        finally
        {
            if (deleteError)
            {
                error.Dispose();
                error = default;
            }
        }
    }

    /// <summary>The name of the API function that caused the error.</summary>
    public string? FunctionName { get; }

    /// <summary>The error parameters.</summary>
    public string? FunctionParameters { get; }

    /// <summary>Creates exception instance with parameters specified.</summary>
    /// <param name="message">The error message.</param>
    /// <param name="functionName">The name of the API function that caused the error.</param>
    /// <param name="functionParameters">The error parameters.</param>
    public ObException(string? message, string? functionName, string? functionParameters)
        : base(message)
    {
        FunctionName = functionName;
        FunctionParameters = functionParameters;
    }

    /// <summary>Constructor for deserialization needs.</summary>
    /// <param name="info">Serialization info.</param>
    /// <param name="context">Streaming context.</param>
    protected ObException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
        FunctionName = info.GetString(nameof(FunctionName));
        FunctionParameters = info.GetString(nameof(FunctionParameters));
    }

    /// <summary>For serialization needs.</summary>
    /// <param name="info">Serialization info.</param>
    /// <param name="context">Streaming context.</param>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
        info.AddValue(nameof(FunctionName), FunctionName);
        info.AddValue(nameof(FunctionParameters), FunctionParameters);
    }
}
