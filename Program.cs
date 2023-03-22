namespace MinimumScorePathBetweenTwoCities
{
    internal class Program
    {
        public class MinimumScorePathBetweenTwoCities
        {
            private class Node
            {
                public readonly int vertex;
                public readonly int distance;

                public Node(int vertex, int distance)
                {
                    this.vertex = vertex;
                    this.distance = distance;
                }
            }

            public int MinScore(int n, int[][] roads)
            {
                Dictionary<int, List<Node>> graph = new();
                foreach (int[] road in roads)
                {
                    int road1 = road[0];
                    int road2 = road[1];
                    int distance = road[2];
                    if (!graph.ContainsKey(road1))
                        graph[road1] = new List<Node>();
                    if (!graph.ContainsKey(road2))
                        graph[road2] = new List<Node>();
                    graph[road1].Add(new Node(road2, distance));
                    graph[road2].Add(new Node(road1, distance));
                }
                int minScore = int.MaxValue;
                HashSet<int> visited = new();
                Queue<int> queue = new();
                queue.Enqueue(1);
                while(queue.Count > 0)
                {
                    int node = queue.Dequeue();
                    if (visited.Contains(node))
                        continue;
                    visited.Add(node);
                    foreach(Node neighbor in graph[node])
                    {
                        minScore = Math.Min(minScore, neighbor.distance);
                        queue.Enqueue(neighbor.vertex);
                    }
                }
                return minScore;
            }
        }
        static void Main(string[] args)
        {
            MinimumScorePathBetweenTwoCities minimumScorePathBetweenTwoCities = new();
            Console.WriteLine(minimumScorePathBetweenTwoCities.MinScore(4, new int[][]
            {
                new int[] { 1, 2, 9 },
                new int[] { 2, 3, 6 },
                new int[] { 2, 4, 5 },
                new int[] { 1, 4, 7 }
            }));
            Console.WriteLine(minimumScorePathBetweenTwoCities.MinScore(4, new int[][]
            {
                new int[] { 1, 2, 2 },
                new int[] { 1, 3, 4 },
                new int[] { 3, 4, 7 }
            }));
        }
    }
}