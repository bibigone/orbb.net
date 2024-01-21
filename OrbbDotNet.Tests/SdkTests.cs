namespace OrbbDotNet.Tests;

[TestClass]
public class SdkTests
{
    [TestMethod]
    public void TestVersion()
    {
        var v = Sdk.Version;
        Assert.AreEqual(1, v.Major);
        Assert.AreEqual(8, v.Minor);
        Assert.AreEqual(1, v.Build);

        var s = Sdk.VersionStage;
        Assert.AreEqual("main", s);
    }

    [TestMethod]
    [ExpectedException(typeof(ObException.InvalidParameter))]
    public void TestWrongLicense()
    {
        Sdk.LoadLicense("xyz", "a");
    }
}