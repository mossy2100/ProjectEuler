namespace Galaxon.ProjectEuler;

/// <summary>
/// Coin sums.
/// <see href="https://projecteuler.net/problem=31" />
/// </summary>
public static class Problem31
{
    private static readonly int[] Coins = { 1, 2, 5, 10, 20, 50, 100, 200 };

    private static List<CoinSet> GetCoinSets(int total, CoinSet? coinsSoFar = null)
    {
        List<CoinSet> result = new ();

        // Initialise the set of coins if necessary.
        coinsSoFar ??= new CoinSet();

        // Get the max value of the coins we want to consider for the next in the set.
        var max = coinsSoFar.Smallest ?? Coins[^1];

        // Consider possible next coins from largest to smallest.
        foreach (var coin in Coins.Reverse())
        {
            if (coin > total || coin > max)
            {
                continue;
            }

            // Clone the given coin set.
            CoinSet newCoinSet = new (coinsSoFar);

            // Add the new coin.
            newCoinSet.Add(coin);

            // Calculate the remainder.
            var rem = total - coin;

            // Are we done?
            if (rem == 0)
            {
                // Only the one result for this coin.
                result.Add(newCoinSet);
            }
            else
            {
                // Add other possible coin sets.
                result.AddRange(GetCoinSets(rem, newCoinSet));
            }
        }

        return result;
    }

    public static long Answer()
    {
        var coinSets = GetCoinSets(200);

        // DEBUG.
        foreach (var coinSet in coinSets)
        {
            coinSet.Print();
        }

        return coinSets.Count;
    }
}

public class CoinSet
{
    private readonly Dictionary<int, int> coins = new ();

    public CoinSet()
    {
    }

    public CoinSet(CoinSet coinSetToClone) =>
        coins = new Dictionary<int, int>(coinSetToClone.coins);

    public int? Smallest
    {
        get
        {
            if (coins.Count == 0)
            {
                return null;
            }
            int? smallest = null;
            foreach (var pair in coins)
            {
                if (smallest == null || pair.Key < smallest && pair.Value > 0)
                {
                    smallest = pair.Key;
                }
            }
            return smallest;
        }
    }

    public void Add(int coin)
    {
        if (!coins.ContainsKey(coin))
        {
            coins[coin] = 0;
        }
        coins[coin]++;
    }

    private static string CoinToString(KeyValuePair<int, int> coin)
    {
        var d = coin.Key >= 100 ? $"£{coin.Key / 100}" : $"{coin.Key}p";
        return $"{coin.Value}x{d}";
    }

    public void Print() =>
        Console.WriteLine(string.Join(", ", coins.Select(CoinToString)));
}
