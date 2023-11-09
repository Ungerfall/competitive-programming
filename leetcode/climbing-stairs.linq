<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	var s = new Solution();
	
	s.ClimbStairs(45).Dump("start");
}

public class Solution
{
	public long ClimbStairs(int n)
	{
		if (n == 1)
			return 1;

		var memo = new long[n + 1];
		memo[1] = 1;
		memo[2] = 2;
		for (int i = 3; i <= n; i++)
		{
			memo[i] = memo[i - 1] + memo[i - 2];
		}

		return memo[n];
	}
}