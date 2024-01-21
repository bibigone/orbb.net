namespace OrbbDotNet;

public interface ISensorListItem
{
    SensorType SensorType { get; }
    Sensor Sensor { get; }
}
