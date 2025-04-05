#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

string? line = null;
int totalAlphabeticalComposition = 0;
int reducedCount = 0;
int reducedWithoutHyphenCount = 0;
while ((line = Console.ReadLine()) is not null)
{
    int alphabeticalComposition = 0;
    int hyphenCount = 0;
    for (int i = 0; i < line.Length; i++)
    {
        char ch = line[i];
        if (ch >= 'a' && ch <= 'z')
        {
            alphabeticalComposition++;
        }

        if (ch == '-')
        {
            hyphenCount++;
        }
    }

    ReadOnlySpan<char> span = line;
    reducedCount += ReduceAndCount(span);
    Span<Range> ranges = stackalloc Range[hyphenCount + 1];
    int chunks = span.Split(ranges, '-');
    Debug.Assert(chunks == ranges.Length);
    for (int i = 0; i < chunks; i++)
    {
        Range range = ranges[i];
        ReadOnlySpan<char> chunk = span[range];
        reducedWithoutHyphenCount += ReduceAndCount(chunk);
    }

    reducedWithoutHyphenCount += hyphenCount;
    totalAlphabeticalComposition += alphabeticalComposition;
}

totalAlphabeticalComposition.Dump();
reducedCount.Dump();
reducedWithoutHyphenCount.Dump();

static int ReduceAndCount(ReadOnlySpan<char> span)
{
    int numericalCompostion = 0;
    for (int i = 0; i < span.Length; i++)
    {
        char ch = span[i];
        if (ch >= '0' && ch <= '9')
        {
            numericalCompostion++;
        }
    }

    return Math.Abs((span.Length - numericalCompostion) - numericalCompostion);
}
