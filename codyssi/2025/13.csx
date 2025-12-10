#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

record Destination(string Location, int Length);
record Bfs(string Destination, int PathLength);

Dictionary<string, List<Destination>> connectedLocations = [];
string? line = null;
Regex locationPattern = new Regex(@"^(\w+) -> (\w+) \| (\d+)$");
while ((line = Console.ReadLine()) is not null)
{
    Match m = locationPattern.Match(line);
    string start = m.Groups[1].Value;
    string end = m.Groups[2].Value;
    int len = int.Parse(m.Groups[3].Value);
    if (!connectedLocations.ContainsKey(start))
    {
        connectedLocations[start] = [];
    }

    connectedLocations[start].Add(new(end, len));
}

const string start = "STT";
Queue<Bfs> bfs = [];
HashSet<string> visited = [];
List<int> pathLengths = [];
bfs.Enqueue(new(start, 0));
while (bfs.Count > 0)
{
    (string destination, int pathLength) = bfs.Dequeue();
    visited.Add(destination);
    foreach ((string next, int _) in connectedLocations[destination])
    {
        if (!visited.Contains(next))
        {
            bfs.Enqueue(new(next, pathLength + 1));
        }
        else
        {
            pathLengths.Add(pathLength);
        }
    }
}

long product = pathLengths
  .OrderByDescending(x => x)
  .Take(3)
  .Aggregate(seed: 0L, (acc, e) => acc * e);

product.Dump();

