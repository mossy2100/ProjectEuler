using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Lexicographic permutations.
/// <see href="https://projecteuler.net/problem=24"/>
/// </summary>
public static class Problem24
{
    public static long Answer()
    {
        List<string> permutations = Combinatorial.CharPermutations("0123456789");
        return long.Parse(permutations[999999]);
    }
}
