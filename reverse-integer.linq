<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.Reverse(123).Dump();
	s.Reverse(-123).Dump();
	s.Reverse(120).Dump();
	s.Reverse(-2147483648).Dump();
}

public class Solution
{
	public int Reverse(int x)
	{
		int result = 0;
		int mul = (int)Math.Pow(10, IntegerLen(x) - 1);
		int divider = 10;
		while (x != 0)
		{
			try
			{	        
				checked
				{
					//(x, mul).ToString().Dump();
					result += x % 10 * mul;
				}
			}
			catch (Exception)
			{
				return 0;
			}
			
			mul /= 10;
			x /= divider;
			//(mul, x, divider).ToString().Dump();
		}
		
		return result;
	}
	
	internal static int IntegerLen(int x)
	{
		if (x == int.MinValue) return 10;
		
		int i = Math.Abs(x);
		if (i < 10) return 1;
		if (i < 100) return 2;
		if (i < 1000) return 3;
		if (i < 10000) return 4;
		if (i < 100000) return 5;
		if (i < 1000000) return 6;
		if (i < 10000000) return 7;
		if (i < 100000000) return 8;
		if (i < 1000000000) return 9;
		
		return 10;
	}
}
