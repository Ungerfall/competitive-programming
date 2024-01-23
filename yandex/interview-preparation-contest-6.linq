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
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Program
{
	public class Program
	{
		public static void Main(string[] args)
		{
#if LINQPAD
			string linqpadInput =
"""
4
0 0
2 0
0 2
2 2
1
1 4
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int n = Scanner.Int();
			(int row, int col)[] v = new (int row, int col)[n];
			for (int i = 0; i < n; i++)
			{
				var pair = Scanner.IntInt();
				v[i] = pair;
			}
			
			int k = Scanner.Int();
			var (start, end) = Scanner.IntInt();
			start--;
			end--;
			var bfs = new Queue<(int town, int len)>();
			var visited = new bool[n];
			bfs.Enqueue((start, 0));
			int best = int.MaxValue;
			while (bfs.Count > 0)
			{
				var (curTown, curLen) = bfs.Dequeue();
				visited[curTown] = true;
				if (curTown == end)
				{
					best = Math.Min(best, curLen);
				}
				
				for (int i = 0; i < n; i++)
				{
					if (visited[i])
					{
						continue;
					}
					
					long dist = Math.Abs(v[curTown].row - v[i].row) + Math.Abs(v[curTown].col - v[i].col);
					if (dist > k)
					{
						continue;
					}
					
					bfs.Enqueue((i, curLen + 1));
				}
			}
			
			Console.WriteLine(best == int.MaxValue ? -1 : best);
		}
	}

	public static class Scanner
	{
		public static string String() => Console.ReadLine().Trim();
		public static int Int() => int.Parse(Console.ReadLine().Trim());
		public static long Long() => long.Parse(Console.ReadLine().Trim());
		public static (int, int) IntInt()
		{
			int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			Debug.Assert(line.Length == 2);
			return (line[0], line[1]);
		}
		public static (int, int, int) IntIntInt()
		{
			int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			Debug.Assert(line.Length == 3);
			return (line[0], line[1], line[2]);
		}
		public static T[] Array<T>() => Console.ReadLine().Trim()
			.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
			.Select(x => (T)Convert.ChangeType(x, typeof(T)))
			.ToArray();
	}
}
