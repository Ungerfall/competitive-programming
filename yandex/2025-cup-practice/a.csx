#!/usr/bin/env dotnet-script

#define DEBUG
#nullable enable

int k = Scanner.Int();
foreach (var caseNumber in Enumerable.Range(0, k))
{
    bool canFit = true;
    bool[,] seen = new bool[10, 4];
    int[] scrolls = new int[8];
    int[][] wall = new int[10][];
    for (int r = 0; r < 10; r++)
    {
        wall[r] = Scanner.Array<int>();
    }

    for (int r = 0; r < 10; r++)
    {
        for (int c = 0; c < 4; c++)
        {
            if (seen[r, c])
            {
                continue;
            }

            if (wall[r][c] == 1)
            {
                scrolls[0]++;
                seen[r, c] = true;
                continue;
            }

            if (wall[r][c] == 2)
            {
                if (!tryGetValue(wall, r, c + 1, seen, out int next) || next != 2)
                {
                    canFit = false;
                    break;
                }

                scrolls[1]++;
                seen[r, c] = true;
                seen[r, c + 1] = true;
                continue;
            }

            if (wall[r][c] == 3)
            {
                if (!tryGetValue(wall, r, c + 1, seen, out int next) || next != 3)
                {
                    canFit = false;
                    break;
                }

                if (!tryGetValue(wall, r, c + 2, seen, out int nextnext) || nextnext != 3)
                {
                    canFit = false;
                    break;
                }

                scrolls[2]++;
                seen[r, c] = true;
                seen[r, c + 1] = true;
                seen[r, c + 2] = true;
                continue;
            }

            if (wall[r][c] == 4)
            {
                if (c != 0)
                {
                    canFit = false;
                    break;
                }

                if (!tryGetValue(wall, r, c + 1, seen, out int next) || next != 4)
                {
                    canFit = false;
                    break;
                }

                if (!tryGetValue(wall, r, c + 2, seen, out int nextnext) || nextnext != 4)
                {
                    canFit = false;
                    break;
                }

                if (!tryGetValue(wall, r, c + 1, seen, out int nextnextnext) || nextnextnext != 4)
                {
                    canFit = false;
                    break;
                }

                scrolls[3]++;
                seen[r, c] = true;
                seen[r, c + 1] = true;
                seen[r, c + 2] = true;
                seen[r, c + 3] = true;
                continue;
            }

            if (wall[r][c] == 5)
            {
                if (tryGetValue(wall, r, c + 1, seen, out int right) && right == 5
                    && tryGetValue(wall, r + 1, c, seen, out int bot) && bot == 5
                    && tryGetValue(wall, r + 1, c + 1, seen, out int rigthBot) && rigthBot == 5)
                {
                    scrolls[4]++;
                    seen[r, c] = true;
                    seen[r, c + 1] = true;
                    seen[r + 1, c] = true;
                    seen[r + 1, c + 1] = true;
                    continue;
                }

                canFit = false;
                break;
            }

            if (wall[r][c] == 6)
            {
                if (tryGetValue(wall, r, c + 1, seen, out int right) && right == 6
                    && tryGetValue(wall, r, c + 2, seen, out int right2) && right2 == 6
                    && tryGetValue(wall, r + 1, c, seen, out int bot) && bot == 6
                    && tryGetValue(wall, r + 1, c + 1, seen, out int r2b) && r2b == 6
                    && tryGetValue(wall, r + 1, c + 2, seen, out int r3b) && r3b == 6)
                {
                    scrolls[5]++;
                    seen[r, c] = true;
                    seen[r, c + 1] = true;
                    seen[r, c + 2] = true;
                    seen[r + 1, c] = true;
                    seen[r + 1, c + 1] = true;
                    seen[r + 1, c + 2] = true;
                    continue;
                }
                canFit = false;
                break;
            }

            if (wall[r][c] == 7)
            {
                if (c != 0)
                {
                    canFit = false;
                    break;
                }

                if (tryGetValue(wall, r, c + 1, seen, out int r2) && r2 == 7
                    && tryGetValue(wall, r, c + 2, seen, out int r3) && r3 == 7
                    && tryGetValue(wall, r, c + 3, seen, out int r4) && r4 == 7
                    && tryGetValue(wall, r + 1, c, seen, out int rb) && rb == 7
                    && tryGetValue(wall, r + 1, c + 1, seen, out int r2b) && r2b == 7
                    && tryGetValue(wall, r + 1, c + 2, seen, out int r3b) && r3b == 7
                    && tryGetValue(wall, r + 1, c + 3, seen, out int r4b) && r4b == 7)
                {
                    scrolls[6]++;
                    seen[r, c] = true;
                    seen[r, c + 1] = true;
                    seen[r, c + 2] = true;
                    seen[r, c + 3] = true;
                    seen[r + 1, c] = true;
                    seen[r + 1, c + 1] = true;
                    seen[r + 1, c + 2] = true;
                    seen[r + 1, c + 3] = true;
                    continue;
                }

                canFit = false;
                break;
            }

            if (wall[r][c] == 8)
            {
                if (tryGetValue(wall, r, c + 1, seen, out int r2) && r2 == 8
                    && tryGetValue(wall, r, c + 2, seen, out int r3) && r3 == 8
                    && tryGetValue(wall, r + 1, c, seen, out int rb) && rb == 8
                    && tryGetValue(wall, r + 1, c + 1, seen, out int r2b) && r2b == 8
                    && tryGetValue(wall, r + 1, c + 2, seen, out int r3b) && r3b == 8
                    && tryGetValue(wall, r + 2, c, seen, out int rb2) && rb2 == 8
                    && tryGetValue(wall, r + 2, c + 1, seen, out int r2b2) && r2b2 == 8
                    && tryGetValue(wall, r + 2, c + 2, seen, out int r3b2) && r3b2 == 8)
                {
                    scrolls[7]++;
                    seen[r, c] = true;
                    seen[r, c + 1] = true;
                    seen[r, c + 2] = true;
                    seen[r + 1, c] = true;
                    seen[r + 1, c + 1] = true;
                    seen[r + 1, c + 2] = true;
                    seen[r + 2, c] = true;
                    seen[r + 2, c + 1] = true;
                    seen[r + 2, c + 2] = true;
                    continue;
                }

                canFit = false;
                break;
            }
        }
    }

    Console.WriteLine(canFit ? "YES" : "NO");
    if (canFit)
    {
        Console.WriteLine(string.Join(' ', scrolls));
    }

    static bool tryGetValue(int[][] wall, int r, int c, bool[,] seen, out int val)
    {
        val = default;
        int rows = wall.Length;
        int cols = wall[0].Length;
        if (r < 0 || r >= rows || c < 0 || c >= cols)
        {
            return false;
        }

        if (seen[r, c])
        {
            return false;
        }

        val = wall[r][c];
        return true;
    }
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
