<Query Kind="Program" />

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
		var patients = new Dictionary<int, decimal>();
		int active = 0;
		decimal sum = 0;
		string line = null;
		while ((line = Console.ReadLine().Trim()) != "!")
		{
			if (line[0] == '?')
			{
				Console.WriteLine((sum / active).ToString("0.#########"));
				Console.Out.Flush();
				continue;
			}

			var split = line.Split(' ');
			string code = split[0];
			int id = int.Parse(split[1]);
			decimal t = split.Length == 3 ? decimal.Parse(split[2]) : 0m;
			if (code == "-")
			{
				sum -= patients[id];
				active--;
				patients.Remove(id);
			}
			else if (code == "+")
			{
				sum += t;
				active++;
				patients[id] = t;
			}
			else
			{
				sum -= patients[id];
				sum += t;
				patients[id] = t;
			}
		}
	}
}

void Main()
{
	var input = """
		+ 1 36.5
		?
		+ 2 42.3
		?
		+ 3 39.0
		?
		~ 2 -6.8
		?
		- 2
		~ 3 40.1
		?
		!
	""";
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		Program.Main(null);
	}
}
