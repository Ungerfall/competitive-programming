<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.MaxProduct(new[] { 2, 3, -2, 4 }).Dump();
	s.MaxProduct(System.Text.Json.JsonSerializer.Deserialize<int[]>("[2,-5,-2,-4,3]")).Dump();
	s.MaxProduct(System.Text.Json.JsonSerializer.Deserialize<int[]>("[-2,0,-1]")).Dump();
	s.MaxProduct(System.Text.Json.JsonSerializer.Deserialize<int[]>("[7,-2,-4]")).Dump();
	s.MaxProduct(System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,0,-1,2,3,-5,-2]")).Dump();
}
public class Solution
{
	public int MaxProduct(int[] nums)
	{
		if (nums.Length == 1)
		{
			return nums[0];
		}

		int max = nums[0];
		int currentNegativeProduct = nums[0] >= 0 ? 1 : nums[0];
		int currentPositiveRunningProduct = nums[0] <= 0 ? 1 : nums[0];
		int currentRunningProduct = nums[0] == 0 ? 1 : nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			int num = nums[i];
			if (num == 0)
			{
				currentNegativeProduct = 1;
				currentPositiveRunningProduct = 1;
				currentRunningProduct = 1;
				max = Math.Max(max, 0);
				continue;
			}

			currentRunningProduct *= num;
			if (num > 0)
			{
				currentPositiveRunningProduct *= num;
				currentNegativeProduct *= num;
				max = Math.Max(max, Math.Max(currentPositiveRunningProduct, currentRunningProduct));
			}
			else // negative
			{
				int product = currentNegativeProduct * num;
				if (product < 0)
				{
					currentNegativeProduct = product;
					currentPositiveRunningProduct = 1;
				}
				else
				{
					currentNegativeProduct = currentPositiveRunningProduct * num;
					currentPositiveRunningProduct = product;
					max = Math.Max(max, Math.Max(currentPositiveRunningProduct, currentRunningProduct));
				}
			}
		}

		return max;
	}
}

