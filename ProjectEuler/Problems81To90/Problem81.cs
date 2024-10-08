using Galaxon.Numerics.Algorithms.Dijkstra;

namespace Galaxon.ProjectEuler.Problems81To90;

/// <summary>
/// Path Sum: Two Ways
/// <see href="https://projecteuler.net/problem=81"/>
/// </summary>
public static class Problem81
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
                "/Users/shaun/Documents/Web & software development/C#/Projects/ProjectEuler/ProjectEuler/Problems81To90/0081_matrix.txt");
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
        // Convert the matrix into a graph.
        Graph graph = new ();
        int nRows = matrix.GetLength(0);
        int nCols = matrix.GetLength(1);
        for (int row = 0; row < nRows; row++)
        {
            for (int col = 0; col < nCols; col++)
            {
                // Add the node to the graph.
                string currentNodeLabel = $"{row},{col}";
                graph.AddNode(currentNodeLabel);

                // Add the edges to the graph that lead to the current node.
                if (row > 0)
                {
                    string prevRowNodeLabel = $"{row - 1},{col}";
                    graph.AddEdge(prevRowNodeLabel, currentNodeLabel, matrix[row, col]);
                }

                if (col > 0)
                {
                    string prevColNodeLabel = $"{row},{col - 1}";
                    graph.AddEdge(prevColNodeLabel, currentNodeLabel, matrix[row, col]);
                }
            }
        }

        // Set the initial "distance to start" of the start node.
        string startNodeLabel = "0,0";
        Node startNode = graph.GetNode(startNodeLabel)!;
        startNode.distanceFromStart = matrix[0, 0];

        // Run the search.
        string endNodeLabel = $"{nRows - 1},{nCols - 1}";
        graph.ShortestPath(startNodeLabel, endNodeLabel);

        // Return the distance from the start to the end node.
        return graph.GetNode(endNodeLabel)!.distanceFromStart;
    }
}
