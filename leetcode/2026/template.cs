#!/usr/bin/env dotnet run

using System.Text;
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
[JsonSerializable(typeof(int[][]))]
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

        public int[][] DeserializeTo2DJaggedArray()
        {
            return System.Text.Json.JsonSerializer.Deserialize<int[][]>(
                    s,
                    CorePrimitivesContext.Default.Int32ArrayArray)
                ?? throw new ArgumentNullException();
        }
    }

    extension<T>(T[][] array)
    {
        public void Print(TextWriter tw)
        {
            StringBuilder sb = new();
            for (int row = 0; row < array.Length; row++)
            {
                sb.AppendJoin(',', array[row]);
                sb.AppendLine();
            }

            tw.WriteLine(sb.ToString());
        }
    }
}

