#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

int t = Scanner.Int();
foreach (var caseNumber in Enumerable.Range(0, t))
{
    int len = Scanner.Int();
    int[] a = Scanner.Array<int>();
    int max = 0;
    for (int i = 0; i < a.Length - 1; i++)
    {
        max = Math.Max(max, Math.Abs(a[i] - a[i + 1]));
    }

    Console.WriteLine($"Case #{caseNumber + 1}: {max}");
}

public static class Scanner
{
    public static string String() => Console.ReadLine()!.Trim();
    public static int Int() => int.Parse(Console.ReadLine()!.Trim());
    public static long Long() => long.Parse(Console.ReadLine()!.Trim());
    public static (int, int) IntInt()
    {
        int[] line = Console.ReadLine()!.Trim().Split().Select(int.Parse).ToArray();
        Debug.Assert(line.Length == 2);
        return (line[0], line[1]);
    }
    public static (int, int, int) IntIntInt()
    {
        int[] line = Console.ReadLine()!.Trim().Split().Select(int.Parse).ToArray();
        Debug.Assert(line.Length == 3);
        return (line[0], line[1], line[2]);
    }
    public static T[] Array<T>() => Console.ReadLine()!.Trim()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Select(x => (T)Convert.ChangeType(x, typeof(T)))
        .ToArray();
}
