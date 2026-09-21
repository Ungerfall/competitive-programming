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
5
3 6 3
3 6 10
5 5 4
2 5 6
67676767 41414141 998244353
""";
    StringReader stringReader = new(input);
    Console.SetIn(stringReader);
}

int t = Scanner.Int();
foreach (var _ in Enumerable.Range(0, t))
{
    (int a, int b, int c) = Scanner.IntIntInt();
    Console.WriteLine(Math.Max(
                Math.Abs((a + c) - b),
                Math.Abs(a - b)));
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
