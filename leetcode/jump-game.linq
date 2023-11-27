<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.CanJump(System.Text.Json.JsonSerializer.Deserialize<int[]>("[2,3,1,1,4]")).Dump();
	s.CanJump(System.Text.Json.JsonSerializer.Deserialize<int[]>("[3,2,1,0,4]")).Dump();
}

public class Solution
{
	public bool CanJump(int[] nums)
	{
		bool?[] subPaths = new bool?[nums.Length];
		return jump(0);
		
		bool jump(int index)
		{
			if (index >= nums.Length)
			{
				return false;
			}
			
			if (index == nums.Length - 1)
			{
				return true;
			}
			
			if (subPaths[index] != null)
			{
				return subPaths[index].Value;
			}
			
			for (int i = nums[index]; i >= 1; i--)
			{
				if (jump(index + i))
				{
					subPaths[index] = true;
					return true;
				}
			}
			
			subPaths[index] = false;
			return false;
		}
	}
}
