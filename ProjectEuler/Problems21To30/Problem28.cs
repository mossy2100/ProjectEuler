using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
///     <see href="https://projecteuler.net/problem=" />
/// </summary>
public static class Problem28
{
    public static long Answer()
    {
        const int SIZE = 1001;
        var spiral = Grids.ConstructSpiral(SIZE, true, EDirection.Right);
        // PrintGrid(spiral, size);

        // Sum the diagonals.
        long result = 0;
        for (var i = 0; i < SIZE; i++)
        {
            result += spiral[i, i] ?? 0;
            result += spiral[i, SIZE - i - 1] ?? 0;
        }
        return result - 1;
    }
}
