namespace Galaxon.ProjectEuler;

/// <summary>
/// Even Fibonacci numbers.
/// <see href="https://projecteuler.net/problem=2" />
/// </summary>
public static class Problem2
{
    public static long Answer()
    {
        var a = 0;
        var b = 1;
        var sum = 0;
        while (true)
        {
            // Get the next number.
            var c = a + b;

            // Check if we're done.
            if (c > 4000000)
            {
                break;
            }

            // Add it if even.
            if (c % 2 == 0)
            {
                sum += c;
            }

            // Prepare for the next loop iteration.
            a = b;
            b = c;
        }

        return sum;
    }
}
