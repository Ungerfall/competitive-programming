namespace Program
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine().Trim());
			for (int i = 0; i < n; i++)
			{
				int len = int.Parse(Console.ReadLine().Trim());
				int[] arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				LinkedList<int> linkedList = new LinkedList<int>();
				foreach (int item in arr)
				{
					linkedList.AddLast(item);
				}
				int operations = 0;
				int prevOperations = 0;
				do
				{
					prevOperations = operations;
					LinkedListNode<int> currentNode = linkedList.First;
					while (currentNode != null)
					{
						if (currentNode.Next != null && currentNode.Value > currentNode.Next.Value)
						{
							operations++;
							int splitPrev = currentNode.Value / 2;
							int split = currentNode.Value - splitPrev;
							linkedList.AddBefore(currentNode, splitPrev);
							var after = linkedList.AddAfter(currentNode, split);
							linkedList.Remove(currentNode);
							currentNode = after;
						}
						else
						{
							currentNode = currentNode.Next;
						}
					}
				}
				while (operations > prevOperations);

				Console.WriteLine(operations);
			}
		}
	}
}

