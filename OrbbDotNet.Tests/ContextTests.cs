namespace OrbbDotNet.Tests;

[TestClass]
public class ContextTests
{
    [TestMethod]
    public void TestCreation()
    {
        var context = new Context();
        var list = context.DeviceList;
        Assert.IsNotNull(list);
        Assert.AreEqual(0, list.Count);
        context.DeviceListChanged += (o, e) => { };
        context.Dispose();
        context.Dispose();
    }

    [TestMethod]
    public void TestCreationWithConfig()
    {
        Sdk.TraceLevel = System.Diagnostics.TraceLevel.Verbose;
        var context = new Context("xyz");
        Sdk.TraceLevel = System.Diagnostics.TraceLevel.Off;
        context.Dispose();
    }
}