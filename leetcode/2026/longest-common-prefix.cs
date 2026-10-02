#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
string[] strs = """["dog","racecar","car"]""".DeserializeToArray<string>(CorePrimitivesContext.Default.StringArray);
var result = s.LongestCommonPrefix(strs);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length == 1)
        {
            return strs[0];
        }

        int longestLen = 0;
        int min = strs.Min(x => x.Length);
        for (; longestLen < min; longestLen++)
        {
            char common = strs[0][longestLen];
            if (strs.Any(x => x[longestLen] != common))
            {
                break;
            }
        }

        return strs[0].Substring(0, longestLen);
    }
}
