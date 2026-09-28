#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int n = 16;
var result = s.CountBits(n);
string print = string.Join(',', result);
Console.WriteLine(print);
result = s.CountBitsOn(n);
Console.WriteLine(string.Join(',', result));

public class Solution {
    public int[] CountBits(int n) {
        int[] result = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            int bitsCount = 0;
            int payload = i;
            while (payload > 0)
            {
                if (payload % 2 == 1)
                {
                    bitsCount++;
                }

                payload /= 2;
            }

            result[i] = bitsCount;
        }

        return result;
    }

    public int[] CountBitsOn(int n)
    {
        int[] result = new int[n + 1];
        for (int i = 0; i <= n; i++)
        {
            result[i] = result[i >> 1] + (i % 2);
        }

        return result;
    }
}
