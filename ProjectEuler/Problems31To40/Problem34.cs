namespace AstroMultimedia.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=" />
/// </summary>
public static class Problem34
{
    public static long Answer()
    {
        long result = 0;

        // Cache this value to speed up calculation of max factorial sum for n-digit number.
        long factorial9 = (long)Factorials.Factorial(9);

        // We need at least 2 digits in the value being checked or it won't be a sum.
        int nDigits = 2;

        // Initial min value to check.
        int min = 10;

        while (true)
        {
            // Get max value for numbers with this many digits.
            long max = min * 10 - 1;
            Console.WriteLine($"Checking {nDigits}-digit numbers. From {min} to {max}");

            // Calculate the maximum factorial sum for numbers with this many digits.
            long maxSum = factorial9 * nDigits;
            Console.WriteLine($"Maximum factorial sum of digits is {maxSum}");

            // If the smallest value with this many digits is larger than the maximum factorial sum,
            // we can stop.
            if (min > maxSum)
            {
                break;
            }

            // Check values.
            for (long i = min; i <= max; i++)
            {
                int[] digits = i.ToString().ToCharArray().Select(c => c - '0').ToArray();
                List<long> factorials = digits.Select(digit => (long)Factorials.Factorial(digit)).ToList();
                long sum = factorials.Sum();
                if (i == sum)
                {
                    result += i;
                    string digitString = string.Join(" + ", digits.Select(d => $"{d}!"));
                    string factorialsString = string.Join(" + ", factorials);
                    Console.WriteLine($"Match: {digitString} = {factorialsString} = {i}");
                }
            }

            nDigits++;
            min *= 10;
        }

        return result;
    }
}
