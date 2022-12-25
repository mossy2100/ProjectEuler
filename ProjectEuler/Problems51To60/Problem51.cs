namespace Galaxon.ProjectEuler;

/// <summary>
/// Prime digit replacements.
/// <see href="https://projecteuler.net/problem=51" />
/// </summary>
public static class Problem51
{
    public static long Answer()
    {
        // Size of the family of primes we're looking for.
        const int familySize = 8;

        // Start with 5-digit numbers since the problem tells us the smallest prime that produces a
        // family of 7 has 5 digits.
        int nDigits = 5;

        while (true)
        {
            // Get max value with this many digits.
            uint max = (uint)Pow(10, nDigits) - 1;

            // Get all primes up to this value.
            List<ulong> primes = Primes.GetPrimesUpTo(max);

            // Check each number in this group looking for a match.
            foreach (long num in primes)
            {
                // Get the number as a string.
                string sNum = num.ToString().PadLeft(nDigits, '0');

                // Get the set of distinct digits in this number, which we can replace.
                char[] cDigits = sNum.Distinct().ToArray();

                // Try replacing each one.
                foreach (char c in cDigits)
                {
                    // Create the set of numbers to compare.
                    List<ulong> group = new();
                    for (char d = '0'; d <= '9'; d++)
                    {
                        string sNewNum = sNum.Replace(c, d);
                        ulong newNum = ulong.Parse(sNewNum);
                        if (Digits.NumDigits(newNum) == nDigits && Primes.IsPrime(newNum))
                        {
                            group.Add(newNum);
                        }
                    }

                    // If there are familySize primes in the set, we've found the answer.
                    if (group.Count == familySize)
                    {
                        return (long)group.First();
                    }
                }
            } // for min..max

            // Increment number of digits.
            nDigits++;

        } // while
    } // method
}
