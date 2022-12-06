namespace AstroMultimedia.ProjectEuler.Tests;

[TestClass]
public class Test1To10
{
    [TestMethod]
    public void TestProblem1() => Assert.AreEqual(233168, Problem1.Answer());

    [TestMethod]
    public void TestProblem2() => Assert.AreEqual(4613732, Problem2.Answer());

    [TestMethod]
    public void TestProblem3() => Assert.AreEqual(6857, Problem3.Answer());

    [TestMethod]
    public void TestProblem4() => Assert.AreEqual(906609, Problem4.Answer());

    [TestMethod]
    public void TestProblem5() => Assert.AreEqual(232792560, Problem5.Answer());

    [TestMethod]
    public void TestProblem6() => Assert.AreEqual(25164150, Problem6.Answer());

    [TestMethod]
    public void TestProblem7() => Assert.AreEqual(104743, Problem7.Answer());

    [TestMethod]
    public void TestProblem8() => Assert.AreEqual(23514624000, Problem8.Answer());

    [TestMethod]
    public void TestProblem9() => Assert.AreEqual(31875000, Problem9.Answer());

    [TestMethod]
    public void TestProblem10() => Assert.AreEqual(142913828922, Problem10.Answer());
}
