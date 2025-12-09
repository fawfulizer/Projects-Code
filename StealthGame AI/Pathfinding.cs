using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a queue for the frontier and a set for reached nodes
        Queue<int> frontier = new Queue<int>();
        HashSet<int> reached = new HashSet<int>();

        // Assuming 'start' is defined earlier
        int start = 0; // Example start value
        frontier.Enqueue(start);
        reached.Add(start);

        while (frontier.Count > 0)
        {
            int current = frontier.Dequeue();

            // Assuming 'graph' is a predefined object with a method 'Neighbors'
            foreach (var next in Graph.Neighbors(current))
            {
                if (!reached.Contains(next))
                {
                    frontier.Enqueue(next);
                    reached.Add(next);
                }
            }
        }
    }
}

// Example Graph class to simulate neighbors (this part will depend on your actual graph structure)
public static class Graph
{
    public static IEnumerable<int> Neighbors(int node)
    {
        // Return neighbors based on your graph structure
        // Example: For simplicity, assuming a direct neighbor mapping
        var neighbors = new Dictionary<int, List<int>>()
        {
            { 0, new List<int> { 1, 2 } },
            { 1, new List<int> { 0, 3 } },
            { 2, new List<int> { 0, 3 } },
            { 3, new List<int> { 1, 2 } }
        };

        if (neighbors.ContainsKey(node))
        {
            return neighbors[node];
        }

        return new List<int>();
    }
}