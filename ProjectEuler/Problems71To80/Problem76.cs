using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Counting summations.
/// <see href="https://projecteuler.net/problem=76" />
/// </summary>
public static class Problem76
{
    public static long Answer()
    {
        return (long)Partitions.P(100) - 1;
    }
}
