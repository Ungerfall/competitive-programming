#!/usr/bin/env dotnet run

using System.Text.Json.Serialization;

Solution s = new();
var result = s.TODO(...);
string print = result switch
{
    [] => "[]",
    [..] => string.Join(',', result),
    _ => result.ToString()
};

[JsonSerializable(typeof(int[]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;

public static class TemplateExtensions
{
    extension(Dictionary<T, int> counter)
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
