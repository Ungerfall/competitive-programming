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
5
3 4 4
1 2 3
1 3 2 3
6 2 3
6 1 2 4 1 5
6 6
5 1 1
0 5 0 5 0
5
1 1 1
1
1
3 4 6
1 2 3
1 3 2 3
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (n, k, d) = Scanner.IntIntInt();
				int[] a = Scanner.Array<int>();
				int[] v = Scanner.Array<int>();
				int count = 0;
				for (int i = 0; i < n; i++)
				{
					if (a[i] == i + 1)
					{
						count++;
					}
				}

				int max = count;
				int harvestDay = 0;
				for (int i = 0; i < Math.Min(k, n) - 1; i++)
				{
					for (int ii = 0; ii < v[i]; ii++)
					{
						a[ii]++;
					}

					count = 0;
					for (int j = 0; j < n; j++)
					{
						if (a[j] == j + 1)
						{
							count++;
						}
					}

					if (count > max)
					{
						harvestDay = i + 1;
						max = count;
					}
				}

				int daysLeft = d - (harvestDay + 1);
				//(new { daysLeft, d, harvestDay, max, a, v }).Dump();
				if (harvestDay >= d)
				{
					Console.WriteLine(0);
				}
				else
				{
					int best = max + (daysLeft <= 0 ? 0 : (daysLeft / 2));
					Console.WriteLine(best);
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
