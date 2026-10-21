#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution solution = new();
string[] strings = ["pwwkew", "abcabcbb", "bbbbb", "S", "ccbbcc", "qwerty", "baaabca"];
foreach (string s in strings)
{
    var result = solution.LengthOfLongestSubstring(s);
    string print = result.ToString();
    Console.WriteLine($"result: {print}");
}

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        Dictionary<char, int> positionByChar = [];
        int maxLen = 0;
        int left = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (positionByChar.TryGetValue(s[i], out int position))
            {
                left = Math.Max(left, position + 1);
            }

            positionByChar[s[i]] = i;
            maxLen = Math.Max(maxLen, i - left + 1);
        }

        return maxLen;
    }
}
