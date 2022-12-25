using Galaxon.Numerics.Types;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Convergents of e.
/// <see href="https://projecteuler.net/problem=65" />
/// </summary>
public static class Problem65
{
    public static int ESequence(int index) =>
        (index % 3 is 0 or 2) ? 1 : (2 * (index / 3 + 1));

    public static long Answer()
    {
        int n = 100;
        BigRational f = ESequence(n - 2);
        for (int m = n - 2; m >= 0; m--)
        {
            int prevTerm = (m == 0) ? 0 : ESequence(m - 1);
            f = prevTerm + ~f;
        }
        f += 2;
        return f.Numerator.ToString().Sum(c => c - '0');
    }
}
