namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Digit fifth powers.
/// <see href="https://projecteuler.net/problem=30" />
/// </summary>
public static class Problem30
{
    public static long Answer()
    {
        long total = 0;
        const int power = 5;

        // Get 5th powers of each digit. Cache for speed.
        int[] fifthPowersOfDigits = new int[10];
        for (int i = 0; i < 10; i++)
        {
            fifthPowersOfDigits[i] = (int)Pow(i, power);
        }

        int minNDigitNum = 1;
        // Start with 2 digit numbers or it won't be a sum. End with 6-digit numbers because any 7
        // digit number will be larger than the maximum possible sum.
        for (int nDigits = 2; nDigits <= 6; nDigits++)
        {
            // Get min and max number with this many digits.
            minNDigitNum *= 10;
            int maxNDigitNum = minNDigitNum * 10 - 1;

            // Get max sum of 5th powers of digits for numbers with d digits.
            // (Min sum will always be 1, e.g. for 10, 100, etc. == 1+0+...)
            int maxSum = fifthPowersOfDigits[9] * nDigits;

            // Get the min and max value to check.
            int min = minNDigitNum;
            int max = Min(maxSum, maxNDigitNum);

            // Check these values.
            for (int n = min; n <= max; n++)
            {
                int sum = n.ToString().ToCharArray().Sum(c => fifthPowersOfDigits[c - '0']);
                // Console.WriteLine($"The sum of each digit in {n} to the power of {power} is {sum}.");
                if (n == sum)
                {
                    // Console.WriteLine($"{n} EQUAL!");
                    total += n;
                }
            }
        }

        return total;
    }
}
