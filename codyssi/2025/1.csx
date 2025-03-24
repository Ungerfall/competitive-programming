#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;
using System.Diagnostics;

string? line = Console.ReadLine() ?? throw new ArgumentException("null input");
long offset = long.Parse(line.Trim()) * 10;
line = Console.ReadLine() ?? throw new ArgumentException("null input");
offset += long.Parse(line.Trim());
List<int> magnitudes = new();
string? signs = null;
bool secondDigit = false;
int doubleDigit = 0;
while ((line = Console.ReadLine()) != null)
{
  if (int.TryParse(line, out int number))
  {
    if (!secondDigit)
    {
      doubleDigit = 10 * number;
    }
    else
    {
      doubleDigit += number;
      magnitudes.Add(doubleDigit);
      doubleDigit = 0;
    }

    secondDigit = !secondDigit;
  }
  else
  {
    signs = line;
  }
}

(offset, magnitudes).Dump();

Debug.Assert(signs is not null);
for (int i = 0; i < magnitudes.Count; i++)
{
  int reverseIndex = i + 1;
  char sign = signs[^reverseIndex];
  offset += (sign == '+' ? magnitudes[i] : -1 * magnitudes[i]);
}

offset.Dump("final offset");
