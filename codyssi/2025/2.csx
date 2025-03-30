#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;
using System.Numerics;
using System.Text.RegularExpressions;

string line = Console.ReadLine()?.Trim() ?? throw new ArgumentNullException("null");
int add = int.Parse(Regex.Match(line, @"\d+").Value);
line = Console.ReadLine()?.Trim() ?? throw new ArgumentNullException("null");
int mul = int.Parse(Regex.Match(line, @"\d+").Value);
line = Console.ReadLine()?.Trim() ?? throw new ArgumentNullException("null");
int pow = int.Parse(Regex.Match(line, @"\d+").Value);

string? l = Console.ReadLine();
List<long> qualities = new();
long evenRooms = 0L;
const long limit = 15000000000000L;
int bestQualityRoom = 0;
long bestAffordableQuality = 0L;
while ((l = Console.ReadLine()) is not null)
{
  if (!int.TryParse(l, out int room))
  {
    continue;
  }

  long quality = applyFunctions(room, pow, mul, add);
  if (quality <= limit && quality > bestAffordableQuality)
  {
    bestAffordableQuality = quality;
    bestQualityRoom = room;
  }

  qualities.Add(quality);
  if (room % 2 == 0)
  {
    evenRooms += room;
  }
}

qualities.Sort();

int mid = qualities.Count / 2;
if (qualities.Count % 2 == 0)
{
  ((qualities[mid] + qualities[mid+1]) / 2).Dump();
}
else
{
  qualities[mid].Dump();
}

//(evenRooms, pow, mul, add).Dump();
BigInteger evenRoomsBig = new BigInteger(evenRooms);
applyFunctions(evenRoomsBig, pow, mul, add).ToString().Dump();
bestQualityRoom.Dump();

static long applyFunctions(long q, int pow, int mul, int add)
{
  checked
  {
    q = (long)Math.Pow(q, pow);
    q *= mul;
    q += add;
  }

  return q;
}

static BigInteger applyFunctions(BigInteger q, int pow, int mul, int add)
{
  q = BigInteger.Pow(q, pow);
  q *= mul;
  q += add;

  return q;
}
