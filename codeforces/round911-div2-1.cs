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
			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = int.Parse(Console.ReadLine().Trim());
				int?[] arr = Console.ReadLine().Trim()
					.Select(x => x switch
						{
							'#' => (int?)null,
							'.' => 0,
							_ => throw new ArgumentException($"invalid char {x}"),
						}
					)
					.ToArray();

				int emptyCells = arr[0] == 0 ? 1 : 0;
				int maxEmptySeq = emptyCells;
				int currEmptySeq = emptyCells;
				for (int i = 1; i < n; i++)
				{
					if (arr[i] is null)
					{
						maxEmptySeq = Math.Max(maxEmptySeq, currEmptySeq);
						currEmptySeq = 0;
					}
					else
					{
						emptyCells++;
						currEmptySeq++;
					}
				}

				Console.WriteLine(Math.Max(maxEmptySeq, currEmptySeq) >= 3 ? 2 : emptyCells);
			}
		}
	}
}
