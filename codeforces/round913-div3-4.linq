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
4
5
1 5
3 4
5 6
8 10
0 1
3
0 2
0 1
0 3
3
3 8
10 18
6 11
4
10 20
0 5
15 17
2 2
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = int.Parse(Console.ReadLine().Trim());
				int[][] segments = new int[n][];
				for (int i = 0; i < n; i++)
				{
					segments[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				}
				
				int?[] memo = new int?[n];
				Console.WriteLine(GetMinStep(segments, index: 0, pos: 0, memo, 0));
			}
			
			static int GetMinStep(int[][] segments, int index, int pos, int?[] memo, int length)
			{
				if (index == segments.Length)
				{
					return length;
				}
				
				if (memo[index] is not null)
				{
					return memo[index].Value;
				}
				
				int left = segments[index][0];
				int right = segments[index][1];
				int min = int.MaxValue;
				for (int i = left; i <= right; i++)
				{
					int toNext = Math.Max(length, Math.Abs(pos - i));
					min = Math.Min(min, GetMinStep(segments, index + 1, i, memo, toNext));
				}
					
				memo[index] = min;
				return min;
			}
		}
	}
}
