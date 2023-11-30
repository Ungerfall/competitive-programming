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
1
0
4
0 3 3 5
3 0 3 7
3 3 0 7
5 7 7 0
5
0 7 7 5 5
7 0 3 2 6
7 3 0 3 7
5 2 3 0 4
5 6 7 4 0
3
0 0 1
0 0 0
1 0 0
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif

			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(1, t))
			{
				int n = int.Parse(Console.ReadLine().Trim());
				int[][] cube = new int[n][];
				for (int i = 0; i < n; i++)
				{
					cube[i] = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				}

				bool hasZero = false;
				int[] key = new int[n];
				for (int row = 0; row < n; row++)
				{
					for (int col = 0; col < n; col++)
					{
						if (row != col)
						{
							if (cube[row][col] == 0)
							{
								hasZero = true;
							}

							key[row] = cube[row][col] & (~cube[row][col]);
							key[col] = cube[row][col] | key[row];
						}
					}
				}

				if (hasZero)
				{
					bool allZeros = true;
					for (int i = 0; i < n; i++)
					{
						if (key[i] != 0)
						{
							allZeros = false;
							break;
						}
					}

					if (allZeros)
					{
						Console.WriteLine("NO");
						continue;
					}
				}
				
				Console.WriteLine("YES");
				Console.WriteLine(string.Join(' ', key));
			}
		}
	}
}
