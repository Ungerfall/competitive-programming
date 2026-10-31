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
2
0 0 3
1 1 2
""";
    StringReader stringReader = new(input);
    Console.SetIn(stringReader);
}

int t = Scanner.Int();
foreach (var _ in Enumerable.Range(0, t))
{
    (int rocks, int scissors, int papers) = Scanner.IntIntInt(); 
    int bobsRocks = scissors;
    int bobsPapers = rocks;
    int bobsScissors = papers;
    (int count, char code)[] sequence = [
        (bobsRocks, 'R'),
        (bobsPapers, 'P'),
        (bobsScissors, 'S')];
    Array.Sort(sequence, (x, y) => x.count.CompareTo(y.count));

    Console.WriteLine(new string(sequence[2].code, rocks + papers + scissors));
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
