<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.FindTargetSumWays(new int[]{1,0}, 1).Dump();
	
}
public class Solution {
    public int FindTargetSumWays(int[] nums, int target) {
    	var memo = new Dictionary<(int index, int sum), int>();

		return countWays(0, 0);
		
		int countWays(int i, int total)
		{
			if (i == nums.Length)
			{
				return total == target ? 1 : 0;
			}
			
			var key = (i, total);
			if (memo.ContainsKey(key))
			{
				return memo[key];
			}
			
			int ways = countWays(i + 1, total + nums[i]) + countWays(i + 1, total - nums[i]);
			memo[key] = ways;
			return ways;
		}
	}
}