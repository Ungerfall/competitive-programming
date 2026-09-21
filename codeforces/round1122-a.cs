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

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Environment.GetEnvironmentVariable("CONSOLE_IN_STRINGREADER") == "true")
            {
                string input =
"""
6
3
3 3 3
4
4 4 3
1
1 1 1
9
9 8 9
5
0 5 5
6
4 3 2
""";
                StringReader stringReader = new(input);
                Console.SetIn(stringReader);
            }

            int t = Scanner.Int();
            foreach (var _ in Enumerable.Range(0, t))
            {
                int n = Scanner.Int();
                int[] scores = Scanner.Array<int>();

                Console.WriteLine(n - Math.Min(scores[0], Math.Min(scores[1], scores[2])));
            }
        }
    }

    public static class Scanner
    {
        public static string String() => Console.ReadLine().Trim();
        public static int Int() => int.Parse(Console.ReadLine().Trim());
        public static long Long() => long.Parse(Console.ReadLine().Trim());
        public static (int, int) IntInt()
        {
            int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            Debug.Assert(line.Length == 2);
            return (line[0], line[1]);
        }
        public static (int, int, int) IntIntInt()
        {
            int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
            Debug.Assert(line.Length == 3);
            return (line[0], line[1], line[2]);
        }
        public static T[] Array<T>() => Console.ReadLine().Trim()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(x => (T)Convert.ChangeType(x, typeof(T)))
            .ToArray();
    }
}
