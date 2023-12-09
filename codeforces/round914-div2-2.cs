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
5
20 5 1 4 2
3
1434 7 1442
1
1
5
999999999 999999999 999999999 1000000000 1000000000
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				int[] nums = Scanner.Array<int>();
				int[] sorted = new int[n];
				int[] counts = new int[n];
				Array.Copy(nums, sorted, n);
				Array.Sort(sorted);
				for (int i = 0; i < n; i++)
				{
					int start = nums[i];
					long score = start;
					bool itself = false;
					int count = 0;
					for (int j = 0; j < n; j++)
					{
						if (start > sorted[j])
						{
							count++;
							score += sorted[j];
						}
						else
						{
							if (score < sorted[j])
							{
								break;
							}
							else if (!itself)
							{
								itself = true;
							}
							else
							{
								score += sorted[j];
								count++;
							}
						}
					}

					counts[i] = count;
				}

				Console.WriteLine(string.Join(' ', counts));
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
