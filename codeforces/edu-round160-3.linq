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
1 0
1 0
1 0
2 3
2 4
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			var multiset = new Multiset();
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (op, v) = Scanner.IntLong();
				if (op == 1)
				{
					multiset.Add((int)v);
				}
				else if (op == 2)
				{
					if (multiset.CheckSum(v))
					{
						Console.WriteLine("YES");
					}
					{
						Console.WriteLine("NO");
					}
				}
				else
				{
					throw new ArgumentException("op is not ok");
				}
			}
		}
	}
	
	public class Multiset
	{
		private readonly Dictionary<int, int> _counter = new Dictionary<int, int>();
		private readonly HashSet<long> _sums = new HashSet<long>(new long[] { 0 });
		
		public void Add(int key)
		{
			if (_counter.TryGetValue(key, out int count))
			{
				_counter[key] = count + 1;
			}
			else
			{
				_counter[key] = 1;
			}
			
			foreach (var item in _sums)
			{
				_sums.Add(item + key);
			}
		}
		
		public bool CheckSum(long target)
		{
			return _sums.Contains(target);
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
		public static (int, long) IntLong()
		{
			long[] line = Console.ReadLine().Trim().Split().Select(long.Parse).ToArray();
			Debug.Assert(line.Length == 2);
			return ((int)line[0], line[1]);
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
