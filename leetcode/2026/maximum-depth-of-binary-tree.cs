#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
TreeNode root = "[1,null,2]".DeserializeToBinaryTree();
//root.Print(Console.Out);
var result = s.MaxDepth(root);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public int MaxDepth(TreeNode root) {
        return deepest(root);

        int deepest(TreeNode node)
        {
            if (node is null)
            {
                return 0;
            }

            return 1 + Math.Max(deepest(node.left), deepest(node.right));
        }
    }
}
