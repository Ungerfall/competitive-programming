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
8
2 4
1543
7777
2 4
7154
8903
2 4
3451
8888
2 2
54
13
2 2
51
43
2 6
432015
512034
4 4
5431
1435
5518
7634
6 4
5432
1152
4542
2432
2302
5942
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				var (n, m) = Scanner.IntInt();
				string[] rug = new string[n];
				for (int i = 0; i < n; i++)
				{
					rug[i] = Scanner.String();
				}
				
				
				int left = 0;
				int right = m;
				int top = 0;
				int bottom = n;
				int count = 0;
				while (left < right && top < bottom)
				{
					int layerCount = 2 * ((right - left) + (bottom - top) - 2);
					StringBuilder sb = new();
					sb.Append(rug[top].Substring(left, m - 2 * left));
					for (int i = top + 1; i < bottom - 1; i++)
					{
						sb.Append(rug[i][right - 1]);
					}
					
					for (int i = right - 1; i >= left; i--)
					{
						sb.Append(rug[bottom - 1][i]);
					}
					
					for (int i = bottom - 2; i >= top + 1; i--)
					{
						sb.Append(rug[i][left]);
					}
					
					string layer = sb.ToString();
					count += Regex.Matches(layer, "1543").Count;
					
					if (layer[^3] == '1' && layer[^2] == '5' && layer[^1] == '4' && layer[0] == '3')
					{
						count++;
					}
					else if (layer[^2] == '1' && layer[^1] == '5' && layer[0] == '4' && layer[1] == '3')
					{
						count++;
					}
					else if (layer[^1] == '1' && layer[0] == '5' && layer[1] == '4' && layer[2] == '3')
					{
						count++;
					}
					
					left++;
					right--;
					top++;
					bottom--;
				}
				
				Console.WriteLine(count);
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
