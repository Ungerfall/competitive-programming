<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);
	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);
	
	Solution s = new();
	s.DiameterOfBinaryTree(root).Dump();
	
	root = new TreeNode(1);
	root.left = new TreeNode(2);
	
	s.DiameterOfBinaryTree(root).Dump();
}

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
}

public class Solution
{
	public int DiameterOfBinaryTree(TreeNode root)
	{
		return DFS(root).d;
	}
	
	public static (int d, int h) DFS(TreeNode node)
	{
		if (node == null)
		{
			return (0, 0);
		}
		
		var left = DFS(node.left);
		var right = DFS(node.right);
		
		int bestD = Math.Max(left.h + right.h, Math.Max(left.d, right.d));
		int height = 1 + Math.Max(left.h, right.h);
		
		return (bestD, height);
	}
}