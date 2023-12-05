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
12
ARaBbbitBaby
YetAnotherBrokenKeyboard
Bubble
Improbable
abbreviable
BbBB
BusyasaBeeinaBedofBloomingBlossoms
CoDEBARbIES
codeforces
bobebobbes
b
TheBBlackbboard
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = int.Parse(Console.ReadLine().Trim());
			const char B = 'B';
			const char b = 'b';
			foreach (var _ in Enumerable.Range(0, t))
			{
				string line = Console.ReadLine().Trim();
				bool[] toPrint = new bool[line.Length];
				int toRemoveUpperB = 0;
				int toRemoveLowerB = 0;
				for (int i = line.Length - 1; i >= 0; i--)
				{
					char ch = line[i];
					if (ch == B)
					{
						toRemoveUpperB++;
					}
					else if (ch == b)
					{
						toRemoveLowerB++;
					}
					else if (toRemoveUpperB > 0 && ch >= 'A' && ch <= 'Z')
					{
						toRemoveUpperB--;
					}
					else if (toRemoveLowerB > 0 && ch >= 'a' && ch <= 'z')
					{
						toRemoveLowerB--;
					}
					else
					{
						toPrint[i] = true;
					}
				}

				var output = line.Where((_, ix) => toPrint[ix]);
				Console.WriteLine(output.ToArray());
			}
		}
	}
}
