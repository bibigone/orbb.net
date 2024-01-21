using System;
using System.Runtime.InteropServices;

namespace OrbbDotNet.Native;

/// <summary>DLL imports from <c>Version.h</c> header file.</summary>
internal static class VersionApi
{
    // int ob_get_version();
    /// <summary>Get the SDK version number</summary>
    /// <returns>The SDK version number.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_get_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetVersion();

    // int ob_get_major_version();
    /// <summary>Get the SDK major version number</summary>
    /// <returns>The SDK major version number.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_get_major_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetMajorVersion();

    // int ob_get_minor_version();
    /// <summary>Get the SDK minor version number</summary>
    /// <returns>The SDK minor version number.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_get_minor_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetMinorVersion();

    // int ob_get_patch_version();
    /// <summary>Get the SDK patch version number</summary>
    /// <returns>The SDK patch version number.</returns>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_get_patch_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern int GetPatchVersion();

    // const char* ob_get_stage_version();
    /// <summary>Get the SDK stage version</summary>
    /// <returns>The SDK stage version.</returns>
    /// <remarks>The returned pointer does not need to be freed.</remarks>
    [DllImport(Sdk.SDK_DLL_NAME, EntryPoint = "ob_get_stage_version", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern IntPtr GetStageVersion();
}