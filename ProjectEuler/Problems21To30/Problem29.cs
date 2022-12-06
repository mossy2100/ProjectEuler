using System.Numerics;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Distinct powers.
/// <see href="https://projecteuler.net/problem=29" />
/// </summary>
public static class Problem29
{
    public static long Answer()
    {
        HashSet<BigInteger> terms = new();
        for (int a = 2; a <= 100; a++)
        {
            for (int b = 2; b <= 100; b++)
            {
                terms.Add(BigInteger.Pow(a, b));
            }
        }
        return terms.Count;
    }
}
