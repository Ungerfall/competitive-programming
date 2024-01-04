<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.FindNumberOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,3,5,4,7]")).Dump();
	s.FindNumberOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[2,2,2,2,2]")).Dump();
	s.FindNumberOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,4,3,5,4,7,2]")).Dump();
	s.FindNumberOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,4,3]")).Dump();
}

public class Solution
{
	public int FindNumberOfLIS(int[] nums)
	{
		int[] longest = new int[nums.Length];
		int[] counts = new int[nums.Length];
		Array.Fill(longest, 1);
		Array.Fill(counts, 1);
		int maxLongest = 0;
		int maxLongestCount = 0;
		for (int i = nums.Length - 1; i >= 0; i--)
		{
			int maxLength = 1;
			int maxCount = 1;
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[i] < nums[j])
				{
					int longestPrev = longest[j];
					int countPrev = counts[j];
					if (longestPrev + 1 > maxLength)
					{
						maxLength = longestPrev + 1;
						maxCount = countPrev;
					}
					else if (longestPrev + 1 == maxLength)
					{
						maxCount += countPrev;
					}
				}
			}
			
			if (maxLength > maxLongest)
			{
				maxLongest = maxLength;
				maxLongestCount = maxCount;
			}
			else if (maxLength == maxLongest)
			{
				maxLongestCount += maxCount;
			}
			
			longest[i] = maxLength;
			counts[i] = maxCount;
		}

		return maxLongestCount;
	}
}

