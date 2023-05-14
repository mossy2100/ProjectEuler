using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Truncatable primes.
/// <see href="https://projecteuler.net/problem=37" />
/// </summary>
public static class Problem37
{
    public static long Answer()
    {
        ulong sum = 0;
        List<ulong> values = new ();

        // Start at 10 to skip single-digit matches.
        ulong n = 10;

        // We know there are only 11.
        while (values.Count < 11)
        {
            if (!Primes.IsPrime(n))
            {
                n++;
                continue;
            }

            // Check if it's both left- and right-truncatable.
            var nStr = n.ToString();
            var passes = true;
            for (var j = 1; j < nStr.Length; j++)
            {
                var left = ulong.Parse(nStr[..^j]);
                var right = ulong.Parse(nStr[j..]);
                if (!Primes.IsPrime(left) || !Primes.IsPrime(right))
                {
                    passes = false;
                }
            }

            if (passes)
            {
                sum += n;
                values.Add(n);
            }

            n++;
        }

        return (long)sum;
    }
}
