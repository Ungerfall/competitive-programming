<Query Kind="Program" />

void Main()
{
	//	var f = @"C:\temp-leonid-petrov\hackerrank\hr-testcases-us-east-1.s3.amazonaws.com_24105_input01.txt_response-content-type=text2F202309302Fs3%2Faws4_request&X-Amz-D.txt";
	var f = @"C:\temp-leonid-petrov\hackerrank\hr-testcases-us-east-1.s3.amazonaws.com_24105_input05.txt_response-content-type=text2F202309302Fs3%2Faws4_request&X-Amz-Date=2023.txt";
	using (StringReader simulatedInput = new StringReader(File.ReadAllText(f)))
	{
		Console.SetIn(simulatedInput);
		Solution.Main(null);
	}
}

class Solution
{
	public static void Main(String[] args)
	{
		/* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
		/*
        2
4 2
1 2
1 3
1
3 1
2 3
2
        */
		var graphCount = int.Parse(Console.ReadLine().Trim());
		for (int i = 0; i < graphCount; i++)
		{
			SolveForAGraph();
		}
	}
	static void SolveForAGraph()
	{
		int start;
		var line = Console.ReadLine().Trim().Split();
		var nodesCount = int.Parse(line[0]);
		var edgesCount = int.Parse(line[1]);
		var graph = new List<int>[nodesCount + 1];
		var dist = new int[nodesCount + 1];
		for (int i = 1; i <= nodesCount; i++)
		{
			dist[i] = -1;
			graph[i] = new List<int>();
		}
		while (true)
		{
			line = Console.ReadLine().Trim().Split();
			if (line.Length == 1)
			{
				start = int.Parse(line[0]);
				dist[start] = 0;
				break;
			}

			var node = int.Parse(line[0]);
			var adjNode = int.Parse(line[1]);
			graph[node].Add(adjNode);
			graph[adjNode].Add(node);
		}

		var bfsQueue = new Queue<NodeVisit>();
		bfsQueue.Enqueue(new NodeVisit { Node = start, DistanceFromStart = 0 });
		var visited = new HashSet<int>();
		visited.Add(start);
		while (bfsQueue.Count > 0)
		{
			var currentNode = bfsQueue.Peek().Node;
			var distance = bfsQueue.Peek().DistanceFromStart;
			if (dist[currentNode] == -1 || dist[currentNode] > distance)
			{
				dist[currentNode] = distance;
			}
			bfsQueue.Dequeue();
			foreach (int adj in graph[currentNode])
			{
				if (!visited.Contains(adj))
				{
					bfsQueue.Enqueue(new NodeVisit { Node = adj, DistanceFromStart = distance + 1 });
					visited.Add(adj);
				}
			}
		}

		Console.WriteLine(string.Join(
			' ',
			dist
				.Where((v, i) => i != start && i != 0)
				.Select(x => x == -1 ? x : x * 6)
		));
	}

	class NodeVisit
	{
		public int Node { get; set; }
		public int DistanceFromStart { get; set; }
	}
}

