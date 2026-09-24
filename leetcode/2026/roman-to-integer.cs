#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
//string str = "III";
//string str = "LVIII";
string str = "MCMXCIV";
var result = s.RomanToInt(str);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    private static Dictionary<char, int> map = new()
    {
        ['I'] = 1,
        ['V'] = 5,
        ['X'] = 10,
        ['L'] = 50,
        ['C'] = 100,
        ['D'] = 500,
        ['M'] = 1000,
    };

    public int RomanToInt(string s) {
        int parsed = 0;
        int i = 0;
        for (; i < s.Length - 1; i++)
        {
            int current = map[s[i]];
            int next = map[s[i+1]];
            if (current < next)
            {
                parsed += (next - current);
                i++;
            }
            else
            {
                parsed += current;
            }

            //Console.WriteLine(parsed);
        }

        if (i < s.Length)
        {
            parsed += map[s[i]];
        }

        return parsed;
    }
}
