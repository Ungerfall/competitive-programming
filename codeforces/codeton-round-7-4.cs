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
				string[] line = Console.ReadLine().Trim().Split();
				int n = int.Parse(line[0]);
				int q = int.Parse(line[1]);
				int[] arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				foreach (var __ in Enumerable.Range(0, q))
				{
					int[] op = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
					if (op[0] == 1)
					{
						int s = op[1];
						if (IsSubarrayHaveSum(s, arr))
						{
							Console.WriteLine("YES");
						}
						else
						{
							Console.WriteLine("NO");
						}
					}
					else
					{
						int i = op[1];
						int v = op[2];
						arr[i - 1] = v;
					}
				}
			}


		}

		private static bool IsSubarrayHaveSum(int n, int[] arr)
		{
			int len = arr.Length;
			int count = 0;
			int sum = 0;
			Dictionary<int, int> dict = new Dictionary<int, int>() { { 0, 1 } };

			for (int i = 0; i < len; i++)
			{
				sum += arr[i];

				if (dict.ContainsKey(sum - n))
				{
					return true;
				}

				if (!dict.ContainsKey(sum))
					dict.Add(sum, 1);
				else
					dict[sum]++;
			}

			return false;
		}
	}
}

