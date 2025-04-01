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
using System.Numerics;

public class Program
{
	const int MOD = 23;
	public static void Main(string[] args)
	{
		int n = Scanner.Int();
		int m = Scanner.Int();
		int[] x = Scanner.Array<int>();
		int[] b = Scanner.Array<int>();
		int[,] v = new int[m, n + 1];
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				v[i, j] = (int)BigInteger.ModPow(x[i], j, MOD);
			}

			v[i, n] = b[i];
		}

		v.Dump();
		int[] ans = new int[m];
		for (int i = 0; i < m; i++)
		{
			int diag = v[i, i];
			v[i, i] = 1;
			for (int j = 0; j < n; j++)
			{
				if (i != j)
				{
					v[i, j] = (v[i, j] * ModPowInverse(diag, MOD)) % MOD;
				}
			}
			
			for (int j = 0; j < m; j++)
			{
				
				if (i != j)
				{
										
				}
			}
		}

		v.Dump();


		StringBuilder password = new StringBuilder();
		char[] abc = "abcdefghijklmnopqrstuvw".ToCharArray();
		foreach (int index in ans)
		{
			password.Append(abc[index]);
		}

		Console.WriteLine(password.ToString());
		Console.Out.Flush();
	}

	private static int ModPowInverse(int m, int mod)
	{
		return (int)BigInteger.ModPow(m, mod - 2, mod);
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
