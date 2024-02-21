using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// 10001st prime.
/// <see href="https://projecteuler.net/problem=7"/>
/// </summary>
public static class Problem7
{
    public static long Answer()
    {
        List<ulong> primes = new ();
        ulong n = 2;
        while (primes.Count < 10001)
        {
            if (Primes.IsPrime(n))
            {
                primes.Add(n);
            }
            n++;
        }
        return (long)primes[10000];
    }
}
