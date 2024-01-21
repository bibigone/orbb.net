namespace OrbbDotNet;

public struct PropertyRange<T> where T : unmanaged
{
    public T Current;
    public T Min;
    public T Max;
    public T Step;
    public T Default;
}
