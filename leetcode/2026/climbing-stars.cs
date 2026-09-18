#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int n = 44;
var result = s.ClimbStairs(n);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public int ClimbStairs(int n)
    {
        Dictionary<int, int> knownSolutions = [];
        return climb(0);

        int climb(int pos)
        {
            if (pos == n)
            {
                return 1;
            }

            if (pos > n)
            {
                return 0;
            }

            if (knownSolutions.TryGetValue(pos, out int known))
            {
                return known;
            }

            knownSolutions[pos] = climb(pos + 1) + climb(pos + 2);

            return knownSolutions[pos];
        }
    }
}
