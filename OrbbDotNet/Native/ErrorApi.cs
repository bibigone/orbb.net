using System;
using System.Runtime.InteropServices;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet.Native;

/// <summary>DLL imports from <c>Error.h</c> header file.</summary>
internal static class ErrorApi
{
    // ob_status ob_error_status(ob_error* error);
    /// <summary>Get the error status.</summary>
    /// <param name="error">The error object.</param>
    /// <returns>The error status.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_error_status", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObStatus GetStatus(ObErrorPtr error);

    // const char* ob_error_message(ob_error * error);
    /// <summary>Get the error message.</summary>
    /// <param name="error">The error object.</param>
    /// <returns>The error message.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_error_message", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr GetErrorMessage(ObErrorPtr error);

    // const char* ob_error_function(ob_error * error);
    /// <summary>Get the name of the API function that caused the error.</summary>
    /// <param name="error">The error object.</param>
    /// <returns>The name of the API function.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_error_function", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr GetErrorFunction(ObErrorPtr error);

    // const char* ob_error_args(ob_error * error);
    /// <summary>Get the error parameters.</summary>
    /// <param name="error">The error object.</param>
    /// <returns>The error parameters.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_error_args", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr GetErrorArgs(ObErrorPtr error);

    // ob_exception_type ob_error_exception_type(ob_error* error);
    /// <summary>Get the type of exception that caused the error.</summary>
    /// <param name="error">The error object.</param>
    /// <returns>The type of exception.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_error_exception_type", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern ObExceptionType GetErrorExceptionType(ObErrorPtr error);

    // void ob_delete_error(ob_error* error);
    /// <summary>Delete the error object.</summary>
    /// <param name="error">The error object.</param>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_delete_error", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DeleteError(ObErrorPtr error);
}