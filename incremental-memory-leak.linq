<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.MemLeak(2, 2).Dump();
	s.MemLeak(8, 11).Dump();
	s.MemLeak(0, 0).Dump();
}

public class Solution
{
	public int[] MemLeak(int memory1, int memory2)
	{
		int allocation = 1;
		while (true)
		{
			if (allocation > memory1 && allocation > memory2)
				return new[] { allocation, memory1, memory2 };
				
			if (memory2 > memory1)
			{
				memory2 -= allocation;
			}
			else
			{
				memory1 -= allocation;
			}
			
			allocation++;
		}
	}
}