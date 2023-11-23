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
		var subCombinations = new int?[target + 1];
		return getCombinations(target);
		
		int getCombinations(int left)
		{
			if (left == 0)
			{
				return 1;
			}
			
			if (subCombinations[left] != null)
			{
				return subCombinations[left].Value;
			}
			
			int combinations = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				if (left - nums[i] < 0)
				{
					continue;
				}
				
				combinations += getCombinations(left - nums[i]);
			}
			
			subCombinations[left] = combinations;
			return combinations;
		}
	}
}

