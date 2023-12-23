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
6
3
1 -1
0 0
1 -1
4
-3 -2
-3 -1
-3 0
-3 1
4
1 1
-1 -1
1 -1
-1 1
6
-4 14
-9 -13
-14 5
14 15
-8 -4
19 9
6
82 64
39 91
3 46
87 83
74 21
7 25
1
100 -100
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				(int x, int y)[] points = new (int, int)[n];
				for (int i = 0; i < n; i++)
				{
					points[i] = Scanner.IntInt();
				}

				(int? x, int? y)[] quadrants = new (int?, int?)[]
				{
					(-1, null),
					(1, null),
					(null, -1),
					(null, 1),
				};
				bool inQuadrant = true;
				foreach (var q in quadrants)
				{
					inQuadrant = true;
					for (int i = 0; i < n; i++)
					{
						int? xx = q.x * points[i].x;
						int? yy = q.y * points[i].y;
						if ((xx ?? yy) < 0)
						{
							inQuadrant = false;
						}
					}
					if (inQuadrant)
					{
						Console.WriteLine("YES");
						break;
					}
				}

				if (!inQuadrant)
				{
					Console.WriteLine("NO");
				}
			}
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
