namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Triangular, pentagonal, and hexagonal.
/// <see href="https://projecteuler.net/problem=45" />
/// </summary>
public static class Problem45
{
    public static long Answer()
    {
        int n = 285;
        while (true)
        {
            n++;
            long t = Triangular.Get(n);
            if (Pentagonal.IsPentagonal(t) && Hexagonal.IsHexagonal(t))
            {
                // Found the answer.
                return t;
            }
        }
    }
}
