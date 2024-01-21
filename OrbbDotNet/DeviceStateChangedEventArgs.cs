using System;

namespace OrbbDotNet;

public sealed class DeviceStateChangedEventArgs : EventArgs
{
    internal DeviceStateChangedEventArgs(DeviceState state, string? message)
    {
        State = state;
        Message = message;
    }

    public DeviceState State { get; }

    public string? Message { get; }
}
