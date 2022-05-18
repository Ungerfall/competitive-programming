<Query Kind="Program" />

void Main()
{
	Solution s = new();
	int[] arr = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,3,2,4,1]");
	s.MaxIceCream(arr, 7).Dump();
	
	arr = System.Text.Json.JsonSerializer.Deserialize<int[]>("[10,6,8,7,7,8]");
	s.MaxIceCream(arr, 5).Dump();
	
	arr = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,6,3,1,2,5]");
	s.MaxIceCream(arr, 20).Dump();
}

public class Solution
{
	public int MaxIceCream(int[] costs, int coins)
	{
		Array.Sort(costs);
		for (int i = 0; i < costs.Length; i++)
		{
			if (costs[i] > coins)
				return i;
			
			coins -= costs[i];
		}
		
		return costs.Length;
	}
}