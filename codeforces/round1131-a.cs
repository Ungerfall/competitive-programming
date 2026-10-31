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
4 1
sinx
n
6 7
xixsms
mixsxim
8 5
fixtures
frute
3 3
abc
def
5 10
sixty
codeforces
""";
    StringReader stringReader = new(input);
    Console.SetIn(stringReader);
}

int t = Scanner.Int();
foreach (var _ in Enumerable.Range(0, t))
{
    (int n, int m) = Scanner.IntInt();
    string p = Scanner.String();
    string q = Scanner.String();

    if (n - m != 3)
    {
        Console.WriteLine("NO");
        continue;
    }

    int[] letters = new int[26];
    for (int i = 0; i < n; i++)
    {
        int code = p[i] - 'a';
        letters[code]++;
    }

    for (int i = 0; i < m; i++)
    {
        int code = q[i] - 'a';
        letters[code]--;
    }

    bool can = true;
    for (int i = 0; i < letters.Length; i++)
    {
        if (letters[i] < 0)
        {
            can = false;
            break;
        }

        if (letters[i] > 1)
        {
            can = false;
            break;
        }
    }

    can = can && letters['s' - 'a'] == 1 && letters['i' - 'a'] == 1 && letters['x' - 'a'] == 1;

    Console.WriteLine(can ? "YES" : "NO");
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
