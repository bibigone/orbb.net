namespace OrbbDotNet;

/// <summary>Basic information about a device.</summary>
/// <remarks>Accessible as items in <see cref="DeviceList"/> collection and as property <see cref="Device.DeviceInfo"/> of <see cref="Device"/>.</remarks>
public interface IBasicDeviceInfo
{
    /// <summary>Device PID (hardware Product ID)</summary>
    int Pid { get; }

    /// <summary>Device VID (hardware Vendor ID)</summary>
    int Vid { get; }

    /// <summary>Device UID</summary>
    string? Uid { get; }

    /// <summary>Device serial number</summary>
    string? SerialNumber { get; }

    /// <summary>Device connection type："USB", "USB1.0", "USB1.1", "USB2.0", "USB2.1", "USB3.0", "USB3.1", "USB3.2", "Ethernet".</summary>
    string? ConnectionType { get; }

    /// <summary>Device IP address like "192.168.1.10"</summary>
    /// <remarks>Only valid for network devices, otherwise it will return "0.0.0.0".</remarks>
    string? IPAddress { get; }

    /// <summary>Device extension information.</summary>
    string? ExtensionInfo { get; }
}
