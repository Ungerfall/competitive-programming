#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;
using System.Text.RegularExpressions;

string line = Console.ReadLine()?.Trim() ?? throw new ArgumentNullException("null");
int add = int.Parse(Regex.Match(line, @"\d+").Value);
line = Console.ReadLine()?.Trim() ?? throw new ArgumentNullException("null");
int mul = int.Parse(Regex.Match(line, @"\d+").Value);
line = Console.ReadLine()?.Trim() ?? throw new ArgumentNullException("null");
int pow = int.Parse(Regex.Match(line, @"\d+").Value);

string? l = Console.ReadLine();
List<long> qualities = new();
while ((l = Console.ReadLine()) is not null)
{
  if (!long.TryParse(l, out long quality))
  {
    continue;
  }

  checked
  {
    quality = (long)Math.Pow(quality, pow);
    quality *= mul;
    quality += add;
  }

  qualities.Add(quality);
}

qualities.Sort();

int mid = qualities.Count / 2;
qualities[mid].Dump();

