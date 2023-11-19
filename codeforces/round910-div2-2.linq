<Query Kind="Program">
  <RemoveNamespace>System</RemoveNamespace>
  <RemoveNamespace>System.Collections</RemoveNamespace>
  <RemoveNamespace>System.Collections.Generic</RemoveNamespace>
  <RemoveNamespace>System.Data</RemoveNamespace>
  <RemoveNamespace>System.Diagnostics</RemoveNamespace>
  <RemoveNamespace>System.IO</RemoveNamespace>
  <RemoveNamespace>System.Linq</RemoveNamespace>
  <RemoveNamespace>System.Linq.Expressions</RemoveNamespace>
  <RemoveNamespace>System.Reflection</RemoveNamespace>
  <RemoveNamespace>System.Text</RemoveNamespace>
  <RemoveNamespace>System.Text.RegularExpressions</RemoveNamespace>
  <RemoveNamespace>System.Threading</RemoveNamespace>
  <RemoveNamespace>System.Transactions</RemoveNamespace>
  <RemoveNamespace>System.Xml</RemoveNamespace>
  <RemoveNamespace>System.Xml.Linq</RemoveNamespace>
  <RemoveNamespace>System.Xml.XPath</RemoveNamespace>
</Query>

void Main()
{
	Program.Program.Main(null);
}

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

