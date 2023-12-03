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
5
1 5 5 2
14 3000000000 1000000000 500000000
100 20 1 10
8 120 10 20
42 280 13 37
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int tc = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, tc))
			{
				checked
				{
					string[] line = Console.ReadLine().Trim().Split().ToArray();
					int n = int.Parse(line[0]);
					long p = long.Parse(line[1]);
					int l = int.Parse(line[2]);
					int t = int.Parse(line[3]);
					
					if (l >= p || t >= p)
					{
						Console.WriteLine(0);
						continue;
					}

					int tasks = 1 + ((n - 1) / 7);
					long study = (long)Math.Ceiling(p / (double)(2 * t + l));
					if (study < tasks / 2)
					{
						Console.WriteLine(Math.Max(n - study, 0));
					}
					else
					{
						if (tasks % 2 == 0)
						{
							p -= tasks / 2 * (2 * t + l);
							study = tasks / 2;
						}
						else
						{
							p -= (tasks / 2 * (2 * t + l)) + (t + l);
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
}
