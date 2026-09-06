#!/usr/bin/env dotnet run

using System.Text;
using System.Text.Json.Serialization;

TreeNode? treeNode = TreeNode.FromJsonArray("[4,2,7,1,3,6,9]");
Console.WriteLine(treeNode);
Solution s = new();
var result = s.InvertTree(treeNode);
Console.WriteLine(result);

[JsonSerializable(typeof(int[]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public static TreeNode? FromJsonArray(string jsonArray)
    {
        int[] values = System.Text.Json.JsonSerializer.Deserialize<int[]>(jsonArray, CorePrimitivesContext.Default.Int32Array)
            ?? throw new ArgumentNullException();

        return buildTree(index: 0, values);

        static TreeNode? buildTree(int index, int[] values)
        {
            if (index >= values.Length)
            {
                return null;
            }

            return new(values[index],
                    left: buildTree(index * 2 + 1, values),
                    right: buildTree(index * 2 + 2, values));
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        Queue<TreeNode> queue = new();
        queue.Enqueue(this);
        while (queue.Count > 0)
        {
            TreeNode root = queue.Dequeue();
            sb.Append(root.val + " ");

            if (root.left is not null)
            {
                queue.Enqueue(root.left);
            }

            if (root.right is not null)
            {
                queue.Enqueue(root.right);
            }
        }

        sb.Length--;
        return sb.ToString();
    }
}

public class Solution
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
        {
            return root;
        }

        Queue<TreeNode> levelOrder = new();
        levelOrder.Enqueue(root);
        while (levelOrder.Count > 0)
        {
            TreeNode current = levelOrder.Dequeue();
            Swap(ref current.left, ref current.right);
            if (current.left is not null)
            {
                levelOrder.Enqueue(current.left);
            }

            if (current.right is not null)
            {
                levelOrder.Enqueue(current.right);
            }
        }

        return root;

        static void Swap(ref TreeNode? left, ref TreeNode? right)
        {
            TreeNode? tmp = left;
            left = right;
            right = tmp;
        }
    }
}
