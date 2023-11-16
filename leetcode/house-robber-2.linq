<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.Rob(new int[] { 1 }).Dump();
}

public class Solution {
    public int Rob(int[] nums) {
        if (nums.Length == 1)
        {
            return nums[0];
        }
        
        int?[] memo = new int?[nums.Length + 1];
        Span<int> numsSlice = nums;
        var robFirstMax = rob(numsSlice[..^1], 0);
        Array.Fill(memo, null);
        var skipFirstMax = rob(numsSlice[1..], 0);

        return Math.Max(robFirstMax, skipFirstMax);

        int rob(Span<int> nums, int i)
        {
            if (i >= nums.Length)
            {
                return 0;
            }

            if (memo[i] is not null)
            {
                return memo[i].Value;
            }

            var maxRob = Math.Max(rob(nums, i + 2) + nums[i], rob(nums, i + 1));
			memo[i] = maxRob;
			return maxRob;
		}
	}
}