namespace Galaxon.ProjectEuler;

/// <summary>
/// Lattice paths.
/// <see href="https://projecteuler.net/problem=15" />
/// </summary>
public static class Problem15
{
    private static readonly Dictionary<(int dx, int dy), long> NumPathsCache = new();

    private static long GetNumPaths(int x0, int y0, int x1, int y1)
    {
        // Check cache.
        int dx = x1 - x0;
        int dy = y1 - y0;
        if (NumPathsCache.ContainsKey((dx, dy)))
        {
            return NumPathsCache[(dx, dy)];
        }

        long result;

        if (x0 == x1 && y0 == y1)
        {
            result = 0;
        }
        else if (x0 == x1 || y0 == y1)
        {
            result = 1;
        }
        else
        {
            result = GetNumPaths(x0 + 1, y0, x1, y1) + GetNumPaths(x0, y0 + 1, x1, y1);
        }

        // Add result to cache.
        NumPathsCache[(dx, dy)] = result;

        return result;
    }

    public static long Answer()
    {
        const int n = 20;
        long numPaths = GetNumPaths(0, 0, n, n);
        return numPaths;
    }
}
