// copy template to destination `cp template.cs problem123.cs`
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

if (Environment.GetEnvironmentVariable("CONSOLE_IN_STRINGREADER") == "true")
{
    string input =
"""
3
6
5 1 4 2 2 -4
7
0 0 0 0 0 0 0
12
-4 3 0 -4 -4 -1 -4 1 -3 -2 -2 -1
""";
    StringReader stringReader = new(input);
    Console.SetIn(stringReader);
}

int t = Scanner.Int();
foreach (var _ in Enumerable.Range(0, t))
{
    int keys = Scanner.Int();
    int[] love = Scanner.Array<int>();
    Dictionary<int, HashSet<int>> counter = [];
    for (int x = 0; x < keys - 4; x++)
    {
        int key0 = x;
        int key1 = x + 2;
        int key2 = x + 4;
        int unitsOfLove = love[key0] + love[key1] - love[key2];
        if (!counter.ContainsKey(unitsOfLove))
        {
            counter[unitsOfLove] = [];
        }

        counter[unitsOfLove].Add(key0);
    }

    long ways = 0L;
    foreach (HashSet<int> values in counter.Values)
    {
        long n = values.Count;
        long totalPairs = n * (n - 1) / 2;
        long invalid = 0;
        foreach (int x in values)
        {
            if (values.Contains(x + 2))
            {
                invalid++;
            }

            if (values.Contains(x + 4))
            {
                invalid++;
            }
        }

        ways += (totalPairs - invalid);
    }

    Console.WriteLine(ways);
}

public static class Scanner
{
    public static string String() => Console.ReadLine()?.Trim() ?? throw new ArgumentNullException();
    public static int Int() => int.Parse(Console.ReadLine()?.Trim() ?? throw new ArgumentNullException());
    public static long Long() => long.Parse(Console.ReadLine()?.Trim() ?? throw new ArgumentException());
    public static (int, int) IntInt()
    {
        string raw = Console.ReadLine() ?? throw new ArgumentNullException();
        int[] line = raw.Trim().Split().Select(int.Parse).ToArray();
        Debug.Assert(line.Length == 2);
        return (line[0], line[1]);
    }
    public static (int, int, int) IntIntInt()
    {
        string raw = Console.ReadLine() ?? throw new ArgumentNullException();
        int[] line = raw.Trim().Split().Select(int.Parse).ToArray();
        Debug.Assert(line.Length == 3);
        return (line[0], line[1], line[2]);
    }
    public static T[] Array<T>() => (Console.ReadLine() ?? throw new ArgumentNullException())
        .Trim()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(x => (T)Convert.ChangeType(x, typeof(T)))
        .ToArray();
}
