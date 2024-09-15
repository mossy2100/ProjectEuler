using Galaxon.Numerics.Algorithms.Dijkstra;

namespace Galaxon.ProjectEuler.Problems81To90;

/// <summary>
/// Path Sum: Three Ways
/// <see href="https://projecteuler.net/problem=82"/>
/// </summary>
public static class Problem82
{
    public static long Example()
    {
        int[,] matrix =
        {
            { 131, 673, 234, 103, 18 },
            { 201, 96, 342, 965, 150 },
            { 630, 803, 746, 422, 111 },
            { 537, 699, 497, 121, 956 },
            { 805, 732, 524, 37, 331 }
        };

        return (long)DijkstraSearch(matrix);
    }

    public static long Answer()
    {
        // Open file ProjectEuler/Problems81To90/0081_matrix.txt and read the matrix.
        string[] lines =
            File.ReadAllLines(
                "/Users/shaun/Documents/Web & software development/C#/Projects/ProjectEuler/ProjectEuler/Problems81To90/0082_matrix.txt");
        const int nRows = 80;
        const int nCols = 80;
        int[,] matrix = new int[nRows, nCols];

        // Parse the matrix.
        for (int row = 0; row < nRows; row++)
        {
            // Split the line into values.
            string[] values = lines[row].Split(',');

            // Parse the values into the matrix.
            for (int col = 0; col < nCols; col++)
            {
                matrix[row, col] = int.Parse(values[col]);
            }
        }

        // Find the minimum-cost path.
        return (long)DijkstraSearch(matrix);
    }

    public static double DijkstraSearch(int[,] matrix)
    {
        // Create a graph.
        Graph graph = new ();

        // Add the start and end nodes.
        string startNodeLabel = "start";
        string endNodeLabel = "end";
        Node startNode = graph.AddNode(startNodeLabel);
        Node endNode = graph.AddNode(endNodeLabel);

        // Copy the matrix into the graph.
        int nRows = matrix.GetLength(0);
        int nCols = matrix.GetLength(1);
        for (int row = 0; row < nRows; row++)
        {
            for (int col = 0; col < nCols; col++)
            {
                // Add the node to the graph.
                string currentNodeLabel = $"{row},{col}";
                graph.AddNode(currentNodeLabel);

                // Add the up- and down-direction edges that connect the current node to the one above it.
                // We can't add a single bidirectional edge because the cost of the move comes from
                // the value of the end node, and thus will be different for an up move vs. a down move.
                if (row > 0)
                {
                    string aboveNodeLabel = $"{row - 1},{col}";
                    graph.AddEdge(aboveNodeLabel, currentNodeLabel, matrix[row, col]);
                    graph.AddEdge(currentNodeLabel, aboveNodeLabel, matrix[row - 1, col]);
                }

                // Add the right-direction edges to the graph that lead to the current node.
                string leftNodeLabel = col == 0 ? startNodeLabel : $"{row},{col - 1}";
                graph.AddEdge(leftNodeLabel, currentNodeLabel, matrix[row, col]);

                // If we're in the last column, also add a zero-cost path to the end node.
                if (col == nCols - 1)
                {
                    graph.AddEdge(currentNodeLabel, endNodeLabel, 0);
                }
            }
        }

        // Set the initial "distance to start" of the start node.
        startNode.distanceFromStart = 0;

        // Run the search.
        graph.ShortestPath(startNodeLabel, endNodeLabel);

        // Return the distance from the start to the end node.
        return graph.GetNode(endNodeLabel)!.distanceFromStart;
    }
}
