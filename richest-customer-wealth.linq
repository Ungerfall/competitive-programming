<Query Kind="Program" />

void Main()
{
}

public class Solution
{
	public int MaximumWealth(int[][] accounts)
	{
		int max = 0;
		for (int i = 0; i < accounts.Length; i++)
		{
			max = Math.Max(max, accounts[i].Sum());
		}
		
		return max;
	}
}