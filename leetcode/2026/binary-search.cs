#!/usr/bin/env dotnet run

using System.Text.Json.Serialization;

int[] nums = "[-1,0,3,5,9,12]".DeserializeToArray();
int target = 2;
Solution s = new();
var result = s.Search(nums, target);
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

    extension(string s)
    {
        public int[] DeserializeToArray()
        {
            return System.Text.Json.JsonSerializer.Deserialize<int[]>(
                    s,
                    CorePrimitivesContext.Default.Int32Array)
                ?? throw new ArgumentNullException();
        }
    }
}

public class Solution {
    public int Search(int[] nums, int target) {
        int searchResult = Array.BinarySearch(nums, target);

        if (searchResult < 0)
        {
            return - 1;
        }

        return searchResult;
    }
}
