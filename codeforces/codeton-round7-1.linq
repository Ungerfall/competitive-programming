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
				int n = int.Parse(Console.ReadLine().Trim());
				int[] arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

				if (arr[0] != 1)
				{
					Console.WriteLine("NO");
					continue;
				}

				bool permuted = false;
				do
				{
					permuted = false;
					for (int i = 1; i < n - 1; i++)
					{
						if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
						{
							permuted = true;
							int tmp = arr[i];
							arr[i] = arr[i + 1];
							arr[i + 1] = tmp;
						}
					}
				} while (permuted);

				bool sorted = true;
				for (int i = 1; i < n; i++)
				{
					if (arr[i] < arr[i-1])
					{
						sorted = false;
						break;
					}
				}

				if (sorted)
				{
					Console.WriteLine("YES");
				}
				else
				{
					Console.WriteLine("NO");
				}
			}
		}
	}
}

