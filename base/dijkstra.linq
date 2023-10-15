<Query Kind="Program" />

void Main()
{
	var inputFile = "path/to/file";
	using (StringReader simulatedInput = new StringReader(File.ReadAllText(inputFile)))
	{
		Console.SetIn(simulatedInput);
		GFG.Main(null);
	}
}

class GFG
{
	public static void Main(string[] args)
	{
		int testcases;// Taking testcase as input
		testcases = Convert.ToInt32(Console.ReadLine());
		while (testcases-- > 0)// Looping through all testcases
		{
			var ip = Console.ReadLine().Trim().Split(' ');
			int V = int.Parse(ip[0]);
			int E = int.Parse(ip[1]);
			List<List<List<int>>> adj = new List<List<List<int>>>();
			for (int i = 0; i < V; i++)
			{
				adj.Add(new List<List<int>>());
			}
			for (int i = 0; i < E; i++)
			{
				ip = Console.ReadLine().Trim().Split(' ');
				int u = int.Parse(ip[0]);
				int v = int.Parse(ip[1]);
				int w = int.Parse(ip[2]);

				adj[u].Add(new List<int>() { v, w });
				adj[v].Add(new List<int>() { u, w });
			}
			int S = Convert.ToInt32(Console.ReadLine());
			Solution obj = new Solution();
			var res = obj.dijkstra(V, ref adj, S);
			foreach (int i in res)
			{
				Console.Write(i + " ");
			}
			Console.WriteLine();
		}
	}
}
}

class Solution
{
	//Function to find the shortest distance of all the vertices
	//from the source vertex S.
	public List<int> dijkstra(int V, ref List<List<List<int>>> adj, int S)
	{
		if (V <= 1)
		{
			return new List<int> { 0 };
		}

		var visited = new HashSet<int>();
		visited.Add(S);
		var dist = new int[V];
		for (int i = 0; i < V; i++)
		{
			dist[i] = int.MaxValue;
		}
		dist[S] = 0;
		var heap = new SortedDictionary<int, Queue<int>>()
		{
			[0] = new Queue<int>(),
		};
		heap[0].Enqueue(S);
		while (heap.Count > 0)
		{
			var minNode = heap.First();
			var minLenght = minNode.Key;
			var minNodeId = minNode.Value.Dequeue();
			if (minNode.Value.Count == 0)
			{
				heap.Remove(minLenght);
			}

			var currentDistance = dist[minNodeId];
			foreach (List<int> adjNode in adj[minNodeId])
			{
				var adjNodeId = adjNode[0];
				var adjNodeDistance = adjNode[1] + currentDistance;
				if (adjNodeDistance < dist[adjNodeId])
				{
					dist[adjNodeId] = adjNodeDistance;
					if (!visited.Contains(adjNodeId))
					{
						if (!heap.ContainsKey(adjNodeDistance))
						{
							heap[adjNodeDistance] = new Queue<int>();
						}

						heap[adjNodeDistance].Enqueue(adjNodeId);
					}
				}
			}

			visited.Add(minNodeId);
		}

		return dist.ToList();
	}
}
