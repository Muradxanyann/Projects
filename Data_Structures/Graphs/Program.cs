class Graph
{
    private Dictionary<int, List<int>> graph = new();
    public readonly bool IsWeighted;
    public readonly bool IsDirected;
    public int Size { get; private set; } = 0;
    public Graph(bool isWeighted = false, bool isDirected = false)
    {
        this.IsWeighted = isWeighted;
        this.IsDirected = isDirected;
    }

    public void AddVertex(int vertex)
    {
        if (graph.ContainsKey(vertex)) return;
        graph.Add(vertex, new List<int>());
        Size++;
    }
    public void AddEdge(int from, int to)
    {
        if (!graph.ContainsKey(from) || (!graph.ContainsKey(to))) return;
        if (IsDirected)
            graph[from].Add(to);
        else
        {
            graph[from].Add(to);
            graph[to].Add(from);
        }
    }

    public void Dfs(int start)
    {
        HashSet<int> visited = new();
        foreach (var node in graph.Keys)
        {
            if (!visited.Contains(node))
            {
                DfsHelper(node, visited);
            }
        }

    }
    private void DfsHelper(int start, HashSet<int> visited)
    {
        if (!graph.ContainsKey(start)) return;


        Stack<int> stack = new();
        visited.Add(start);
        stack.Push(start);

        while (stack.Count > 0)
        {
            var node = stack.Pop();
            Console.WriteLine(node);
            foreach (var neighbour in graph[node])
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    stack.Push(neighbour);
                }
            }
        }
    }
    public void Bfs(int start)
    {
        HashSet<int> visited = new();
        foreach (var node in graph.Keys)
        {
            if (!visited.Contains(node))
            {
                DfsHelper(node, visited);
            }
        }

    }
    void BfsHelper(int start, HashSet<int> visited)
    {
        var queue = new Queue<int>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
    public int GetShortestWay(int start, int end)
    {
        if (start < 0 || end < 0)
            throw new ArgumentOutOfRangeException($"The argument {start} || {end} cant be negative");
        int level = 1;
        Queue<int> queue = new();
        HashSet<int> visited = new();

        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                var node = queue.Dequeue();
                foreach (var neighbor in graph[node])
                {
                    if (neighbor == end) return level + 1;
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
            level++;
        }
        return -1;
    }

    public bool CanReach(int start, int end)
    {
        if (start == end) return true;
        var visited = new HashSet<int>();
        var queue = new Queue<int>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            Console.WriteLine(node);
            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    if (neighbor == end) return true;
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
        return false;
    }

    public bool HasCycle(int start)
    {
        HashSet<int> visited = new();
        bool[] onStack = new bool[Size];
        bool hasCycle = false;

        foreach (var key in graph.Keys)
        {
            if (!visited.Contains(key))
            {
                if (IsDirected) //for Directed graph case
                {
                    if (HasCycleInDirected(key, graph, visited, onStack))
                    {
                        hasCycle = true;
                        break;
                    }
                }
                else //for Undirected graph case
                {
                    if (HasCycleInUndirected(key, graph, visited, null))
                    {
                        hasCycle = true;
                        break;
                    }
                }

            }
        }
        return hasCycle;
    }

    private bool HasCycleInUndirected(int start, Dictionary<int, List<int>> graph, HashSet<int> visited, int? parent)
    {
        visited.Add(start);

        foreach (var node in graph[start])
        {
            if (!visited.Contains(node))
            {
                if (HasCycleInUndirected(node, graph, visited, start))
                    return true;
            }
            else if (node != parent)
                return true;
        }
        return false;
    }

    private bool HasCycleInDirected(int start, Dictionary<int, List<int>> graph, HashSet<int> visited, bool[] onStack)
    {
        visited.Add(start);
        onStack[start] = true;
        foreach (var node in graph[start])
        {
            if (!visited.Contains(node))
            {

                if (HasCycleInDirected(node, graph, visited, onStack))
                    return true;
            }
            else if (onStack[node])
                return true;
        }
        onStack[start] = false;
        return false;
    }

    public List<List<int>> GetAllPossiblePaths(int u, int v)
    {
        List<List<int>> res = new();
        HashSet<int> visited = new();
        List<int> temp = new();
        Helper(u, v, visited, temp, res);
        return res;
    }

    private void Helper(int u, int v, HashSet<int> visited, List<int> temp, List<List<int>> res)
    {
        visited.Add(u);
        temp.Add(u);
        if (u == v)
            res.Add([.. temp]); // adding the copy of temp
        else
        {
            foreach (var node in graph[u])
            {
                if (!visited.Contains(node))
                {
                    Helper(node, v, visited, temp, res);
                }
            }
        }
        visited.Remove(u);
        temp.Remove(temp.Count - 1);
    }
}

static class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        graph.AddVertex(1);
        graph.AddVertex(2);
        graph.AddVertex(3);
        graph.AddVertex(4);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 4);
        Console.WriteLine(graph.GetShortestWay(1, 4));


    }
}