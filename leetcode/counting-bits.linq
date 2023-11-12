<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.CountBits(100).Dump();
}

public class Solution
{
	public int[] CountBits(int n)
	{
		if (n == 0)
			return new int[] { 0 };
		if (n == 1)
			return new int[] { 0, 1 };

		int[] ones = new int[n + 1];
		ones[0] = 0;
		ones[1] = 1;
		int @base = 1;
		for (int i = 2; i <= n; i++)
		{
			if (i >= @base * 2)
			{
				@base *= 2;
			}

			ones[i] = 1 + ones[i - @base];
		}

		return ones;
	}
}