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
5
aaabc
3
acb
3
bac
4
zbca
15
czddeneeeemigec
13
cdefmopqsvxzz
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = Scanner.Int();
				string s = Scanner.String();
				
				if (isSortedAsc(s))
				{
					Console.WriteLine(0);
					continue;
				}
				
				if (isSortedDesc(s))
				{
					Console.WriteLine(0);
					continue;
				}
				
				var largestAlphabeticSubsequence = new bool[s.Length];
				int start = 0;
				while (start < s.Length)
				{
					int max = start;
					for (int i = start; i < s.Length; i++)
					{
						if (s[i] > s[max])
						{
							max = i;
						}
					}
					
					largestAlphabeticSubsequence[max] = true;
					for (int i = max + 1; i < s.Length; i++)
					{
						if (s[max] == s[i])
						{
							largestAlphabeticSubsequence[i] = true;
						}
					}
					
					start = max + 1;
				}
				
				var restSb = new StringBuilder();
				var lasSb = new StringBuilder();
				var lasStack = new Stack<char>();
				for (int i = 0; i < s.Length; i++)
				{
					if (largestAlphabeticSubsequence[i])
					{
						lasSb.Append(s[i]);
						lasStack.Push(s[i]);
					}
					else
					{
						restSb.Append(s[i]);
					}
				}
				
				string rest = restSb.ToString();
				string las = lasSb.ToString();
				if (!isSortedAsc(rest) || !isSortedDesc(las))
				{
					Console.WriteLine(-1);
					continue;
				}
				
				char[] mut = s.ToCharArray();
				int startLas = 0;
				while (lasStack.Count > 0)
				{
					char w = lasStack.Pop();
					for (int i = startLas; i < mut.Length; i++)
					{
						if (largestAlphabeticSubsequence[i])
						{
							mut[i] = w;
							startLas = i + 1;
							break;
						}
					}
				}
				
				if (!isSortedAsc(new string(mut)))
				{
					Console.WriteLine(-1);
					continue;
				}
				
				char lastChar = las[^1];
				int count = las.Length;
				for (int i = 0; i < las.Length; i++)
				{
					if (las[i] == lastChar)
					{
						count--;
					}
				}
				
				Console.WriteLine(count);
			}
		}

		static bool isSortedAsc(string s)
		{
			bool asc = true;
			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] < s[i - 1])
				{
					asc = false;
					break;
				}
			}

			return asc;
		}
		
		static bool isSortedDesc(string s)
		{
			bool desc = true;
			for (int i = 1; i < s.Length; i++)
			{
				if (s[i] > s[i - 1])
				{
					desc = false;
					break;
				}
			}
			
			return desc;
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
