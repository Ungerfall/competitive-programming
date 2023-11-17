<Query Kind="Program" />

void Main()
{
	(int.MaxValue + int.MinValue).Dump();
	var s = new Solution();
	s.MaxSubArray(new[] { -2, 1, -3, 4, -1, 2, 1, -50000, 50000 }).Dump();
	s.MaxSubArray(new[] { 5, 4, -1, 7, 8 }).Dump();
	s.MaxSubArray(new[] { -2, -1 }).Dump();
	s.MaxSubArray(new[] { -1, -2 }).Dump();
}

public class Solution
{
	public int MaxSubArray(int[] nums)
	{
		if (nums.Length == 1)
		{
			return nums[0];
		}

		int maxIndex = 0;
		int maxValue = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			maxValue = Math.Max(maxValue, nums[i]);
			nums[i] = (nums[i - 1] < 0 ? 0 : nums[i - 1]) + nums[i];
			maxIndex = nums[i] > nums[maxIndex] ? i : maxIndex;
		}

		if (maxValue <= 0)
		{
			return maxValue;			
		}
		
		return nums[maxIndex];
	}
}

