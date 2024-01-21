using System.Runtime.InteropServices;

namespace OrbbDotNet.Tests;

[TestClass]
public class FrameTests
{
    private static readonly int testWidth = 32;
    private static readonly int testHeight = 16;
    private static readonly TimeSpan testSystemTimestamp = TimeSpan.FromMilliseconds(12345);
    private static readonly TimeSpan testDeviceTimestamp = TimeSpan.FromMilliseconds(987654);
    private static readonly long testDeviceTimestampUsec = 19760216L;


    [TestMethod]
    public void TestFrameSetCreation()
    {
        using var frameSet = new Frame.Set();
        Assert.AreEqual(0, frameSet.Count);
        Assert.IsNull(frameSet[FrameType.Color]);
        Assert.IsNull(frameSet.ColorFrame);
    }

    [TestMethod]
    public void TestFrameSetInFrameSet()
    {
        using var frameSet = new Frame.Set();
        using var subFrameset = new Frame.Set();
        frameSet.PushFrame(subFrameset);
        Assert.AreEqual(1, frameSet.Count);
        Assert.AreEqual(0, subFrameset.Count);
        Assert.IsNotNull(frameSet[FrameType.Set]);
    }

    [TestMethod]
    public void TestDepthFrameCreation()
    {
        using var frame = Frame.Create(DataFormat.Y16, testWidth, testHeight, testWidth * 2, FrameType.Depth);
        Assert.AreEqual(DataFormat.Y16, frame.DataFormat);
        Assert.AreEqual(testWidth * testHeight * 2, frame.DataSizeBytes);
        Assert.AreEqual(FrameType.Depth, frame.FrameType);
        Assert.IsInstanceOfType(frame, typeof(Frame.Depth));
        var depthFrame = frame as Frame.Depth;
        Assert.IsNotNull(depthFrame);
        Assert.AreEqual(testWidth, depthFrame.Width);
        Assert.AreEqual(testHeight, depthFrame.Height);
        Assert.AreEqual(16, depthFrame.PixelAvailableBitSize);
        Assert.AreEqual(1f, depthFrame.ValueScale);
    }

    [TestMethod]
    public void TestColorRgbFrameCreation()
    {
        using var frame = Frame.Create(DataFormat.Rgb, testWidth, testHeight, testWidth * 4, FrameType.Color);
        Assert.AreEqual(DataFormat.Rgb, frame.DataFormat);
        Assert.AreEqual(testWidth * testHeight * 4, frame.DataSizeBytes);
        Assert.AreEqual(FrameType.Color, frame.FrameType);
        Assert.IsInstanceOfType(frame, typeof(Frame.Color));
        var colorFrame = frame as Frame.Color;
        Assert.IsNotNull(colorFrame);
        Assert.AreEqual(testWidth, colorFrame.Width);
        Assert.AreEqual(testHeight, colorFrame.Height);
        Assert.AreEqual(0, colorFrame.PixelAvailableBitSize);
    }

    [TestMethod]
    public void TestFramePushingToSet()
    {
        using var frameSet = new Frame.Set();
        using var frame = Frame.Create(DataFormat.Y16, testWidth, testHeight, testWidth * 2, FrameType.Depth);
        frameSet.PushFrame(frame);
        Assert.AreEqual(1, frameSet.Count);
        using var depthFrame = frameSet.DepthFrame;
        Assert.IsNotNull(depthFrame);
        Assert.AreEqual(testWidth, depthFrame.Width);
        Assert.AreEqual(testHeight, depthFrame.Height);
        Assert.AreEqual(16, depthFrame.PixelAvailableBitSize);
        Assert.AreEqual(1f, depthFrame.ValueScale);
        Assert.AreEqual(frame.DataPtr, depthFrame.DataPtr);
        Assert.AreEqual(frame.DataSizeBytes, depthFrame.DataSizeBytes);
    }

    [TestMethod]
    public void TestTimestamps()
    {
        using var frameset = new Frame.Set();
        Assert.AreEqual(TimeSpan.Zero, frameset.SystemTimestamp);
        Assert.AreEqual(TimeSpan.Zero, frameset.DeviceTimestamp);
        Assert.AreEqual(0L, frameset.DeviceTimestampUsec);
        frameset.SystemTimestamp = testSystemTimestamp;
        Assert.AreEqual(testSystemTimestamp, frameset.SystemTimestamp);
        Assert.AreEqual(TimeSpan.Zero, frameset.DeviceTimestamp);
        Assert.AreEqual(0L, frameset.DeviceTimestampUsec);
        frameset.DeviceTimestamp = testDeviceTimestamp;
        Assert.AreEqual(testDeviceTimestamp, frameset.DeviceTimestamp);
        Assert.AreEqual(0L, frameset.DeviceTimestampUsec);  // Independent property!
        frameset.DeviceTimestampUsec = testDeviceTimestampUsec;
        Assert.AreEqual(testDeviceTimestampUsec, frameset.DeviceTimestampUsec);
        Assert.AreEqual(testDeviceTimestamp, frameset.DeviceTimestamp);      // DeviceTimestampUsec does not affect DeviceTimestamp and vice versa
    }

