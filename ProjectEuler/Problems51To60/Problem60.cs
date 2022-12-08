namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Prime pair sets.
/// <see href="https://projecteuler.net/problem=60" />
/// </summary>
public static class Problem60
{
    public static bool AreConcatPrimes(ulong p1, ulong p2)
    {
        ulong num1 = ulong.Parse($"{p1}{p2}");
        if (!Primes.IsPrime(num1))
        {
            // Console.WriteLine($"{p1} ~ {p2} is composite.");
            return false;
        }
        ulong num2 = ulong.Parse($"{p2}{p1}");
        if (!Primes.IsPrime(num2))
        {
            // Console.WriteLine($"{p2} ~ {p1} is composite.");
            return false;
        }
        return true;
    }

    public static long Answer()
    {
        // Keep track of the lowest sum found so far.
        ulong lowestSum = 0;
        List<ulong> resultSet = new ();

        // Get some primes.
        // Make a guess at the largest prime in the set (it actually turns out to be 8389).
        Primes.Eratosthenes(10000);
        ulong[] primes = Primes.Cache.ToArray();
        int nPrimes = primes.Length;

        // Try all possible sets of values.
        for (int i1 = 0; i1 < nPrimes - 4; i1++)
        {
            ulong p1 = primes[i1];
            // Console.WriteLine($"Testing first prime {p1}");

            for (int i2 = i1 + 1; i2 < nPrimes - 3; i2++)
            {
                ulong p2 = primes[i2];

                // Test p2.
                if (!AreConcatPrimes(p1, p2))
                {
                    continue;
                }

                for (int i3 = i2 + 1; i3 < nPrimes - 2; i3++)
                {
                    ulong p3 = primes[i3];

                    // Test p3.
                    if (!AreConcatPrimes(p1, p3))
                    {
                        continue;
                    }
                    if (!AreConcatPrimes(p2, p3))
                    {
                        continue;
                    }

                    for (int i4 = i3 + 1; i4 < nPrimes - 1; i4++)
                    {
                        ulong p4 = primes[i4];

                        // Test p4.
                        if (!AreConcatPrimes(p1, p4))
                        {
                            continue;
                        }
                        if (!AreConcatPrimes(p2, p4))
                        {
                            continue;
                        }
                        if (!AreConcatPrimes(p3, p4))
                        {
                            continue;
                        }

                        for (int i5 = i4 + 1; i5 < nPrimes; i5++)
                        {
                            ulong p5 = primes[i5];

                            // Test p5.
                            if (!AreConcatPrimes(p1, p5))
                            {
                                continue;
                            }
                            if (!AreConcatPrimes(p2, p5))
                            {
                                continue;
                            }
                            if (!AreConcatPrimes(p3, p5))
                            {
                                continue;
                            }
                            if (!AreConcatPrimes(p4, p5))
                            {
                                continue;
                            }

                            // Found a solution.
                            ulong sum = p1 + p2 + p3 + p4 + p5;
                            if (lowestSum == 0 || sum < lowestSum)
                            {
                                lowestSum = sum;
                                resultSet = new List<ulong> { p1, p2, p3, p4, p5 };
                            }

                        } // for i5
                    } // for i4
                } // for i3
            } // for i2
        } // for i1

        Console.WriteLine("Best set: " + string.Join(", ", resultSet));
        var combos = Factorials.GetCombinations(resultSet, 2);
        foreach (var combo in combos)
        {
            ulong num1 = ulong.Parse($"{combo[0]}{combo[1]}");
            ulong num2 = ulong.Parse($"{combo[1]}{combo[0]}");
            Console.WriteLine($"{num1} " + (Primes.IsPrime(num1) ? "is" : "is not") + " prime.");
            Console.WriteLine($"{num2} " + (Primes.IsPrime(num2) ? "is" : "is not") + " prime.");
        }

        return (long)lowestSum;
    }
}
