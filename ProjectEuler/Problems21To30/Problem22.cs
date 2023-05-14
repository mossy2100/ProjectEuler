using Galaxon.Numerics.Integers;

namespace Galaxon.ProjectEuler;

/// <summary>
///     <see href="https://projecteuler.net/problem=22" />
/// </summary>
public static class Problem22
{
    public static long Answer()
    {
        // Load the names file into an array of names.
        var dataFilePath = Utility.GetDataFilePath("p022_names.txt");
        var text = File.ReadAllText(dataFilePath);

        // Sort the array.
        var names = text.Split(",").ToList();
        names = names.Select(n => n.Trim().Trim('"')).ToList();
        names.Sort();

        // Calculate the name score for each name.
        var position = 0;
        long total = 0;
        foreach (var name in names)
        {
            position++;
            var value = NumberStrings.GetAlphabeticalValue(name);
            var score = position * value;
            total += score;
        }
        return total;
    }
}
