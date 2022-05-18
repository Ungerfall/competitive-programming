<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.WinnerOfGame("AAABABB").Dump();
	s.WinnerOfGame("AA").Dump();
	s.WinnerOfGame("ABBBBBBBAAA").Dump();
	s.WinnerOfGame("AABB").Dump();
}

public class Solution
{
	public bool WinnerOfGame(string colors)
	{
		if (colors.Length <= 2)
			return false;


		int aliceRemovesCount = 0;
		int bobRemovesCount = 0;
		int seq = 1;
		bool state = colors[0] == 'A'; // true = Alice, false = Bob
		for (int i = 1; i < colors.Length; i++)
		{
			bool newState = colors[i] == 'A';
			if (state == newState)
				seq++;
			else
				seq = 1;
			
			state = newState;
			if (seq >= 3)
			{
				if (state)
				{
					aliceRemovesCount++;
				}
				else
				{
					bobRemovesCount++;
				}
			}
		}
		
		//(aliceRemovesCount, bobRemovesCount).Dump();
		return (aliceRemovesCount > 0) && aliceRemovesCount > bobRemovesCount;
	}
}