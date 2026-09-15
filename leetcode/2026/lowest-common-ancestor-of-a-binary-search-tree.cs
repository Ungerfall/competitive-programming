#!/usr/bin/env dotnet run

#:include utils.cs

using System.Collections.Immutable;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

Solution s = new();
TreeNode root = "[5,3,6,2,4,null,null,1]".DeserializeToBinarySearchTree();
TreeNode p = new(1);
TreeNode q = new(3);
var result = s.LowestCommonAncestor(root, p, q);
Console.WriteLine(result.val);

public class Solution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val == p.val || root.val == q.val)
        {
            return root;
        }

        List<TreeNode> leftPath = [];
        List<TreeNode> rightPath = [];
        _ = findPath(root, leftPath, p);
        _ = findPath(root, rightPath, q);


        TreeNode lceNode = root;
        for (int i = 0; i < leftPath.Count && i < rightPath.Count; i++)
        {
            if (leftPath[i].val != rightPath[i].val)
            {
                break;
            }

            lceNode = leftPath[i];
        }

        return lceNode;

        bool findPath(TreeNode? node, List<TreeNode> path, TreeNode target)
        {
            if (node is null)
            {
                return false;
            }

            path.Add(node);
            if (node.val == target.val || findPath(node.left, path, target) || findPath(node.right, path, target))
            {
                return true;
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }
    }
}
