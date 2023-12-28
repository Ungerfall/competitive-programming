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
8
bacedbab
4
baba
13
daddecabeddad
3
dac
6
dacdac
22
dababbabababbabbababba
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				string s = Scanner.String();
				StringBuilder sb = new();
				int i = 0;
				for (; i < n - 2; i++)
				{
					sb.Append(s[i]);
					if (IsVowel(s[i]))
					{
						if (IsConsonant(s[i + 2]))
						{
							sb.Append(s[i + 1]);
							i++;
						}

						sb.Append('.');
					}
				}

				sb.Append(s[i..^0]);
				Console.WriteLine(sb.ToString());
			}

			static bool IsConsonant(char ch)
			{
				return (ch == 'b')
					|| (ch == 'c')
					|| (ch == 'd');
			}

			static bool IsVowel(char ch)
			{
				return (ch == 'a')
					|| (ch == 'e');
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
