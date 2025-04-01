#!/usr/bin/env dotnet-script

#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

string? line = null;
long memoryUnits = 0L;
long compressedUnits = 0L;
long lossless = 0L;
while ((line = Console.ReadLine()) is not null)
{
    ReadOnlySpan<char> trimmed = line.Trim();
    memoryUnits += GetMemoryUnits(trimmed);
    int compressionRoundedDown = trimmed.Length / 10;
    compressedUnits += GetMemoryUnits(trimmed[..compressionRoundedDown]);
    compressedUnits += GetMemoryUnits(trimmed[^compressionRoundedDown..]);
    compressedUnits += GetMemoryUnits(trimmed.Length - (2 * compressionRoundedDown));
    char prev = trimmed[0];
    int same = 1;
    for (int i = 1; i < trimmed.Length; i++)
    {
        if (trimmed[i] == prev)
        {
            same++;
        }
        else
        {
            lossless += GetMemoryUnits(same);
            lossless += GetMemoryUnits(prev);
            same = 1;
            prev = trimmed[i];
        }
    }

    lossless += GetMemoryUnits(same);
    lossless += GetMemoryUnits(prev);
}

memoryUnits.Dump();
compressedUnits.Dump();
lossless.Dump();

static int GetMemoryUnits(char ch)
{
    return ch - 'A' + 1;
}
static int GetMemoryUnits(ReadOnlySpan<char> span)
{
    int units = 0;
    for (int i = 0; i < span.Length; i++)
    {
        char x = span[i];
        if (!(x >= 'A' && x <= 'Z'))
            throw new ArgumentException("not in ['A'..'Z']", nameof(x));

        units += x - 'A' + 1;
    }

    return units;
}
static int GetMemoryUnits(int compression)
{
    ReadOnlySpan<char> chars = compression.ToString();
    int units = 0;
    for (int i = 0; i < chars.Length; i++)
    {
        char x = chars[i];
        units += x - '0';
    }

    return units;
}

