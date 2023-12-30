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
10
2 2
5 2
3 1
7 17 7
4 2
1 289 1 1
3 1
7 17 17
1 1
289
1 1
2023
1 3
1
5 5
2023 2023 2023 2023 2023
5 5
1 1 1 1 1
1 5
3
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			const string YES = "YES";
			const string NO = "NO";
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (n, k) = Scanner.IntInt();
				int[] b = Scanner.Array<int>();
				long product = b.Aggregate(1L, (acc, number) => acc * number);
				if (product == 2023)
				{
					Console.WriteLine(YES);
					Console.WriteLine(string.Join(" ", Enumerable.Repeat(1, k)));
				}
				else if (product > 2023)
				{
					Console.WriteLine(NO);
				}
				else if (product == 1 && k >= 1)
				{
					Console.WriteLine(YES);
					Console.WriteLine(string.Join(" ", (new int[] { 2023 }).Concat(Enumerable.Repeat(1, k - 1))));
				}
				else if (product == 7 && k >= 1)
				{
					Console.WriteLine(YES);
					Console.WriteLine(string.Join(" ", (new int[] { 17 * 17 }).Concat(Enumerable.Repeat(1, k - 1))));
				}
				else if (product == 17 && k >= 1)
				{
					Console.WriteLine(YES);
					Console.WriteLine(string.Join(" ", (new int[] { 7 * 17 }).Concat(Enumerable.Repeat(1, k - 1))));
				}
				else if (product == 7 * 17 && k >= 1)
				{
					Console.WriteLine(YES);
					Console.WriteLine(string.Join(" ", (new int[] { 17 }).Concat(Enumerable.Repeat(1, k - 1))));
				}
				else if (product == 17 * 17 && k >= 1)
				{
					Console.WriteLine(YES);
					Console.WriteLine(string.Join(" ", (new int[] { 7 }).Concat(Enumerable.Repeat(1, k - 1))));
				}
				else
				{
					Console.WriteLine(NO);
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
