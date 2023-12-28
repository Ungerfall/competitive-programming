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
9
3
1 3 2
6
1 1 1 1 1 1
10
1 6 9 8 55 3 14 2 7 2
8
1 2 11 4 1 5 1 2
6
2 6 1 5 7 8
9
2 5 10 4 4 9 6 7 8
1
4
2
1 3
2
5 5
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				int[] a = Scanner.Array<int>();
				if (n == 1)
				{
					Console.WriteLine("NO");
					continue;
				}
				
				if (n == 2)
				{
					Console.WriteLine(a[0] == a[1] ? "YES" : "NO");
					continue;
				}
				
				long[] prefixSumEven = new long[n];
				long[] prefixSumOdd = new long[n];
				prefixSumEven[0] = a[0];
				prefixSumEven[1] = a[0];
				prefixSumOdd[0] = 0L;
				prefixSumOdd[1] = a[1];
				for (int i = 2; i < n; i++)
				{
					if (i % 2 == 0)
					{
						prefixSumEven[i] = checked((long)a[i] + prefixSumEven[i-2]);
						prefixSumOdd[i] = prefixSumOdd[i-1];
					}
					else
					{
						prefixSumOdd[i] = checked((long)a[i] + prefixSumOdd[i-2]);
						prefixSumEven[i] = prefixSumEven[i-1];
					}
				}
				
				bool found = false;
				for (int left = 0; left < n - 1; left++)
				{
					for (int right = left + 1; right < n; right++)
					{
						long evenSum = prefixSumEven[right] - (left == 0 ? 0 : prefixSumEven[left-1]);
						long oddSum = prefixSumOdd[right] - (left == 0 ? 0 : prefixSumOdd[left-1]);
						//(evenSum, oddSum, left, right, $"[{string.Join(",", prefixSumEven)}]", $"[{string.Join(',', prefixSumOdd)}]").ToString().Dump();
						if (evenSum == oddSum)
						{
							found = true;
							goto STOP;
						}
					}
				}
				
				STOP:
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
