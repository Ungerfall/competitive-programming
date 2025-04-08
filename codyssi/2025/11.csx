#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

string? line = null;
long max = 0L;
long sum = 0L;
while ((line = Console.ReadLine()) is not null)
{
    string[] parts = line.Split();
    long base10 = ConvertToInt64(parts[0], int.Parse(parts[1].Trim()));
    max = Math.Max(max, base10);
    checked { sum += base10; }
}

string base68 = ConvertToBase68(sum);

int largestBaseToFitInFourCharacters = 0;
int left = 0;
int right = int.MaxValue;
while (left <= right)
{
    int mid = (int)(((long)left + right) / 2);
    int len = GetNumberLength(sum, mid);
    if (len < 5)
    {
        largestBaseToFitInFourCharacters = mid;
        right = mid - 1;
    }
    else
    {
        left = mid + 1;
    }
}

max.Dump();
base68.Dump();
largestBaseToFitInFourCharacters.Dump();

static Dictionary<char, int> charTo10 = Enumerable.Range(0, 62)
  .Select(x => x switch
      {
          <= 9 => ((char)(x + '0'), x),
          >= 10 and <= 35 => ((char)('A' + (x - 10)), x),
          >= 36 and <= 61 => ((char)('a' + (x - 36)), x),
          _ => throw new ArgumentException(nameof(x)),
      })
  .Concat([
      ('!', 62),
      ('@', 63),
      ('#', 64),
      ('$', 65),
      ('%', 66),
      ('^', 67),
  ])
  .ToDictionary(keySelector: x => x.Item1,
      elementSelector: x => x.Item2);
static Dictionary<int, char> decToChar = charTo10
  .ToDictionary(keySelector: x => x.Value,
      elementSelector: x => x.Key);
static long ConvertToInt64(string s, int fromBase)
{
    long num = 0L;
    for (int end = s.Length - 1, pow = 0; end >= 0; end--, pow++)
    {
        char ch = s[end];
        int in10 = charTo10[ch];
        num += in10 * (long)Math.Pow(fromBase, pow);
    }

    return num;
}

static string ConvertToBase68(long base10)
{
    long reminder = base10;
    StringBuilder sb = new();
    while (base10 >= 68)
    {
        reminder = base10 % 68;
        sb.Append(decToChar[(int)reminder]);
        base10 /= 68;
    }

    Debug.Assert(base10 < 68);
    if (base10 != 0)
    {
        sb.Append(decToChar[(int)base10]);
    }

    return new string(sb.ToString().Reverse().ToArray());
}

static int GetNumberLength(long n, int numericBase)
{
    if (n == 0)
    {
        return 1;
    }

    return (int)Math.Floor(Math.Log(n) / Math.Log(numericBase)) + 1;
}
