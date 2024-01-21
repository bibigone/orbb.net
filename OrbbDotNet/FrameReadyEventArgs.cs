using System;

namespace OrbbDotNet;

public sealed class FrameReadyEventArgs : EventArgs, IDisposable
{
    internal FrameReadyEventArgs(Frame frame)
        => Frame = frame;

    public Frame Frame { get; }

    public bool AutoFrameDisposing { get; set; } = true;

    public void Dispose()
    {
        if (AutoFrameDisposing)
            Frame.Dispose();
    }
}
