using System.Runtime.InteropServices;

namespace OrbbDotNet;

// typedef uint64_t OBDeviceState, ob_device_state;
/// <summary>Device state.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct DeviceState
{
    public ulong Value;
}
