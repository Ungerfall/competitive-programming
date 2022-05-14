<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.GuessNumber(2).Dump();
	
}

public class Solution : GuessGame
{
	public int GuessNumber(int n)
	{
		if (n == 1)
			return 1;
			
		int left = 1;
		int right = n;
		int mid = left + (right - left) / 2;
		int guess;
		while ((guess = base.guess(mid)) != 0)
		{
			if (guess == -1)
			{
				right = mid;
			}
			else
			{
				left = mid + 1;
				
			}
			
			mid = left + (right - left) / 2;
		}
		
		return mid;
	}
}
public class GuessGame
{
	protected int guess(int num)
	{
		return num > 2
			? -1
			: num == 2
				? 0
				: 1;
	}
}