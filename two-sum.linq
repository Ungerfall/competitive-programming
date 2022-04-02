<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.TwoSum(new[] {-3,4,3,90}, 0).Dump();
}
public class Solution
{
	public int[] TwoSum(int[] nums, int target)
	{
		var indicies = new int[2];
		var visited = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; i++)
		{
			var curr = nums[i];
			if (visited.TryGetValue(target-curr, out int ix))
			{
				indicies[0] = ix;
				indicies[1] = i;
				break;
			}
			
			visited[curr] = i;
		}
		
		return indicies;
	}
}

// You can define other methods, fields, classes and namespaces here