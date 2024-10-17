<Query Kind="Program" />

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

public class Program
{
	public static void Main(string[] args)
	{
		int n = Scanner.Int();
		int m = Scanner.Int();
		int[] x = Scanner.Array<int>();
		int[] b = Scanner.Array<int>();
		const int mod = 23;
		char[] abc = new char[23] { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w'};
		StringBuilder password = new();
		
		for (int j = 0; j < m; j++)
		{
			long sum = 0L;
			int xx = x[j] % mod;
			
			for (int i = 1; i <= n; i++)
			{
				int pow = (int) System.Numerics.BigInteger.ModPow(xx, n, mod);
				int abcIx = i % mod;
				sum += pow;
			}
			
		}
		
		Console.WriteLine(password.ToString());
		Console.Out.Flush();
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

void Main()
{
	var input = """
		4
		3
		2 3 5
		11 10 16
	""";
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		Program.Main(null);
	}
}
