using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
///     <see href="https://projecteuler.net/problem=78" />
/// </summary>
public static class Problem78
{
    public static long Answer()
    {
        ushort n = 0;
        while (true)
        {
            if (Partitions.P(n) % 1_000_000 == 0)
            {
                break;
            }
            n++;
        }
        return n;
    }
}
