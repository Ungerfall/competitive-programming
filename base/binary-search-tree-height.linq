<Query Kind="Program" />

void Main()
{
	var f = @"C:\temp-leonid-petrov\hackerrank\some-input.txt";
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
		int nodesCount = int.Parse(Console.ReadLine().Trim());
		var nodes = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
		Node root = null;
		for (int i = 0; i < nodesCount; i++)
		{
			root = InsertNode(root, nodes[i]);
		}

		if (root == null || (root.Left == null && root.Right == null))
		{
			Console.WriteLine(0);
			return;
		}

		var bsfQueue = new Queue<Node>();
		bsfQueue.Enqueue(root);
		int h = -1;
		while (bsfQueue.Count > 0)
		{
			h++;
			int levelSize = bsfQueue.Count;
			for (int i = 0; i < levelSize; i++)
			{
				var node = bsfQueue.Dequeue();
				if (node.Left != null)
				{
					bsfQueue.Enqueue(node.Left);
				}
				if (node.Right != null)
				{
					bsfQueue.Enqueue(node.Right);
				}
			}
		}

		Console.WriteLine(h);
	}

	static Node? InsertNode(Node? node, int value)
	{
		if (node == null)
		{
			return new Node(value);
		}
		if (value < node.Value)
		{
			node.Left = InsertNode(node.Left, value);
		}
		else if (value > node.Value)
		{
			node.Right = InsertNode(node.Right, value);
		}

		return node;
	}

	class Node
	{
		public Node(int v)
		{
			Value = v;
		}

		public int Value { get; }
		public Node? Left { get; set; }
		public Node? Right { get; set; }
	}
}
