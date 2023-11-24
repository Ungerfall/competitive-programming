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
				var line = Console.ReadLine().Trim().Split();
				var n = int.Parse(line[0]);
				var x = int.Parse(line[1]);
				int[] arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				int max = arr[0];
				for (int i = 1; i < arr.Length; i++)
				{
					max = Math.Max(max, arr[i] - arr[i - 1]);
				}

				max = Math.Max(max, 2 * (x - arr[^1]));

				Console.WriteLine(max);
			}
		}
	}
}

