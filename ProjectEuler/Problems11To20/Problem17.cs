using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Number letter counts.
/// <see href="https://projecteuler.net/problem=17" />
/// </summary>
public static class Problem17
{
    public static void Test()
    {
        Random rand = new();
        for (int i = 0; i < 100; i++)
        {
            uint n = (uint)rand.Next();
            string words = NumberStrings.NumberToWords(n);
            int letterCount = NumberStrings.LetterCount(words);
            Console.WriteLine($"{n} = {words} ({letterCount} letters).");
        }
    }

    public static long Answer()
    {
        long total = 0;
        for (uint i = 1; i <= 1000; i++)
        {
            total += NumberStrings.LetterCount(NumberStrings.NumberToWords(i));
        }
        return total;
    }
}
