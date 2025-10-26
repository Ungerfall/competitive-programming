#!/usr/bin/env dotnet-script

#define DEBUG
#nullable enable

int k = Scanner.Int();
foreach (var caseNumber in Enumerable.Range(0, k))
{

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
