<Query Kind="Program" />

void Main()
{
	Solution s = new();
	int[] bills = System.Text.Json.JsonSerializer.Deserialize<int[]>("[5,5,5,10,20]");
	s.LemonadeChange(bills).Dump();
	bills = System.Text.Json.JsonSerializer.Deserialize<int[]>("[5,5,10,10,20]");
	s.LemonadeChange(bills).Dump();
}

public class Solution
{
	public bool LemonadeChange(int[] bills)
	{
		int fives = 0;
		int tens = 0;
		for (int i = 0; i < bills.Length; i++)
		{
			if (bills[i] == 5)
			{
				fives++;
			}
			else if (bills[i] == 10)
			{
				if (fives <= 0)
					return false;
				
				fives--;
				tens++;
			}
			else
			{
				if (tens > 0 && fives > 0)
				{
					tens--;
					fives--;
				}
				else if (fives >= 3)
				{
					fives -= 3;
				}
				else
				{
					return false;
				}
			}
		}
		
		return true;
	}
}