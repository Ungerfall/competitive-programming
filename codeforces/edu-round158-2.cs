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
				int n = int.Parse(Console.ReadLine().Trim());
				int[] arr = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
				long min = arr[0] - 1;
				for (int i = 1; i < arr.Length; i++)
				{
					if (arr[i] <= arr[i-1])
					{
						continue;
					}
					
					min += arr[i] - arr[i-1];					
				}
				Console.WriteLine(min);
			}
		}
	}
}

