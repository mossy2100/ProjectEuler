using Galaxon.Core.Numbers;
using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Factorial digit sum.
/// <see href="https://projecteuler.net/problem=20" />
/// </summary>
public static class Problem20
{
    public static long Answer() =>
        (long)Factorials.Factorial(100).DigitSum();
}
