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
20
1 1 1 1
1 1 1 1
1 2 1 1
1 1 1 1000000000
1 999999998 1 1000000000
1 999999999 1 1000000000
1 1000000000 1 1000000000
1 1000000001 1 1000000000
1 1 1000000000 1
1 999999998 1000000000 1
1 999999999 1000000000 1
1 1000000000 1000000000 1
1 1000000001 1000000000 1
1 1 1000000000 1000000000
1 1999999997 1000000000 1000000000
1 1999999998 1000000000 1000000000
1 1999999999 1000000000 1000000000
1 2000000000 1000000000 1000000000
1000000000 1 1 1
1000000000 1142857140 1 1
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int tc = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, tc))
			{
				string[] line = Console.ReadLine().Trim().Split().ToArray();
				int n = int.Parse(line[0]);
				long p = long.Parse(line[1]);
				int l = int.Parse(line[2]);
				int t = int.Parse(line[3]);

				if (l >= p || t >= p)
				{
					Console.WriteLine(n - 1);
					continue;
				}

				int tasks = 1 + ((n - 1) / 7);
				long study = (long)Math.Ceiling(p / (double)(2 * t + (long)l));
				if (study < tasks / 2)
				{
					Console.WriteLine(Math.Max(n - study, 0));
				}
				else
				{
					if (tasks % 2 == 0)
					{
						p -= tasks / 2 * (2 * t + (long)l);
						study = tasks / 2;
					}
					else
					{
						p -= (tasks / 2 * (2 * t + (long)l)) + (t + (long)l);
						study = (tasks / 2) + 1;
					}
					//(new { p, study, tasks, n }).ToString().Dump();
					if (p > 0)
					{
						long days = (long)Math.Ceiling(p / (double)l);
						study += days;
					}

					Console.WriteLine(Math.Max(n - study, 0));
				}
			}
		}
	}
}
