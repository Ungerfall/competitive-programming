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
3 2
1 2 3
3 1
9 9 9
4 4
6 4 2 1
4 3
10 3 830 14
2 1
3 1
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif

			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(1, t))
			{
				int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				int n = line[0];
				int k = line[1];
				int[] nums = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();

				if (k == 1)
				{
					bool sorted = true;
					for (int i = 1; i < nums.Length; i++)
					{
						if (nums[i] < nums[i - 1])
						{
							sorted = false;
							break;
						}
					}

					Console.WriteLine(sorted ? "YES" : "NO");
				}
				else
				{
					Console.WriteLine("YES");
				}
			}
		}
	}
}
