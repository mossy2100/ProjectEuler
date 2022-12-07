namespace AstroMultimedia.ProjectEuler;

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
            ulong t = PolygonalNumbers.GetTriangular(n);
            if (PolygonalNumbers.IsPentagonal(t) && PolygonalNumbers.IsHexagonal(t))
            {
                // Found the answer.
                return (long)t;
            }
        }
    }
}
