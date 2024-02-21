using Galaxon.Core.Numbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Factorial digit sum.
/// <see href="https://projecteuler.net/problem=20"/>
/// </summary>
public static class Problem20
{
    public static long Answer()
    {
        return (long)BigIntegerExtensions.Factorial(100).DigitSum();
    }
}
