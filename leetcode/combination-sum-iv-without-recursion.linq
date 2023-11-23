<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.CombinationSum4(System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,3]"), 4).Dump();
	s.CombinationSum4(System.Text.Json.JsonSerializer.Deserialize<int[]>("[9]"), 3).Dump();
}

public class Solution
{
	public int CombinationSum4(int[] nums, int target)
	{
		var subCombinations = new int[target + 1];
		subCombinations[0] = 1;
		for (int x = 0; x <= target; x++)
		{
			for (int j = 0; j < nums.Length; j++)
			{
				if (x - nums[j] >= 0)
				{
					subCombinations[x] += subCombinations[x - nums[j]];
				}
			}
		}
		
		return subCombinations[target];
	}
}

