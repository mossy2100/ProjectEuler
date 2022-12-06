using System.Numerics;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=12" />
/// </summary>
public static class Problem12
{
    public static long Answer()
    {
        long triangleNumber = 0;
        long i = 1;
        while (true)
        {
            triangleNumber += i;
            List<BigInteger> divisors = GetDivisors(triangleNumber);
            if (divisors.Count > 500)
            {
                return triangleNumber;
            }
            i++;
        }
    }
}
