using Galaxon.Core.Numbers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Odd period square roots.
/// <see href="https://projecteuler.net/problem=64" />
/// </summary>
public static class Problem64
{
    public static long Answer()
    {
        int count = 0;
        for (int a = 2; a <= 10000; a++)
        {
            double s = Sqrt(a);
            int b = (int)Floor(s);
            double r = s - b;

            // Skip perfect squares.
            if (r.FuzzyEquals(0))
            {
                Console.WriteLine($"{a} is a perfect square.");
                continue;
            }

            // Starting fraction.
            Problem64Fraction frac = new (a, b, 1);

            // Find the repeating sequence.
            List<(int value, string strFrac)> seq = new ();
            while (true)
            {
                int e = frac.Invert();
                string strFrac = frac.ToString();

                if (seq.Any(tup => tup.strFrac == strFrac))
                {
                    break;
                }

                seq.Add((e, strFrac));
            }

            // Count the numbers with odd sequences.
            if (seq.Count % 2 == 1)
            {
                count++;
            }

            // Feedback for testing.
            List<int> intSequence = seq.Select(tup => tup.value).ToList();
            Console.WriteLine($"The sequence for Sqrt({a}) is [{b}; ({string.Join(", ", intSequence)})], period = {seq.Count}");
        }

        return count;
    }
}

/// <summary>
/// BigRational of the form (√A - B) / C
/// </summary>
public class Problem64Fraction
{
    public int A;
    public int B;
    public int C;

    public Problem64Fraction(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
    }

    public int Invert()
    {
        int d = A - (B * B);
        int e = (int)Floor(C * (Sqrt(A) + B) / d);
        d /= C;
        B = e * d - B;
        C = d;
        return e;
    }

    public override string ToString() =>
        $"(√{A}-{B})/{C}";
}
