#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
//TreeNode root = "[4,-7,-3,null,null,-9,-3,9,-7,-4,null,6,null,-6,-6,null,null,0,6,5,null,9,null,null,-1,-4,null,null,null,-2]".DeserializeToBinaryTree();
TreeNode root = "[1,2]".DeserializeToBinaryTree();
var result = s.DiameterOfBinaryTree(root);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public int DiameterOfBinaryTree(TreeNode root) {
        int widest = int.MinValue;
        return Math.Max(deepest(root.left) + deepest(root.right), widest);

        int deepest(TreeNode? node)
        {
            if (node is null)
            {
                return 0;
            }

            int left = deepest(node.left);
            int right = deepest(node.right);
            widest = Math.Max(widest, left + right);

            return 1 + Math.Max(left, right);
        }
    }
}
