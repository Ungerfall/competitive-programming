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
8
6
1 2 3 4 5 1
6
2 2 2 2 2 2
8
8 8 8 1 2 8 8 8
1
1
2
1 2
3
1 2 3
7
4 3 2 7 1 1 3
9
5 5 5 9 2 5 5 5 5
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				int[] a = Scanner.Array<int>();
				int standard = a[0];
				int left = 1;
				int right = n - 1;
				while (left <= right && (a[left] == standard || a[right] == standard))
				{
					if (a[left] == standard)
					{
						left++;
					}

					if (a[right] == standard)
					{
						right--;
					}
				}

				int best = right - left + 1;
				standard = a[^1];
				left = 0;
				right = n - 2;
				while (left <= right && (a[left] == standard || a[right] == standard))
				{
					if (a[left] == standard)
					{
						left++;
					}

					if (a[right] == standard)
					{
						right--;
					}
				}

				best = Math.Min(best, right - left + 1);
				Console.WriteLine(Math.Clamp(best, 0, int.MaxValue));
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
