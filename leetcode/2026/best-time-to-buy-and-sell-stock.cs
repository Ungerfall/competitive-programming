#!/usr/bin/env dotnet run

using System.Text.Json;
using System.Text.Json.Serialization;

Solution s = new();
int[] prices = JsonSerializer.Deserialize<int[]>(
        "[7,1,5,3,6,4]",
        CorePrimitivesContext.Default.Int32Array)
    ?? throw new ArgumentNullException();
var result = s.MaxProfit(prices);
Console.WriteLine(result);

[JsonSerializable(typeof(int[]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;

public class Solution {
    public int MaxProfit(int[] prices) {
        int buy = 0;
        int profit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] < prices[buy])
            {
                buy = i;
            }
            else
            {
                profit = Math.Max(profit, prices[i] - prices[buy]);
            }

            //Console.WriteLine(profit);
        }

        return profit;
    }
}
