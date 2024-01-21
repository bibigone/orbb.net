using System;

namespace OrbbDotNet;

/// <summary>Information about added and removed devices for <see cref="Context.DeviceListChanged"/> event.</summary>
public sealed class DeviceListChangedEventArgs : EventArgs, IDisposable
{
    /// <summary>Creates object.</summary>
    /// <param name="removedDevices">Removed devices. Lifetime is controlled outside.</param>
    /// <param name="addedDevices">Added devices. Lifetime is controlled outside.</param>
    internal DeviceListChangedEventArgs(DeviceList removedDevices, DeviceList addedDevices)
    {
        RemovedDevices = removedDevices;
        AddedDevices = addedDevices;
    }

    /// <summary>List of removed devices.</summary>
    /// <remarks>This list is valid only inside event handler.</remarks>
    public DeviceList RemovedDevices { get; }

    /// <summary>List of added devices.</summary>
    /// <remarks>This list is valid only inside event handler.</remarks>
    public DeviceList AddedDevices { get; }

    public bool AutoListsDisposing { get; set; } = true;

    public void Dispose()
    {
        if (AutoListsDisposing)
        {
            RemovedDevices.Dispose();
            AddedDevices.Dispose();
        }
    }
}
