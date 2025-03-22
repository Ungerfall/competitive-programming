#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

string? line = Console.ReadLine() ?? throw new ArgumentException("null input");
long offset = long.Parse(line.Trim());
List<int> magnitudes = new();
string? signs = null;
while ((line = Console.ReadLine()) != null)
{
  if (int.TryParse(line, out int number))
  {
    magnitudes.Add(number);
  }
  else
  {
    signs = line;
  }
}

Debug.Assert(signs is not null);
for (int i = 0; i < signs.Length; i++)
{
  char sign = signs[i];
  offset += (sign == '+' ? magnitudes[i] : -1 * magnitudes[i]);
}

offset.Dump("final offset");
