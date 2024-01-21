using System;
using System.Diagnostics;
using static OrbbDotNet.Native.ObTypes;

namespace OrbbDotNet;

/// <summary>Internal helper class which implements logging-related logic.</summary>
internal static class LogImpl
{
    private static readonly ObLogCallback logHandler = OnLogMessage;        // to keep callback in memory
    private static TraceLevel traceLevel = TraceLevel.Off;
    private static readonly object traceLevelSync = new();
    private static volatile bool firstTime = true;

    /// <summary>Implementation of <see cref="Sdk.TraceLevel"/> property.</summary>
    public static TraceLevel TraceLevel
    {
        get
        {
            lock (traceLevelSync) return traceLevel;
        }

        set
        {
            lock (traceLevelSync)
            {
                if (value == traceLevel)
                    return;

                Native.ContextApi.SetLoggerCallback(value.ToLogSeverity(), logHandler, IntPtr.Zero, out var error);
                ObException.CheckError(ref error);

                traceLevel = value;

                if (firstTime)
                {
                    AppDomain.CurrentDomain.ProcessExit += CurrentDomain_Exit;
                    AppDomain.CurrentDomain.DomainUnload += CurrentDomain_Exit;
                    firstTime = false;
                }
            }
        }
    }

    /// <summary>Callback from Native SDK to log messages to standard .Net trace.</summary>
    /// <param name="severity">Log message severity.</param>
    /// <param name="message">Log message text.</param>
    /// <param name="userData">Not used.</param>
    private static void OnLogMessage(ObLogSeverity severity, string message, IntPtr userData)
    {
        switch (severity)
        {
            case ObLogSeverity.Fatal:
            case ObLogSeverity.Error:
                Trace.TraceError(message);
                break;
            case ObLogSeverity.Warn:
                Trace.TraceWarning(message);
                break;
            case ObLogSeverity.Info:
                Trace.TraceInformation(message);
                break;
            default:
                Trace.WriteLine(message);
                break;
        }
    }

    private static void CurrentDomain_Exit(object? sender, EventArgs e)
    {
        // Turns logging to .Net trace off.
        Native.ContextApi.SetLoggerCallback(TraceLevel.Off.ToLogSeverity(), logHandler, IntPtr.Zero, out var error);
        ObException.CheckError(ref error);
    }

    // Converts TraceLevel enumeration to ObLogSeverity enumeration
    private static ObLogSeverity ToLogSeverity(this TraceLevel level)
        => level switch
        {
            TraceLevel.Off => ObLogSeverity.Off,
            TraceLevel.Error => ObLogSeverity.Error,
            TraceLevel.Warning => ObLogSeverity.Warn,
            TraceLevel.Info => ObLogSeverity.Info,
            TraceLevel.Verbose => ObLogSeverity.Debug,
            _ => throw new ArgumentOutOfRangeException(nameof(level)),
        };

    /// <summary>Implementation of <see cref="Sdk.ConfigureLogging(TraceLevel, bool, string?)"/> method.</summary>
    /// <param name="level">Level of logging.</param>
    /// <param name="logToConsole">Log messages to Console?</param>
    /// <param name="logToDirectory">
    /// Log messages to the directory specified.
    /// Use <see langword="null"/> or empty string to completely disable logging to a file.
    /// </param>
    public static void ConfigureLogging(TraceLevel level, bool logToConsole, string? logToDirectory)
    {
        Native.ContextApi.SetLoggerToConsole(
            logToConsole ? level.ToLogSeverity() : ObLogSeverity.Off, out var error);
        ObException.CheckError(ref error);

        Native.ContextApi.SetLoggerToFile(
            string.IsNullOrWhiteSpace(logToDirectory) ? ObLogSeverity.Off : level.ToLogSeverity(),
            logToDirectory ?? string.Empty,
            out error);
        ObException.CheckError(ref error);
    }
}
