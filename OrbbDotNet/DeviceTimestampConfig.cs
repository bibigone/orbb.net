using System.Runtime.InteropServices;

namespace OrbbDotNet;

/// <summary>The timestamp reset configuration of the device.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct DeviceTimestampConfig
{
    private Native.NativeBool enable;

    /// <summary>Whether to enable the timestamp reset function.</summary>
    /// <remarks><para>
    /// If the timestamp reset function is enabled, the timer for calculating the timestamp for output frames
    /// will be reset to 0 when the timestamp reset command or timestamp reset signal is received,
    /// and one timestamp reset signal will be output via TIMER_SYNC_OUT pin on synchronization port by default.
    /// The timestamp reset signal is input via TIMER_SYNC_IN pin on the synchronization port.
    /// </para><para>
    /// For some models, the timestamp reset function is always enabled and cannot be disabled.
    /// </para></remarks>
    public bool Enable
    {
        get => enable;
        set => enable = value;
    }

    /// <summary>The delay time of executing the timestamp reset function after receiving the command or signal in microseconds.</summary>
    public int TimestampResetDelayUs;

    private Native.NativeBool timestampResetSignalOutputEnable;

    /// <summary>The timestamp reset signal output enable flag.</summary>
    /// <remarks>For some models, the timestamp reset signal output is always enabled and cannot be disabled.</remarks>
    public bool TimestampResetSignalOutputEnable
    {
        get => timestampResetSignalOutputEnable;
        set => timestampResetSignalOutputEnable = value;
    }
}
