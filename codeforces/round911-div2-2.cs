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
16
1 1 1
1 1 2
1 2 1
1 2 2
2 1 1
2 1 2
2 2 1
2 2 2
100 100 100
100 100 99
100 99 100
100 99 99
99 100 100
99 100 99
99 99 100
99 99 99
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = int.Parse(Console.ReadLine().Trim());
			foreach (var _ in Enumerable.Range(0, t))
			{
				int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				int a = line[0];
				int b = line[1];
				int c = line[2];

				if (a == b && b == c)
				{
					Console.WriteLine("1 1 1");
					continue;
				}

				Dictionary<Combination, int> memo = new();
				var end = nextCombination(new(a, b, c), memo);
				Console.WriteLine($"{((end & 1) == 1 ? 1 : 0)} {((end & 2) == 2 ? 1 : 0)} {((end & 4) == 4 ? 1 : 0)}");
			}

			static int nextCombination(Combination combination, Dictionary<Combination, int> memo)
			{
				if (combination.a == 0 && combination.b == 0)
				{
					return 4;
				}

				if (combination.a == 0 && combination.c == 0)
				{
					return 2;
				}

				if (combination.b == 0 && combination.c == 0)
				{
					return 1;
				}
				
				if (memo.ContainsKey(combination))
				{
					return memo[combination];
				}

				var steps = new[]
				{
					(+1, -1, -1),
					(-1, +1, -1),
					(-1, -1, +1),
				};

				var (a, b, c) = combination;
				int end = 0;
				foreach (var (ax, bx, cx) in steps)
				{
					var aa = a + ax;
					var bb = b + bx;
					var cc = c + cx;
					if (aa < 0 || bb < 0 || cc < 0)
					{
						continue;
					}

					end |= nextCombination(new(aa, bb, cc), memo);
				}
				
				if (memo.TryGetValue(combination, out int existing))
				{
					memo[combination] = existing | end;
				}
				else
				{
					memo[combination] = end;
				}
				
				return end;
			}
		}

		record struct Combination(int a, int b, int c);
	}
}
