using Galaxon.ProjectEuler.Problems81To90;

namespace Galaxon.ProjectEuler.Tests;

[TestClass]
public class Test81To90
{
    [TestMethod]
    public void TestProblem81Example() => Assert.AreEqual(2427, Problem81.Example());

    [TestMethod]
    public void TestProblem81() => Assert.AreEqual(427337, Problem81.Answer());

    [TestMethod]
    public void TestProblem82Example() => Assert.AreEqual(994, Problem82.Example());

    [TestMethod]
    public void TestProblem82() => Assert.AreEqual(260324, Problem82.Answer());

    // [TestMethod]
    // public void TestProblem83() => Assert.AreEqual(7295372, Problem83.Answer());
    //
    // [TestMethod]
    // public void TestProblem84() => Assert.AreEqual(402, Problem84.Answer());
    //
    // [TestMethod]
    // public void TestProblem85() => Assert.AreEqual(161667, Problem85.Answer());
    //
    // [TestMethod]
    // public void TestProblem86() => Assert.AreEqual(190569291, Problem86.Answer());
    //
    // [TestMethod]
    // public void TestProblem87() => Assert.AreEqual(71, Problem87.Answer());
    //
    // [TestMethod]
    // public void TestProblem88() => Assert.AreEqual(55374, Problem88.Answer());
    //
    // [TestMethod]
    // public void TestProblem89() => Assert.AreEqual(73162890, Problem89.Answer());
    //
    // [TestMethod]
    // public void TestProblem90() => Assert.AreEqual(40886, Problem90.Answer());
}
