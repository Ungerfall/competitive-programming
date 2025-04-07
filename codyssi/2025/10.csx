#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

record Point(int Row, int Col);

string? line = null;
List<int[]> gridBuilder = [];
while ((line = Console.ReadLine()) is not null)
{
    int[] split = line
      .Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
      .Select(int.Parse)
      .ToArray();
    gridBuilder.Add(split);
}

int[][] grid = gridBuilder.ToArray();
int rows = grid.Length;
int cols = grid[0].Length;

long safestLine = long.MaxValue;
for (int row = 0; row < rows; row++)
{
    safestLine = Math.Min(safestLine, grid[row].Sum());
}

for (int col = 0; col < cols; col++)
{
    long colSum = 0L;
    for (int row = 0; row < rows; row++)
    {
        colSum += grid[row][col];
    }

    safestLine = Math.Min(safestLine, colSum);
}

Point start = new(0, 0);
Point destination = new(14, 14);
int safestPathSmol = findSafestPath(start, destination, grid, rows, cols);
int safestPathLong = findSafestPath(start, new(rows - 1, cols - 1), grid, rows, cols);

safestLine.Dump();
safestPathSmol.Dump();
safestPathLong.Dump();

static int findSafestPath(Point start, Point destination, int[][] grid, int rows, int cols)
{
    int[,] bestDist = new int[rows, cols];
    (int rx, int cx)[] dirs = new[] { (0, 1), (1, 0) };
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            bestDist[row, col] = int.MaxValue;
        }
    }
    bestDist[start.Row, start.Col] = grid[start.Row][start.Col];
    PriorityQueue<Point, int> dijkstra = new();
    dijkstra.Enqueue(start, priority: grid[start.Row][start.Col]);
    int safestPath = int.MaxValue;
    while (dijkstra.Count > 0)
    {
        Point pos = dijkstra.Dequeue();
        if (pos == destination)
        {
            safestPath = bestDist[pos.Row, pos.Col];
            return safestPath;
        }

        foreach ((int rx, int cx) in dirs)
        {
            int rr = pos.Row + rx;
            int cc = pos.Col + cx;
            if (rr > destination.Row || cc > destination.Col)
            {
                continue;
            }

            int newDist = bestDist[pos.Row, pos.Col] + grid[rr][cc];
            if (newDist < bestDist[rr, cc])
            {
                bestDist[rr, cc] = newDist;
                dijkstra.Enqueue(new(rr, cc), newDist);
            }
        }
    }

    throw new ArgumentException("Safest path does not exist");
}
