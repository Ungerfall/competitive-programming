<Query Kind="Program" />

void Main()
{
	Solution s = new();
	int[] arr = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,3,4,5,6,7,8,9,10]");
	s.ShipWithinDays(arr, 5).Dump();
	arr = System.Text.Json.JsonSerializer.Deserialize<int[]>("[3,2,2,4,1,4]");
	s.ShipWithinDays(arr, 3).Dump();
	arr = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,3,1,1]");
	s.ShipWithinDays(arr, 4).Dump();
}

public class Solution
{
	public int ShipWithinDays(int[] weights, int days)
	{
		int left = 0;
		int right = 0;
		for (int i = 0; i < weights.Length; i++)
		{
			left = Math.Max(left, weights[i]);
			right += weights[i];
		}
		
		while (left < right)
		{
			int mid = (left + right) / 2;
			int need = 1;
			int curr = 0;
			for (int i = 0; i < weights.Length; i++)
			{
				if (curr + weights[i] > mid)
				{
					need++;
					curr = 0;
				}
				
				curr += weights[i];
			}
			
			if (need > days)
			{
				left = mid + 1;
			}
			else
			{
				right = mid;
			}
		}

		return left;
	}
}
