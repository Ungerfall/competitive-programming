#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

string? line = null;
int uncorruptedCount = 0;
long uncorruptedValue = 0L;
long total = 0L;
int preceding = 0;
while ((line = Console.ReadLine()) is not null)
{
    for (int i = 0; i < line.Length; i++)
    {
        char ch = line[i];
        int value;
        if ((ch >= 'a' && ch <= 'z'))
        {
            value = (ch - 'a' + 1);
            uncorruptedCount++;
            uncorruptedValue += value;
        }
        else if ((ch >= 'A' && ch <= 'Z'))
        {
            value = (ch - 'A' + 27);
            uncorruptedCount++;
            uncorruptedValue += value;
        }
        else
        {
            int fixedValue = (preceding * 2) - 5;
            fixedValue += fixedValue switch
            {
                < 1 => 52,
                > 52 => -52,
                _ => 0
            };
            Debug.Assert(fixedValue >= 1 && fixedValue <= 52);
            value = fixedValue;
        }

        total += value;
        preceding = value;
    }
}

uncorruptedCount.Dump();
uncorruptedValue.Dump();
total.Dump();
