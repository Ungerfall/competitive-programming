#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int n = 2147483645;
var result = s.HammingWeight(n);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public int HammingWeight(int n) {
        int weight = 0;
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                weight++;
            }

            n /= 2;
        }

        return weight;
    }
}
