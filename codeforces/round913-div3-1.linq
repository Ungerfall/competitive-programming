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
1
d5
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif

			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				string rook = Console.ReadLine().Trim();
				int rookRow = (int)char.GetNumericValue(rook[1]);
				int rookCol = rook[0] - 'a' + 1;
				for (int row = 1; row <= 8; row++)
				{
					for (int col = 1; col <= 8; col++)
					{
						if (row == rookRow && col == rookCol)
						{
							continue;
						}

						if (row == rookRow)
						{
							Console.WriteLine($"{(char)('a' + col - 1)}{row}");
						}

						if (col == rookCol)
						{
							Console.WriteLine($"{(char)('a' + col - 1)}{row}");
						}
					}
				}
			}
		}
	}
}
