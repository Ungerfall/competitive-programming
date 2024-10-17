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
		var (a,b,c) = Scanner.IntIntInt();
		long n = Scanner.Int();
		if (a == b && b == c)
		{
			Console.WriteLine(-1);
			return;
		}
		
		long ab = LCM(a, b);
		long ac = LCM(a, c);
		long bc = LCM(b, c);
		long abc = LCM(ab, c);
		
		int count = 0;
		int i = 1;
		while (ab * i < abc)
		{
			i++;
		}
		
		count += i - 1;
		i = 1;
		while (ac * i < abc)
		{
			i++;
		}
		
		count += i - 1;
		i = 1;
		while (bc * i < abc)
		{
			i++;
		}
		
		count += i;
		
		long lowest = count * (long) ( n / count );
		i = 1;
		int j = 1;
		int k = 1;
		long low = (n / count) * abc;
		long current = low;
		(lowest, low, ab, bc, ac, abc, count, n).Dump();
		
		Console.WriteLine(current);
	}

	public static long LCM(long a, long b)
	{
		long lcm = checked((a / GCD(a, b)) * b);
		if (lcm == b)
		{
			lcm = b * (b / a);
		}

		return lcm;
	}
	public static long GCD(long a, long b)
	{
		while (b != 0)
		{
			long temp = b;
			b = a % b;
			a = temp;
		}

		return a;
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
	var input =
"""
5 6 7
1000000
""";
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		Program.Main(null);
	}
}
