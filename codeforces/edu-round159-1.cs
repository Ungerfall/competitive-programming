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
3
2
00
2
11
2
10
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = int.Parse(Console.ReadLine().Trim());
				string s = Console.ReadLine().Trim();

				bool canInsertZero = false;
				int zeroCount = s[0] == '0' ? 1 : 0;
				for (int i = 1; i < s.Length; i++)
				{
					if (s[i] == '0')
					{
						zeroCount++;
					}

					if (s[i - 1] != s[i])
					{
						canInsertZero = true;
					}
				}

				if (zeroCount > s.Length / 2)
				{
					Console.WriteLine("YES");
					continue;
				}

				if (canInsertZero)
				{
					Console.WriteLine("YES");
					continue;
				}

				Console.WriteLine("NO");
			}
		}
	}
}
