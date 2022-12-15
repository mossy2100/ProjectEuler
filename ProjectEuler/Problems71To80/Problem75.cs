namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Singular integer right triangles.
/// <see href="https://projecteuler.net/problem=75" />
/// </summary>
public static class Problem75
{
    public static long Answer()
    {
        ulong max = 1_500_000;
        int[] count = new int[max + 1];
        Dictionary<ulong, ulong> squares = PolygonalNumbers.GetAllSquareUpTo(max * max);
        for (ulong len = 12; len <= max; len++)
        {
            ulong maxA = (len - 3) / 3;
            for (ulong a = 1; a <= maxA; a++)
            {
                // Make b > a, otherwise we'll find duplicates (e.g. 4, 3, 5 as well as 3, 4, 5).
                ulong maxB = (len - a - 1) / 2;
                for (ulong b = a + 1; b <= maxB; b++)
                {
                    if (len < 2 * b + a + 1)
                    {
                        break;
                    }

                    // Calculate the candidate hypotenuse.
                    ulong c = len - a - b;

                    // Test the values, without using Pow() or division.
                    ulong aSqrPlusBSqr = squares[a] + squares[b];
                    ulong cSqr = squares[c];

                    if (aSqrPlusBSqr > cSqr)
                    {
                        // Stop searching.
                        break;
                    }

                    if (aSqrPlusBSqr == cSqr)
                    {
                        // Found a solution.
                        // Console.WriteLine($"{a}^2 + {b}^2 = {c}^2");
                        count[len]++;
                    }
                } // for b
            } // for a

            if (len % 1000 == 0)
            {
                Console.WriteLine($"len = {len}");
            }

        } // for len

        return count.Count(i => i == 1);
    }

    public static Dictionary<ulong, ulong> Squares = new ();

    public static ulong Sqr(ulong n)
    {
        if (!Squares.ContainsKey(n))
        {
            Squares[n] = n * n;
        }
        return Squares[n];
    }

    public static long Answer2()
    {
        // Set the maximum perimeter.
        const ulong max = 1_500_000;

        // Keep track of how many solutions we find, grouped by perimeter.
        List<PythagoreanTriple> triples = new ();

        // Also keep track of how many solutions we find for each length.
        int[] count = new int[max + 1];

        // Find all the Pythagorean primitives up to max length.

        // Try values for n.
        ulong n = 1;
        bool done = false;
        while (!done)
        {
            // Try values for m. We know m > n, and that one is odd, one is even.
            ulong m = n + 1;

            while (true)
            {
                // Check m and n are coprime.
                if (!Primes.AreCoprime(n, m))
                {
                    m += 2;
                    continue;
                }

                // Calculate a, b, c, and len.
                ulong a = Sqr(m) - Sqr(n);
                ulong b = 2 * m * n;
                ulong c = Sqr(m) + Sqr(n);
                ulong len = a + b + c;

                // If perimeter is too large, stop checking values for m.
                if (len > max)
                {
                    // If m is the minimum value for this n, and the length is too large,
                    // n is now too large, so exit the outer (n) loop.
                    if (m == n + 1)
                    {
                        done = true;
                    }
                    break;
                }

                // Check we haven't found it already.
                PythagoreanTriple triple = new (a, b, c);
                if (!triples.Contains(triple))
                {
                    // Found a primitive triple.
                    triples.Add(triple);
                    count[len]++;
                    // Console.WriteLine(triple);
                }

                // Next m.
                m += 2;
            }

            // Next n.
            n++;
        }

        // Now we have the primitives, count up the multiples.
        foreach (PythagoreanTriple triple in triples)
        {
            for (ulong k = 2; k <= max / triple.Length; k++)
            {
                count[k * triple.Length]++;
            }
        }

        // string output = string.Join(" ", triples
        //     .Where(t => t.IsPrimitive)
        //     .OrderBy(t => t.Length)
        //     .Select(t => t.ToString()));
        // Console.WriteLine(output);

        return count.Count(i => i == 1);
    }
}

public class PythagoreanTriple
{
    public ulong a;
    public ulong b;
    public ulong c;

    public PythagoreanTriple(ulong a, ulong b, ulong c)
    {
        if (a < b)
        {
            this.a = a;
            this.b = b;
        }
        else
        {
            this.a = b;
            this.b = a;
        }
        this.c = c;
    }

    public ulong Length => a + b + c;

    public bool IsPrimitive => Primes.AreCoprime(a, b);

    public override string ToString() =>
        $"({a}, {b}, {c})";

    public override bool Equals(object? obj)
    {
        if (obj is not PythagoreanTriple triple)
        {
            return false;
        }
        return triple.a == a && triple.b == b && triple.c == c;
    }

    public override int GetHashCode() =>
        ToString().GetHashCode();
}
