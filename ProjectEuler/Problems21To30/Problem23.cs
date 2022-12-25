namespace Galaxon.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=23" />
/// </summary>
public static class Problem23
{
    public static long Answer()
    {
        // All integers greater than this number can be written as the sum of 2 abundant numbers.
        const int max = 28123;

        // Get all abundant numbers <= max.
        List<int> abundantNumbers = new();
        for (int i = 1; i <= max; i++)
        {
            if (Divisors.PerfectNumber(i) == 1)
            {
                abundantNumbers.Add(i);
            }
        }

        // Look for numbers that cannot be written as the sum of two abundant numbers.
        long sum = 0;
        for (int i = 1; i <= max; i++)
        {
            bool isSumOf2AbundantNums = false;
            foreach (int a in abundantNumbers)
            {
                if (a > i / 2)
                {
                    break;
                }

                int b = i - a;
                if (!abundantNumbers.Contains(b))
                {
                    continue;
                }

                isSumOf2AbundantNums = true;
                // Console.WriteLine($"{i} = {a} + {b}");
                break;
            }

            if (!isSumOf2AbundantNums)
            {
                // The value i cannot be written as a sum of two abundant numbers.
                // Add it to the total.
                sum += i;
            }
        }

        return sum;
    }
}
