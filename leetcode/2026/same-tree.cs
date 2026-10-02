#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
TreeNode p = "[1,2,3]".DeserializeToBinaryTree();
TreeNode q = "[1,2,3]".DeserializeToBinaryTree();
var result = s.IsSameTree(p, q);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        Queue<(TreeNode?, TreeNode?)> toVisit = [];
        toVisit.Enqueue((p, q));
        while (toVisit.Count > 0)
        {
            (TreeNode? one, TreeNode? another) = toVisit.Dequeue();
            if (one?.val != another?.val)
            {
                return false;
            }

            if (one is null && another is null)
            {
                continue;
            }

            toVisit.Enqueue((one.left, another.left));
            toVisit.Enqueue((one.right, another.right));
        }

        return true;
    }
}
