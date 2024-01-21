using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OrbbDotNet;

/// <summary>Static class with common basic things like logging, initializing, loading of license, etc.</summary>
/// <remarks>
/// The most of methods and properties from this static class corresponds to static member functions in <c>Context</c> C++ class
/// from Native SDK.
/// </remarks>
public static class Sdk
{
    #region Dependencies

    /// <summary>Name of main library (DLL/so) from Native SDK.</summary>
    /// <remarks>Extension is not specified to be cross-platform.</remarks>
    public const string SDK_DLL_NAME = "OrbbecSDK";

    #endregion

    #region Version

    /// <summary>Native SDK version.</summary>
    public static Version Version
    {
        get
        {
            var major = Native.VersionApi.GetMajorVersion();
            var minor = Native.VersionApi.GetMinorVersion();
            var patch = Native.VersionApi.GetPatchVersion();
            return new Version(major, minor, patch);
        }
    }

    /// <summary>Native SDK stage version.</summary>
    public static string? VersionStage
    {
        get
        {
            var stagePtr = Native.VersionApi.GetStageVersion();
            return Marshal.PtrToStringAnsi(stagePtr);
        }
    }

    #endregion

    #region Logging

    /// <summary>
    /// The Orbb.Net can log data to a regular .Net Trace.
    /// Use this property to choose the level of such logging, or set it to <see cref="TraceLevel.Off"/> to turn it off.
    /// Default value is <see cref="TraceLevel.Off"/>.
    /// </summary>
    public static TraceLevel TraceLevel
    {
        get => LogImpl.TraceLevel;
        set => LogImpl.TraceLevel = value;
    }

    /// <summary>The Orrb.Net can log data to the console and/or files.</summary>
    /// <param name="level">Level of logging.</param>
    /// <param name="logToConsole">Log messages to Console?</param>
    /// <param name="logToDirectory">
    /// Log messages to the directory specified.
    /// Use <see langword="null"/> or empty string to completely disable logging to a file.
    /// </param>
    public static void ConfigureLogging(TraceLevel level, bool logToConsole = false, string? logToDirectory = null)
        => LogImpl.ConfigureLogging(level, logToConsole, logToDirectory);

    #endregion

    #region License

    /// <summary>Loads a Native SDK license from a file on disk</summary>
    /// <param name="filePath">Path to the license file</param>
    /// <param name="key">Decryption key. "OB_DEFAULT_DECRYPT_KEY" can be used to represent the default key.</param>
    public static void LoadLicense(string filePath, string key)
    {
        Native.ContextApi.LoadLicense(filePath, key, out var error);
        ObException.CheckError(ref error);
    }

    /// <summary>Loads a Native SDK license from a binary data in memory</summary>
    /// <param name="data">License data in binary format</param>
    /// <param name="key">Decryption key. "OB_DEFAULT_DECRYPT_KEY" can be used to represent the default key.</param>
    public static unsafe void LoadLicenseFromData(byte[] data, string key)
    {
        fixed (byte* dataPtr = data)
        {
            var keyPtr = Marshal.StringToHGlobalAnsi(key);
            try
            {
                Native.ContextApi.LoadLicenseFromData(new IntPtr(dataPtr), (uint)data.Length, keyPtr, out var error);
                ObException.CheckError(ref error);
            }
            finally
            {
                Marshal.FreeHGlobal(keyPtr);
            }
        }
    }

    #endregion
}
