namespace Galaxon.ProjectEuler.Tests;

[TestClass]
public class Test21To30
{
    [TestMethod]
    public void TestProblem21() =>
        Assert.AreEqual(31626, Problem21.Answer());

    [TestMethod]
    public void TestProblem22() =>
        Assert.AreEqual(871198282, Problem22.Answer());

    [TestMethod]
    public void TestProblem23() =>
        Assert.AreEqual(4179871, Problem23.Answer());

    [TestMethod]
    public void TestProblem24() =>
        Assert.AreEqual(2783915460, Problem24.Answer());

    [TestMethod]
    public void TestProblem25() =>
        Assert.AreEqual(4782, Problem25.Answer());

    [TestMethod]
    public void TestProblem26() =>
        Assert.AreEqual(983, Problem26.Answer());

    [TestMethod]
    public void TestProblem27() =>
        Assert.AreEqual(-59231, Problem27.Answer());

    [TestMethod]
    public void TestProblem28() =>
        Assert.AreEqual(669171001, Problem28.Answer());

    [TestMethod]
    public void TestProblem29() =>
        Assert.AreEqual(9183, Problem29.Answer());

    [TestMethod]
    public void TestProblem30() =>
        Assert.AreEqual(443839, Problem30.Answer());
}
