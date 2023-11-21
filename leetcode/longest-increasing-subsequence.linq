<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.LengthOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[10,9,2,5,3,7,101,18]")).Dump();
	s.LengthOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[0,1,0,3,2,3]")).Dump();
	s.LengthOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[7,7,7,7,7,7,7]")).Dump();
	s.LengthOfLIS(System.Text.Json.JsonSerializer.Deserialize<int[]>("[4,10,4,3,8,9]")).Dump();
}
public class Solution
{
	public int LengthOfLIS(int[] nums)
	{
		int best = 1;
		var memo = new int?[nums.Length];
		memo[^1] = 1;
		for (int i = 0; i < nums.Length - 1; i++)
		{
			var len = getLIS(i);
			best = Math.Max(best, len);
		}
		
		//memo.Dump();
		return best;
		
		int getLIS(int i)
		{
			if (i == nums.Length - 1)
			{
				return 1;
			}
			
			if (memo[i] is not null)
			{
				return memo[i].Value;
			}
			
			int res = 1;
			for (int j = i + 1; j < nums.Length; j++)
			{
				if (nums[j] > nums[i])
				{
					res = Math.Max(res, 1 + getLIS(j));
				}
			}
			
			memo[i] = Math.Max(memo[i] ?? 1, res);
			return res;
		}
	}
}

