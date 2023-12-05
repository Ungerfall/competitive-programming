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
10
4
aabc
5
abaca
10
avbvvcvvvd
7
abcdefg
5
dabbb
8
aacebeaa
7
bbbbacc
6
dacfcc
6
fdfcdc
9
dbdcfbbdc
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				int n = int.Parse(Console.ReadLine().Trim());
				string s = Console.ReadLine().Trim();
				int[] counter = new int[26];
				for (int i = 0; i < s.Length; i++)
				{
					int code = s[i] - 'a';
					counter[code]++;
				}
				
				int max = 0;
				for (int i = 1; i < counter.Length; i++)
				{
					if (counter[i] > counter[max])
					{
						max = i;
					}
				}
				
				Console.WriteLine(Math.Max(counter[max] - (s.Length - counter[max]), s.Length % 2 == 0 ? 0 : 1));
			}
		}
	}
}
