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
6
4
0011
4
1000
5
01000
8
01001101
7
0101010
7
0111101
""";
    StringReader stringReader = new(input);
    Console.SetIn(stringReader);
}

int t = Scanner.Int();
foreach (var _ in Enumerable.Range(0, t))
{
    int n = Scanner.Int();
    string s = Scanner.String();
    ReadOnlySpan<char> span = s.AsSpan();

    if (span[0] == '1')
    {
        Console.WriteLine(span[1..].Count('0'));
    }
    else if (span.Length == 2)
    {
        Console.WriteLine(s == "10" ? 1 : 0);
    }
    else
    {
        int[] prefix = new int[n];
        for (int i = 1; i < n; i++)
        {
            prefix[i] = prefix[i - 1] + (span[i] == '0' ? 0 : 1);
        }

        int min = int.MaxValue;
        for (int i = 1; i < n - 1; i++)
        {
            int zerosOnLeft = i - prefix[i];
            int onesOnLeft = prefix[i];
            int zerosOnRight = (n - i - 1) - (prefix[^1] - prefix[i]);
            int onesOnRight = prefix[^1] - prefix[i];

            //Console.WriteLine((n, i, string.Join(',', prefix)));
            //Console.WriteLine(new { s, min, zerosOnLeft, onesOnLeft, zerosOnRight, onesOnRight });
            min = Math.Min(min,
                    Math.Min(onesOnLeft + onesOnRight,
                        Math.Min(onesOnLeft + zerosOnRight, zerosOnLeft + zerosOnRight)));

        }

        Console.WriteLine(min);
    }
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
