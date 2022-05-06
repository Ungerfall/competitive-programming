<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.CountOperations(2, 3).Dump();
	s.CountOperations(10, 10).Dump();
}

public class Solution
{
	public int CountOperations(int num1, int num2)
	{
		if (num1 == 0 || num2 == 0)
			return 0;
		if (num1 == num2)
			return 1;
			
		int ops = 0;
		while (num1 != 0 && num2 != 0)
		{
			if (num1 >= num2)
				num1 -= num2;
			else
				num2 -= num1;
				
			ops++;
		}
		
		return ops;
	}
}