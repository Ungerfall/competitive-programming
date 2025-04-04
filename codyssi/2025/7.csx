#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Runtime.InteropServices;
using Dumpify;

record struct SwapOp(int From, int To);
record struct SwapOpVersion2(int X, int Y, int Z);

List<int> tracks = [];
List<int> tracksVersion2 = [];
string? line = null;
while ((line = Console.ReadLine()) is not null)
{
    if (!int.TryParse(line, out int track))
    {
        break;
    }

    tracks.Add(track);
    tracksVersion2.Add(track);
}

List<SwapOp> swaps = [];
while ((line = Console.ReadLine()) is not null)
{
    string trimmed = line.Trim();
    if (trimmed.Length == 0)
    {
        break;
    }

    int[] split = [.. trimmed.Split('-').Select(int.Parse)];
    swaps.Add(new(split[0] - 1, split[1] - 1));
}

int testIndex = int.Parse(Console.ReadLine()!) - 1;
List<SwapOpVersion2> swapsVersion2 = [];
for (int i = 0; i < swaps.Count - 1; i++)
{
    int x = swaps[i].From;
    int y = swaps[i].To;
    int z = swaps[i + 1].From;
    swapsVersion2.Add(new(x, y, z));
}
swapsVersion2.Add(new(swaps[^1].From, swaps[^1].To, swaps[0].From));

int[] tracksVersion3 = [.. tracks];
for (int i = 0; i < swaps.Count; i++)
{
    (int from, int to) = swaps[i];
    Swap(tracks, from, to);
    SwapBlocks(tracksVersion3, from, to);
}

for (int i = 0; i < swapsVersion2.Count; i++)
{
    (int x, int y, int z) = swapsVersion2[i];
    Swap(tracksVersion2, x, y, z);
}

tracks[testIndex].Dump();
tracksVersion2[testIndex].Dump();
tracksVersion3[testIndex].Dump();

static void Swap<T>(List<T> list, int from, int to)
{
    T temp = list[from];
    list[from] = list[to];
    list[to] = temp;
}

static void Swap<T>(List<T> list, int x, int y, int z)
{
    T yValue = list[y];
    T zValue = list[z];
    list[y] = list[x];
    list[z] = yValue;
    list[x] = zValue;
}

static void SwapBlocks(int[] arr, int x, int y)
{
  if (x > y)
  {
    (x, y) = (y, x);
  }

  int blockLength = Math.Min(y - x, arr.Length - y);
  Memory<int> mutable = MemoryExtensions.AsMemory(arr);
  Memory<int> temp = new int[blockLength];
  Memory<int> xBlock = mutable.Slice(x,  blockLength);
  Memory<int> yBlock = mutable.Slice(y, blockLength);
  xBlock.CopyTo(temp);
  yBlock.CopyTo(xBlock);
  temp.CopyTo(yBlock);
}
