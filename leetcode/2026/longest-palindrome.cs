#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
string candidate = "abccccdd";
var result = s.LongestPalindrome(candidate);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public int LongestPalindrome(string s)
    {
        HashSet<char> counter = [];
        int longest = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (counter.Remove(s[i]))
            {
                longest += 2;
            }
            else
            {
                counter.Add(s[i]);
            }
        }

        if (counter.Count > 0)
        {
            longest++;
        }

        return longest;
    }
}
