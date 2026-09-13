#!/usr/bin/env dotnet run

using System.Text.Json.Serialization;

Solution s = new();
string left = "rat";//"anagram";
string right = "car";//"nagaram";
var result = s.IsAnagram(left, right);
string print = result.ToString();
Console.WriteLine(result);

[JsonSerializable(typeof(int[]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;

public static class TemplateExtensions
{
    extension<T>(Dictionary<T, int> counter)
        where T : notnull
    {
        public Dictionary<T, int> Increment(T key)
        {
            counter[key] = counter.GetValueOrDefault(key) + 1;
            return counter;
        }

        public Dictionary<T, int> Decrement(T key)
        {
            counter[key] = counter.GetValueOrDefault(key) - 1;
            return counter;
        }
    }
}

public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> counter = [];

        for (int i = 0; i < s.Length; i++)
        {
            counter.Increment(s[i]);
            counter.Decrement(t[i]);
        }

        bool bad = counter
            .Values
            .Any(x => x != 0);
        
        return !bad;
    }
}
