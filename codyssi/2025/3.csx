#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

record struct BoxRange(int A, int B);
record class Pile(BoxRange Left, BoxRange Right);

string? line = null;
const string digitTemplate = @"\d+";
int boxCount = 0;
int boxCountOverlapless = 0;
int maxBoxCount = 0;
Pile prev = new(new(0, 0), new(0, 0));
while ((line = Console.ReadLine()) is not null)
{
    MatchCollection matches = Regex.Matches(line, digitTemplate);
    int rangeLeft1 = int.Parse(matches[0].Value);
    int rangeRight1 = int.Parse(matches[1].Value);
    int rangeLeft2 = int.Parse(matches[2].Value);
    int rangeRight2 = int.Parse(matches[3].Value);
    Pile current = new(new(rangeLeft1, rangeRight1), new(rangeLeft2, rangeRight2));

    int range1Len = rangeRight1 - rangeLeft1 + 1;
    int range2Len = rangeRight2 - rangeLeft2 + 1;
    int overlapLen = Math.Max(0, Math.Min(rangeRight1, rangeRight2) - Math.Max(rangeLeft1, rangeLeft2) + 1);
    boxCount += range1Len + range2Len;
    boxCountOverlapless += range1Len + range2Len - overlapLen;
    maxBoxCount = Math.Max(maxBoxCount, countBoxesForAdjacent(prev, current));
    prev = current;
}

boxCount.Dump();
boxCountOverlapless.Dump();
maxBoxCount.Dump();

static int countBoxesForAdjacent(Pile prev, Pile current)
{
    List<BoxRange> boxes = [prev.Left, prev.Right, current.Left, current.Right];
    boxes.Sort(comparison: (leftRange, rightRange) =>
    {
        if (leftRange.A == rightRange.A)
        {
            return leftRange.B.CompareTo(rightRange.B);
        }

        return leftRange.A.CompareTo(rightRange.A);
    });

    return 1;
}