    [TestMethod]
    public void TestCreationFromArray()
    {
        var array = new byte[testWidth * testHeight * 4];
        array[0] = 76;
        array[1] = 2;
        array[2] = 16;
        array[array.Length - 1] = 255;

        using var frame = Frame.CreateFromArray(array, DataFormat.Bgra, testWidth, testHeight);
        Assert.IsNotNull(frame);
        Assert.AreEqual(FrameType.Video, frame.FrameType);
        Assert.AreEqual(DataFormat.Bgra, frame.DataFormat);
        Assert.AreEqual(array.Length, frame.DataSizeBytes);
        Assert.AreEqual(array[0], Marshal.ReadByte(frame.DataPtr, 0));
        Assert.AreEqual(array[1], Marshal.ReadByte(frame.DataPtr, 1));
        Assert.AreEqual(array[2], Marshal.ReadByte(frame.DataPtr, 2));
        Assert.AreEqual(array[array.Length - 1], Marshal.ReadByte(frame.DataPtr, array.Length - 1));
        Assert.IsInstanceOfType(frame, typeof(Frame.Video));
        var videoFrame = frame as Frame.Video;
        Assert.IsNotNull(videoFrame);
        Assert.AreEqual(testWidth, videoFrame.Width);
        Assert.AreEqual(testHeight, videoFrame.Height);
        Assert.AreEqual(0, videoFrame.PixelAvailableBitSize);
    }

    #region Testing of IsDisposed property, Dispose() method and Disposed event

    [TestMethod]
    public void TestDisposing()
    {
        var frame = Frame.Create(DataFormat.Y16, testWidth, testHeight, testWidth * 2, FrameType.Depth);

        // Check disposing
        Assert.IsFalse(frame.IsDisposed);
        var disposedEventCounter = 0;
        frame.Disposed += (_, __) => disposedEventCounter++;
        frame.Dispose();
        Assert.IsTrue(frame.IsDisposed);
        Assert.AreEqual(1, disposedEventCounter);

        // We can call Dispose() multiple times
        frame.Dispose();
        Assert.IsTrue(frame.IsDisposed);
        // But Disposed event must be invoked only once
        Assert.AreEqual(1, disposedEventCounter);
    }

    private Frame CreateFrameFromArray(out WeakReference<byte[]> weakReferenceToArray)
    {
        var format = DataFormat.Bgra;
        var array = new byte[4];
        weakReferenceToArray = new WeakReference<byte[]>(array);
        return Frame.CreateFromArray(array, format, 1, 1);
    }

    [TestMethod]
    public void TestArrayUnpinningOnDispose()
    {
        var frame = CreateFrameFromArray(out var weakReferenceToArray);
        frame.Dispose();

        // Force collecting of array
        GC.Collect();

        Assert.IsFalse(weakReferenceToArray.TryGetTarget(out _));

        // Nothing bad if we call dispose second time
        frame.Dispose();
    }

    [TestMethod]
    [ExpectedException(typeof(ObjectDisposedException))]
    public void TestObjectDisposedException()
    {
        var frame = Frame.Create(DataFormat.Y16, testWidth, testHeight, testWidth * 2, FrameType.Depth);
        frame.Dispose();
        _ = frame.DataPtr;      // <- ObjectDisposedException
    }

    #endregion

    #region Test duplicate reference

    [TestMethod]
    public void TestDuplicateReference()
    {
        var frame = CreateFrameFromArray(out var weakReferenceToArray);
        var refFrame = frame.DuplicateReference();

        Assert.AreEqual(frame, refFrame);
        Assert.IsTrue(frame == refFrame);
        Assert.IsFalse(frame != refFrame);

        Assert.AreEqual(frame.DataPtr, refFrame.DataPtr);
        Assert.AreEqual(frame.DataSizeBytes, refFrame.DataSizeBytes);
        Assert.AreEqual(frame.FrameType, refFrame.FrameType);
        Assert.AreEqual(frame.DataFormat, refFrame.DataFormat);

        // Check that when we change property of image,
        // then property of refImage is also synchronously changed
        frame.DeviceTimestamp = testDeviceTimestamp;
        Assert.AreEqual(testDeviceTimestamp, refFrame.DeviceTimestamp);

        // And vice versa
        refFrame.SystemTimestamp = testSystemTimestamp;
        Assert.AreEqual(testSystemTimestamp, frame.SystemTimestamp);

        // And for one more property
        frame.DeviceTimestampUsec = testDeviceTimestampUsec;
        Assert.AreEqual(testDeviceTimestampUsec, refFrame.DeviceTimestampUsec);

        // Dispose source image
        frame.Dispose();

        // But refImage must be still alive
        Assert.IsFalse(refFrame.IsDisposed);
        Assert.AreNotEqual(IntPtr.Zero, refFrame.DataPtr);

        // Force GC
        GC.Collect();

        // But array is still alive because refImage keeps it
        Assert.IsTrue(weakReferenceToArray.TryGetTarget(out _));

        refFrame.Dispose();
    }

    #endregion
}