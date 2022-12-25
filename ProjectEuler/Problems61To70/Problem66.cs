using System.Numerics;
using Galaxon.Core.Numbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Diophantine equation.
/// <see href="https://projecteuler.net/problem=66" />
/// </summary>
public static class Problem66
{
    public static long Answer()
    {
        BigInteger largestX = 0;
        int DForLargestX = 0;
        int min = 2;
        int max = 1000;
        for (int D = min; D <= max; D++)
        {
            Console.WriteLine();
            Console.WriteLine($"D = {D}:");

            // Skip squares.
            if (XDouble.IsPerfectSquare(D))
            {
                Console.WriteLine("Perfect square, skipping.");
                continue;
            }

            (BigInteger x, BigInteger y) = Pell.Solve(D);
            Console.WriteLine($"{x:N0}² - {D}×{y:N0}² = 1");

            if (x > largestX)
            {
                largestX = x;
                DForLargestX = D;
            }
        }

        return DForLargestX;
    }
}
