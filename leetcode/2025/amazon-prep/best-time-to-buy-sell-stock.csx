#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

int[] prices = [7, 1, 5, 3, 6, 4];

Solution s = new();
s.MaxProfit(prices).Dump();

public class Solution
{
    public int MaxProfit(int[] prices)
    {
      int max = 0;
      int left = 0;
      for (int right; right < prices.Length; right++)
      {
      }

      return max;
    }
}
