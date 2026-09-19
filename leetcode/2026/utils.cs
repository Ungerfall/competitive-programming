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

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
        next = null;
    }
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

            return buildTree(index: 0, values) ?? throw new ArgumentNullException();

            static TreeNode? buildTree(int index, ReadOnlySpan<int?> values)
            {
                if (index >= values.Length)
                {
                    return null;
                }

                int? value = values[index];
                if (!value.HasValue)
                {
                    return null;
                }

                TreeNode node = new(value.Value);
                node.left = buildTree(index * 2 + 1, values);
                node.right = buildTree(index * 2 + 2, values);

                return node;
            }
        }

        public ListNode? DeserializeToLinkedList()
        {
            int[] values = s.DeserializeToArray();
            if (values.Length == 0)
            {
                return null;
            }

            ListNode head = new(values[0]);
            ListNode it = head;
            for (int i = 1; i < values.Length; i++)
            {
                it.next = new(values[i]);
                it = it.next;
            }

            return head;
        }
    }

    extension(ListNode? node)
    {
        public void Print(TextWriter tw)
        {
            if (node is null)
            {
                return;
            }

            ListNode it = node;
            while (it is not null)
            {
                tw.Write(it.val + ",");
                it = it.next;
            }

            tw.WriteLine();
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
