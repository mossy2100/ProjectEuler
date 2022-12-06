using AstroMultimedia.Numerics.Types;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
/// Digit cancelling fractions.
/// <see href="https://projecteuler.net/problem=33" />
/// </summary>
public static class Problem33
{
    public static long Answer()
    {
        long nProd = 1;
        long dProd = 1;

        // Check every possible 2-digit numerator.
        for (int n = 11; n <= 98; n++)
        {
            // The denominator must be greater than the numerator since the problem specifies
            // "less than 1 in value".
            for (int d = n + 1; d <= 99; d++)
            {
                bool match = false;

                // Calculate the quotient. Use decimal for accuracy.
                decimal q1 = (decimal)n / d;

                // Get the digits as separate values.
                int n1 = n / 10;
                int n2 = n % 10;
                int d1 = d / 10;
                int d2 = d % 10;

                // Skip the trivial matches.
                if (n2 == 0 && d2 == 0)
                {
                    continue;
                }

                // Look for common digits in the numerator and denominator.

                // Case 1: the tens digit in the numerator matches the tens digit in the denominator.
                if (n1 == d1 && d2 != 0)
                {
                    decimal q2 = (decimal)n2 / d2;
                    if (q1 == q2)
                    {
                        match = true;
                        Console.WriteLine($"Case 1: Found a match {n}/{d} == {n2}/{d2}");
                    }
                }

                // Case 2: the tens digit in the numerator matches the units digit in the denominator.
                if (n1 == d2 && d1 != 0)
                {
                    decimal q2 = (decimal)n2 / d1;
                    if (q1 == q2)
                    {
                        match = true;
                        Console.WriteLine($"Case 2: Found a match {n}/{d} == {n2}/{d1}");
                    }
                }

                // Case 3: the units digit in the numerator matches the tens digit in the denominator.
                // Interestingly, this is the only case that produces matches.
                if (n2 == d1 && d2 != 0)
                {
                    decimal q2 = (decimal)n1 / d2;
                    if (q1 == q2)
                    {
                        match = true;
                        Console.WriteLine($"Case 3: Found a match {n}/{d} == {n1}/{d2}");
                    }
                }

                // Case 4: the units digit in the numerator matches the units digit in the denominator.
                if (n2 == d2 && d1 != 0)
                {
                    decimal q2 = (decimal)n1 / d1;
                    if (q1 == q2)
                    {
                        match = true;
                        Console.WriteLine($"Case 4: Found a match {n}/{d} == {n1}/{d1}");
                    }
                }

                if (match)
                {
                    nProd *= n;
                    dProd *= d;
                }
            }
        }

        Fraction f = new (nProd, dProd);
        Console.WriteLine($"The product is {nProd}/{dProd}, which simplifies to {f.Numerator}/{f.Denominator}");

        return (long)f.Denominator;
    }
}
