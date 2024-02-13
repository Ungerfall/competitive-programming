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
7
6 5 2
1 2 7 4 9 6
7 9 5
1 10 15 3 8 12 15
9 4 10
14 10 2 2 11 11 13 5 6
9 5 6
10 7 6 7 9 7 7 10 10
9 6 2
4 9 7 1 2 2 13 3 15
9 2 3
14 6 1 15 12 15 8 2 15
10 5 7
13 3 3 2 12 11 3 7 13 14
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (n, x, y) = Scanner.IntIntInt();
				int[] a = Scanner.Array<int>();
				int pairs = 0;
				for (int i = 0; i < n; i++)
				{
					for (int j = i + 1; j < n; j++)
					{
						//(i, j).ToString().Dump();
						int sum = a[i] + a[j];
						int sub = a[i] - a[j];
						if (sum % x == 0 && sub % y == 0)
						{
							pairs++;
						}
					}
				}
				
				Console.WriteLine(pairs);
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
