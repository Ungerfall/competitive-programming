#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
TreeNode root = "[1,2,3,4,5,6,null,8]".DeserializeToBinarySearchTree();
var result = s.IsBalanced(root);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public bool IsBalanced(TreeNode root) {
        if (root is null)
        {
            return true;
        }

        int? left = getHeight(root.left, 1);
        int? right = getHeight(root.right, 1);

        return (left.HasValue && right.HasValue && Math.Abs(left.Value - right.Value) <= 1);

        int? getHeight(TreeNode node, int height)
        {
            if (node is null)
            {
                return height;
            }

            int? left = getHeight(node.left, height + 1);
            int? right = getHeight(node.right, height + 1);

            if (!left.HasValue || !right.HasValue)
            {
                return null;
            }

            if (Math.Abs(left.Value - right.Value) > 1)
            {
                return null;
            }

            return Math.Max(left.Value, right.Value);
        }
    }
}
