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
1
6 5 6
2 3 8 5 6 5
1 3 4 10 5
6 5 6
2 3 4 5 6 5
1 3 8 10 3
3 3 4
1 3 5
2 4 6
2 5 4
1 4
7 3 4 4 2
1 4 2
2
6 4 4 2
1 5 2
3
2 2 1 4 3
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (n, m, k) = Scanner.IntIntInt();
				int[] a = Scanner.Array<int>();
				int[] b = Scanner.Array<int>();
				Array.Sort(a);
				Array.Sort(b);
				int rem = k / 2;
				bool found = false;
				var decision = new Queue<(int i, int aRem, int bRem)>();
				decision.Enqueue((1, rem, rem));
				a.Dump();
				b.Dump();
				while (decision.Count > 0)
				{
					var (i, aRem, bRem) = decision.Dequeue();
					new { i, aRem, bRem }.ToString().Dump();
					if (i > n || i > m)
					{
						"ix out of range".Dump();
						continue;
					}

					if (aRem < 0 || bRem < 0)
					{
						"out of rem".Dump();
						continue;
					}
					
					if (i != a[i - 1] && i != b[i - 1])
					{
						"not found i".Dump();
						decision.Enqueue((i + 1, aRem, bRem));
						continue;
					}

					if (aRem == 0 && bRem == 0 && i == k)
					{
						"found".Dump();
						found = true;
						break;
					}

					if (i == a[i - 1] && i == b[i - 1])
					{
						decision.Enqueue((i + 1, aRem - 1, bRem));
						decision.Enqueue((i + 1, aRem, bRem - 1));
					}
					else if (i == a[i - 1])
					{
						decision.Enqueue((i + 1, aRem - 1, bRem));
					}
					else
					{
						decision.Enqueue((i + 1, aRem, bRem - 1));
					}
				}

				Console.WriteLine(found ? "YES" : "NO");
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
