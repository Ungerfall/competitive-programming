#!/usr/bin/env dotnet run

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
var result = s.IsPalindrome("0P");
Console.WriteLine(result);

[JsonSerializable(typeof(int[]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;

public class Solution
{
    public bool IsPalindrome(string s)
    {
        StringBuilder sb = new();
        for (int i = 0; i < s.Length; i++)
        {
            if ((s[i] >= 'a' && s[i] <= 'z')
                    || (s[i] >= 'A' && s[i] <= 'Z')
                    || (s[i] >= '0' && s[i] <= '9'))
            {
                sb.Append(char.ToLower(s[i]));
            }
        }

        //Console.WriteLine(sb.ToString());
        ReadOnlySpan<char> span = sb.ToString().AsSpan();
        bool valid = true;
        int len = span.Length;
        int middle = (len + 1) / 2;
        for (int i = 0; i < middle; i++)
        {
            if (span[i] != span[len - i - 1])
            {
                return false;
            }
        }

        return valid;
    }
}
