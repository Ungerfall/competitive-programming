#!/usr/bin/env dotnet run

using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

[JsonSerializable(typeof(int?))]
[JsonSerializable(typeof(int?[]))]
[JsonSerializable(typeof(int[]))]
[JsonSerializable(typeof(int[][]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;

public class TreeNode
{
    public int val;
    public TreeNode? left;
    public TreeNode? right;
    public TreeNode(int x) { val = x; }
}

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

        public T[] DeserializeToArray<T>(JsonTypeInfo<T[]> jsonTypeInfo)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T[]>(
                    s,
                    jsonTypeInfo)
                ?? throw new ArgumentNullException();
        }

        public int[][] DeserializeTo2DJaggedArray()
        {
            return System.Text.Json.JsonSerializer.Deserialize<int[][]>(
                    s,
                    CorePrimitivesContext.Default.Int32ArrayArray)
                ?? throw new ArgumentNullException();
        }

        public TreeNode DeserializeToBinarySearchTree()
        {
            int?[] values = s.DeserializeToArray<int?>(CorePrimitivesContext.Default.NullableInt32Array);

            return buildTree(index: 0, values);

            static TreeNode? buildTree(int index, ReadOnlySpan<int?> values)
            {
                if (index >= values.Length)
                {
                    return null;
                }

                if (!values[index].HasValue)
                {
                    return null;
                }

                TreeNode node = new(values[index].Value);
                node.left = buildTree(index * 2 + 1, values);
                node.right = buildTree(index * 2 + 2, values);

                return node;
            }
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
