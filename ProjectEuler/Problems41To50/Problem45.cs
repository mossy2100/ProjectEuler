using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Triangular, pentagonal, and hexagonal.
/// <see href="https://projecteuler.net/problem=45" />
/// </summary>
public static class Problem45
{
    public static long Answer()
    {
        ulong n = 285;
        while (true)
        {
            n++;
            var t = Polygonal.GetTriangular(n);
            if (Polygonal.IsPentagonal(t) && Polygonal.IsHexagonal(t))
            {
                // Found the answer.
                return (long)t;
            }
        }
    }
}
