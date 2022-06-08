<Query Kind="Program" />

void Main()
{
	Solution s = new();
	int[] nums = System.Text.Json.JsonSerializer.Deserialize<int[]>("[-1,0,3,5,9,12]");
	s.Search(nums, 2).Dump();
}

public class Solution
{
	public int Search(int[] nums, int target)
	{
		int left = 0;
		int right = nums.Length - 1;
		while (left <= right)
		{
			int mid = left + ((right - left) / 2);
			//(mid, left, right).ToString().Dump();
			if (nums[mid] == target)
				return mid;
				
			if (target < nums[mid])
			{
				right = mid - 1;
			}
			else
			{
				left = mid + 1;
			}
		}
		
		return -1;
	}
}