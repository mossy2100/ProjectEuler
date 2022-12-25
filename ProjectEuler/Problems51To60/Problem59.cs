using System.Text;
using System.Text.RegularExpressions;

namespace Galaxon.ProjectEuler;

/// <summary>
/// XOR decryption.
/// <see href="https://projecteuler.net/problem=59" />
/// </summary>
public static class Problem59
{
    public static long Answer()
    {
        // Load the values into an array.
        string dataFilePath = Utility.GetDataFilePath("p059_cipher.txt");
        string text = File.ReadAllText(dataFilePath);
        List<char> encoded = text.Split(",").Select(ascii => (char)byte.Parse(ascii)).ToList();

        // Test each possible key. Look for the one that produces the most words.
        int maxNWords = 0;
        int sumCodes = 0;
        for (char c1 = 'a'; c1 <= 'z'; c1++)
        {
            for (char c2 = 'a'; c2 <= 'z'; c2++)
            {
                for (char c3 = 'a'; c3 <= 'z'; c3++)
                {
                    string key = $"{c1}{c2}{c3}";

                    // Decode the message using this key.
                    // If we find an invalid character, stop.
                    List<char> decoded = new(encoded.Count);
                    bool looksOk = true;
                    for (int i = 0; i < encoded.Count; i++)
                    {
                        char ch = (char)(encoded[i] ^ key[i % 3]);
                        // Fail on non-printable characters.
                        if (ch is < (char)32 or > (char)126)
                        {
                            // Console.WriteLine($"Key '{key}' fails on char '{ch}' ({(byte)ch}).");
                            looksOk = false;
                            break;
                        }
                        decoded.Add(ch);
                    }

                    if (looksOk)
                    {
                        // Possible solution found.
                        // Console.WriteLine($"Key '{key}' passes.");

                        // Decode the original text.
                        StringBuilder sb = new();
                        decoded.ForEach(d => sb.Append(d));
                        string originalText = sb.ToString();

                        // How many words? This regex only counts words as being surrounded by
                        // spaces. Thus it won't find words surrounded by quotes, or next to
                        // punctuation characters, or numbers, but it produces a correct answer
                        // regardless
                        MatchCollection matches = Regex
                            .Matches(originalText, @" [a-z]+ ", RegexOptions.IgnoreCase);
                        int nWords = matches.Count;

                        if (nWords > maxNWords)
                        {
                            // Console.WriteLine($"Most words so far:  {nWords}");
                            // Console.WriteLine(originalText);
                            // Console.WriteLine();
                            // Console.ReadLine();

                            sumCodes = decoded.Aggregate(0, (sum, ch) => sum + ch);
                            maxNWords = nWords;
                        }
                    }

                }
            }
        }

        return sumCodes;
    }
}
