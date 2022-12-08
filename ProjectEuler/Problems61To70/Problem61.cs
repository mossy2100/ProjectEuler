using System.Text.Json;

namespace AstroMultimedia.ProjectEuler;

/// <summary>
///
/// <see href="https://projecteuler.net/problem=61" />
/// </summary>
public static class Problem61
{
    private const int _MIN = 11;
    private const int _MAX = 99;

    /// <summary>
    /// Given a current problem state and a candidate next 2-digit number, find any possible
    /// valid subsequent problem states.
    /// </summary>
    public static List<Problem61State> FindNextStates(Problem61State currentState, int x1)
    {
        List<Problem61State> nextStates = new ();

        // Test for each side length.
        for (int s = 3; s <= 8; s++)
        {
            // Only test for the side lengths we haven't found a match for yet.
            if (currentState.ResultSoFar[s - 3] == 0)
            {
                // Generate the 4-digit number.
                int x0 = currentState.TwoDigitNums[currentState.Iteration];
                int x = x0 * 100 + x1;

                // Check if it's polygonal.
                bool isPolygonal = PolygonalNumbers.IsPolygonal(s, (ulong)x);

                // If so, construct the new problem state and add it to the results.
                if (isPolygonal)
                {
                    Problem61State state = currentState.Clone();
                    state.ResultSoFar[s - 3] = x;
                    state.Iteration = currentState.Iteration + 1;
                    state.TwoDigitNums[state.Iteration] = x1;
                    nextStates.Add(state);
                }
            }
        }

        // Return the new list of problem states.
        return nextStates;
    }

    public static long Answer()
    {
        // Create initial states, one for each possible starting number, from 11..99.
        List<Problem61State> newResults = new ();
        for (int x0 = _MIN; x0 <= _MAX; x0++)
        {
            Problem61State state = new ();
            state.TwoDigitNums[0] = x0;
            newResults.Add(state);
        }

        // Run 6 iterations of testing for valid future problem states.
        List<Problem61State> results;
        for (int i = 0; i < 6; i++)
        {
            results = newResults.ToList();
            newResults = new List<Problem61State>();
            foreach (Problem61State result in results)
            {
                for (int x1 = _MIN; x1 <= _MAX; x1++)
                {
                    List<Problem61State> states = FindNextStates(result, x1);
                    newResults.AddRange(states);
                }
            }
        }

        // Finally, filter for results where the first 2-digit number matches the last one.
        results = newResults
            .Where(state => state.TwoDigitNums[0] == state.TwoDigitNums[6])
            .ToList();
        // There are 6 results, but they are actually all the same, just starting with different
        // numbers in the group.
        // I could optimize this further to avoid duplicates but the method is pretty fast.

        // Return the sum of the values in the first one.
        return results[0].ResultSoFar.Sum();
    }
}

public class Problem61State
{
    // Array to hold the result so far. Index is size - 3.
    public readonly int[] ResultSoFar = new int[6];

    // Array to hold the 2-digit numbers in the sequence.
    public readonly int[] TwoDigitNums = new int[7];

    // The current iteration, 0..6.
    public int Iteration;

    /// <summary>
    /// Useful for debugging.
    /// </summary>
    public override string ToString() =>
        JsonSerializer.Serialize(ResultSoFar) + JsonSerializer.Serialize(TwoDigitNums)
        + Iteration;

    public Problem61State Clone()
    {
        Problem61State clone = new ();
        ResultSoFar.CopyTo(clone.ResultSoFar, 0);
        TwoDigitNums.CopyTo(clone.TwoDigitNums, 0);
        clone.Iteration = Iteration;
        return clone;
    }
}
