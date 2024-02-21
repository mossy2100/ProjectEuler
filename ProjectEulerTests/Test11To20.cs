namespace Galaxon.ProjectEuler.Tests;

[TestClass]
public class Test11To20
{
    [TestMethod]
    public void TestProblem11()
    {
        Assert.AreEqual(70600674, Problem11.Answer());
    }

    [TestMethod]
    public void TestProblem12()
    {
        Assert.AreEqual(76576500, Problem12.Answer());
    }

    [TestMethod]
    public void TestProblem13()
    {
        Assert.AreEqual(5537376230, Problem13.Answer());
    }

    [TestMethod]
    public void TestProblem14()
    {
        Assert.AreEqual(837799, Problem14.Answer());
    }

    [TestMethod]
    public void TestProblem15()
    {
        Assert.AreEqual(137846528820, Problem15.Answer());
    }

    [TestMethod]
    public void TestProblem16()
    {
        Assert.AreEqual(1366, Problem16.Answer());
    }

    [TestMethod]
    public void TestProblem17()
    {
        Assert.AreEqual(21124, Problem17.Answer());
    }

    [TestMethod]
    public void TestProblem18()
    {
        Assert.AreEqual(1074, Problem18.Answer());
    }

    [TestMethod]
    public void TestProblem19()
    {
        Assert.AreEqual(171, Problem19.Answer());
    }

    [TestMethod]
    public void TestProblem20()
    {
        Assert.AreEqual(648, Problem20.Answer());
    }
}
