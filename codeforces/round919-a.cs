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
4
1 3
2 10
3 1
3 5
2
1 5
2 4
10
3 6
3 7
1 2
1 7
3 100
3 44
2 100
2 98
1 3
3 99
6
1 5
2 10
1 9
2 2
3 2
3 9
5
1 1
2 2
3 1
3 2
3 3
6
1 10000
2 900000000
3 500000000
1 100000000
3 10000
3 900000001
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				int maxConstraint1 = 1;
				int minConstraint2 = int.MaxValue;
				HashSet<int> excludes = new();
				foreach (var __ in Enumerable.Range(0, n))
				{
					var (constraint, value) = Scanner.IntInt();
					if (constraint == 1)
					{
						maxConstraint1 = Math.Max(maxConstraint1, value);
					}
					else if (constraint == 2)
					{
						minConstraint2 = Math.Min(minConstraint2, value);
					}
					else
					{
						excludes.Add(value);
					}
				}
				
				if (maxConstraint1 > minConstraint2)
				{
					Console.WriteLine(0);
					continue;
				}
				
				int count = minConstraint2 - maxConstraint1 + 1;
				//(new { count, minConstraint2, maxConstraint1, ex = string.Join(",", excludes)}).ToString().Dump();
				foreach (var exclude in excludes)
				{
					if (exclude >= maxConstraint1 && exclude <= minConstraint2)
					{
						count--;
					}
				}
				
				Console.WriteLine(count);
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
