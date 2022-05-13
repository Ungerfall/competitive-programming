<Query Kind="Program" />

void Main()
{
	ThroneInheritance t = new ThroneInheritance("king"); // order: king
	t.Birth("king", "andy"); // order: king > andy
	t.Birth("king", "bob"); // order: king > andy > bob
	t.Birth("king", "catherine"); // order: king > andy > bob > catherine
	t.Birth("andy", "matthew"); // order: king > andy > matthew > bob > catherine
	t.Birth("bob", "alex"); // order: king > andy > matthew > bob > alex > catherine
	t.Birth("bob", "asha"); // order: king > andy > matthew > bob > alex > asha > catherine
	t.GetInheritanceOrder().Dump(); // return ["king", "andy", "matthew", "bob", "alex", "asha", "catherine"]
	t.Death("bob"); // order: king > andy > matthew > bob > alex > asha > catherine
	t.GetInheritanceOrder().Dump(); // return ["king", "andy", "matthew", "alex", "asha", "catherine"]}
}

public class ThroneInheritance
{
	private readonly TreeNode king;
	private readonly Dictionary<string, TreeNode> index = new Dictionary<string, TreeNode>();
	public ThroneInheritance(string kingName)
	{
		king = new TreeNode(kingName);
		index[kingName] = king;
	}

	public void Birth(string parentName, string childName)
	{
		TreeNode node = index[parentName];
		TreeNode child = new(childName);
		node.children.Add(child);
		index[childName] = child;
	}

	public void Death(string name)
	{
		TreeNode node = index[name];
		node.isAlive = false;
	}

	public IList<string> GetInheritanceOrder()
	{
		List<string> output = new();
		Stack<TreeNode> dfs = new();
		dfs.Push(king);
		while (dfs.Count > 0)
		{
			TreeNode node = dfs.Pop();
			if (node.isAlive)
				output.Add(node.val);

			for (int i = node.children.Count - 1; i >= 0; i--)
			{
				dfs.Push(node.children[i]);
			}
		}

		return output;
	}

	public class TreeNode
	{
		public string val;
		public bool isAlive;
		public List<TreeNode> children;
		public TreeNode(string val, List<TreeNode> children = null)
		{
			this.val = val;
			this.children = children ?? new();
			this.isAlive = true;
		}
	}
}
