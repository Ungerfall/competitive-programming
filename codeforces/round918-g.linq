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

// copy template to destination `cp template.linq problem123.linq`
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
3
5 5
1 2 2
3 2 1
2 4 5
2 5 7
4 5 1
5 2 1 3 3
5 10
1 2 5
1 3 5
1 4 4
1 5 8
2 3 6
2 4 3
2 5 2
3 4 1
3 5 8
4 5 2
7 2 8 4 1
7 10
3 2 8
2 1 4
2 5 7
2 6 4
7 1 2
4 3 5
6 4 2
6 7 1
6 7 4
4 5 9
7 6 5 4 3 2 1
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (n, m) = Scanner.IntInt();
				var verticies = new Dictionary<int, Vertex>();
				for (int i = 0; i < m; i++)
				{
					var (u, v, w) = Scanner.IntIntInt();
					Vertex uVertex;
					if (!verticies.TryGetValue(u, out uVertex))
					{
						uVertex = new Vertex(u, new List<Edge>());
					}
					
					Vertex vVertex;
					if (!verticies.TryGetValue(v, out vVertex))
					{
						vVertex = new Vertex(v, new List<Edge>());
					}
					
					uVertex.edges.Add(new(vVertex, w));
					vVertex.edges.Add(new(uVertex, w));
					verticies[u] = uVertex;
					verticies[v] = vVertex;
				}
				
				int[] slowness = Scanner.Array<int>();
				var dist = new Dictionary<int, int>();
				var q = new PriorityQueue<(int v, int slow), int>();
				foreach (var v in verticies.Keys)
				{
					dist[v] = int.MaxValue / 2;
				}
				
				dist[1] = 0;
				q.Enqueue((1, slowness[0]), 0);
				while (q.Count > 0)
				{
					var (city, slow) = q.Dequeue();
					var vertex = verticies[city];
					foreach (var edge in vertex.edges)
					{
																		
					}
				}
			}
		}
	}
	
	public record Edge(Vertex connected, int weight);
	public record Vertex(int id, List<Edge> edges);

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
