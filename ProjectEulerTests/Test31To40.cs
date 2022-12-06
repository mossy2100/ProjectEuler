namespace AstroMultimedia.ProjectEuler.Tests;

[TestClass]
public class Test31To40
{
    [TestMethod]
    public void TestProblem31() => Assert.AreEqual(73682, Problem31.Answer());

    [TestMethod]
    public void TestProblem32() => Assert.AreEqual(45228, Problem32.Answer());

    [TestMethod]
    public void TestProblem33() => Assert.AreEqual(100, Problem33.Answer());

    [TestMethod]
    public void TestProblem34() => Assert.AreEqual(40730, Problem34.Answer());

    [TestMethod]
    public void TestProblem35() => Assert.AreEqual(55, Problem35.Answer());

    [TestMethod]
    public void TestProblem36() => Assert.AreEqual(872187, Problem36.Answer());

    [TestMethod]
    public void TestProblem37() => Assert.AreEqual(748317, Problem37.Answer());

    [TestMethod]
    public void TestProblem38() => Assert.AreEqual(932718654, Problem38.Answer());

    [TestMethod]
    public void TestProblem39() => Assert.AreEqual(840, Problem39.Answer());

    [TestMethod]
    public void TestProblem40() => Assert.AreEqual(210, Problem40.Answer());
}
