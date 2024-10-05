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
2
5
8
""";
			//using var stringReader = new StringReader(linqpadInput);
			using var stringReader = new StringReader(File.ReadAllText(@"C:\development\competitive-programming\facebook\prime_subtractorization_validation_input.txt"));
			Console.SetIn(stringReader);
#endif
			int n = 10_000_000;
			bool[] isPrime = new bool[n + 1];
			Array.Fill(isPrime, true);
			isPrime[0] = isPrime[1] = false;
			for (int i = 2; i <= n; i++)
			{
				if (isPrime[i] && (long)i * i <= n)
				{
					for (int j = i * i; j <= n; j += i)
					{
						isPrime[j] = false;
					}
				}
			}
			
			int t = Scanner.Int();
			foreach (var caseNumber in Enumerable.Range(0, t))
			{
				n = Scanner.Int();
				HashSet<int> subtractorization = new();
				for (int i = 1; i <= n; i++)
				{
					if (!isPrime[i])
					{
						continue;
					}
					
					for (int j = i + 1; j <= n; j++)
					{
						if (!isPrime[j])
						{
							continue;
						}
						
						if (isPrime[j - i])
						{
							subtractorization.Add(j-i);
						}
					}
				}

				Console.WriteLine($"Case #{caseNumber + 1}: {subtractorization.Count}");
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

