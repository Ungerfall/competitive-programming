<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.NumberOfSteps(14).Dump();
	s.NumberOfSteps(8).Dump();
	s.NumberOfSteps(123).Dump();
	
}

public class Solution
{
	public int NumberOfSteps(int num)
	{
		int steps = 0;
		while (num != 0)
		{
			if (num % 2 == 0)
				num /= 2;
			else
				num -= 1;
				
			steps++;
		}
		
		return steps;
	}
}