using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
/// Coded triangle numbers.
/// <see href="https://projecteuler.net/problem=42"/>
/// </summary>
public static class Problem42
{
    public static long Answer()
    {
        // Load the words file into an array of words.
        string dataFilePath = Utility.GetDataFilePath("p042_words.txt");
        string text = File.ReadAllText(dataFilePath);
        var words = text.Split(",").ToList();
        words = words.Select(n => n.Trim().Trim('"')).ToList();

        // Get the length of the longest word.
        int maxLen = words.Select(word => word.Length).Max();

        // Calculate the max word value.
        var maxValue = (uint)NumberStrings.GetAlphabeticalValue(new string('z', maxLen));

        // Get all triangle numbers up to maxValue.
        ulong[] triangularNums = Polygonal.GetAllTriangularUpTo(maxValue);

        // Count the number of words with a value that is a triangle number.
        return words.Select(NumberStrings.GetAlphabeticalValue)
            .Count(value => Array.Exists(triangularNums, n => n == (ulong)value));
    }
}
