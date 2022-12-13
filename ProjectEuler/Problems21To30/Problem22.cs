namespace AstroMultimedia.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=22" />
/// </summary>
public static class Problem22
{
    public static long Answer()
    {
        // Load the names file into an array of names.
        string dataFilePath = Utility.GetDataFilePath("p022_names.txt");
        string text = File.ReadAllText(dataFilePath);

        // Sort the array.
        List<string> names = text.Split(",").ToList();
        names = names.Select(n => n.Trim().Trim('"')).ToList();
        names.Sort();

        // Calculate the name score for each name.
        int position = 0;
        long total = 0;
        foreach (string name in names)
        {
            position++;
            int value = NumberStrings.GetAlphabeticalValue(name);
            int score = position * value;
            total += score;
        }
        return total;
    }
}
