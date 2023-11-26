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
void Main()
{
	Program.Program.Main(null);
}

namespace Program
{
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
			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				string[] line = Console.ReadLine().Trim().Split();
				int n = int.Parse(line[0]);
				int x = int.Parse(line[1]);
				int[] a = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				int[] aa = new int[n];
				int[] b = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				Array.Copy(a, aa, n);
				Array.Sort(aa);
				Array.Sort(b);
				ReadOnlySpan<int> largestAa = aa[^x..^0];
				bool yes = true;
				for (int i = 0; i < x; i++)
				{
					if (largestAa[i] <= b[i])
					{
						yes = false;
						break;
					}
				}
				
				if (!yes)
				{
					Console.WriteLine("NO");
					continue;
				}
				
				Console.WriteLine("YES");
				List<int> bRearrangement = new List<int>();
				bool[] visited = new bool[n];
				for (int i = 0; i < n; i++)
				{
					for (int j = n - 1; j <= 0; j++)
					{
						if (visited[j])
						{
							continue;
						}
						
						if (a[i] > b[j])
						{
							visited[j] = true;
							bRearrangement.Add(b[j]);
						}
					}
				}
			}
		}
	}
}

