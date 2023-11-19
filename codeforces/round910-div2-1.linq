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

void Main()
{
	Program.Program.Main(null);
}

namespace Program
{
	using System;
	using System.Collections.Generic;
	
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine().Trim());
			for (int i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Trim().Split();
				var sLen = int.Parse(line[0]);
				var desiredOfB = int.Parse(line[1]);
				var given = Console.ReadLine().Trim();
				int aCount = 0;
				for (int j = 0; j < given.Length; j++)
				{
					if (given[j] == 'A')
					{
						aCount++;
					}
				}
				
				int bCount = given.Length - aCount;
				if (bCount == desiredOfB)
				{
					Console.WriteLine(0);
					continue;
				}
				
				Console.WriteLine(1);
				if (bCount < desiredOfB)
				{
					int toReplace = desiredOfB - bCount;
					for (int j = 0; j <= toReplace && j < given.Length; j++)
					{
						if (given[j] == 'B')
						{
							toReplace++;
						}
					}

					Console.WriteLine($"{toReplace} B");
				}
				else
				{
					int toReplace = bCount - desiredOfB;
					for (int j = 0; j <= toReplace && j < given.Length; j++)
					{
						if (given[j] == 'A')
						{
							toReplace++;
						}
					}

					Console.WriteLine($"{toReplace} A");
				}
			}
		}
	}
}

