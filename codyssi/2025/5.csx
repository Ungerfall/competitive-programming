#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

record struct Point(int Row, int Col);

string? line = null;
const string digitTemplate = @"-?\d+";
Point start = new(0, 0);
HashSet<Point> islands = [];
int farthest = 0;
int closest = int.MaxValue;
while ((line = Console.ReadLine()) is not null)
{
    MatchCollection matches = Regex.Matches(line, digitTemplate);
    int row = int.Parse(matches[0].Value);
    int col = int.Parse(matches[1].Value);
    Point island = new(row, col);
    islands.Add(island);
    int distance = CalculateManhattan(start, island);
    farthest = Math.Max(farthest, distance);
    closest = Math.Min(closest, distance);
}

Point closestToStart = FindClosestIsland(start, islands);
Point closestToClosestToStart = FindClosestIsland(closestToStart, islands);

(farthest - closest).Dump();
CalculateManhattan(closestToStart, closestToClosestToStart).Dump();
Sail(start, islands).Dump();

static long Sail(Point start, HashSet<Point> islands)
{
  HashSet<Point> visited = [];
  long path = 0L;
  while (visited.Count < islands.Count)
  {
    Point closest = FindClosestIsland(start, islands, visited);
    int distance = CalculateManhattan(start, closest);
    path += distance;
    visited.Add(closest);
    start = closest;
  }

  return path;
}

static Point FindClosestIsland(Point start, HashSet<Point> islands, HashSet<Point>? visited = null)
{
    visited = visited ?? [];
    int closest = int.MaxValue;
    Point closestPoint = new(int.MaxValue, int.MaxValue);
    foreach (Point island in islands)
    {
        if (island == start || visited.Contains(island))
        {
            continue;
        }

        int distance = CalculateManhattan(start, island);
        if (distance == closest)
        {
            if (island.Row < closestPoint.Row
                || (island.Row == closestPoint.Row &&  island.Col < closestPoint.Col))
            {
                closestPoint = island;
            }
        }
        else if (distance < closest)
        {
            closest = distance;
            closestPoint = island;
        }
    }

    return closestPoint;
}

static int CalculateManhattan(Point x, Point y)
{
    return Math.Abs(x.Row - y.Row) + Math.Abs(x.Col - y.Col);
}

