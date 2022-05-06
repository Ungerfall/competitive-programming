<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.FindKthNumber(3, 3, 5).Dump();
	s.FindKthNumber(2, 3, 6).Dump();

}

public class Solution
{
	public int FindKthNumber(int m, int n, int k)
	{
		int[] arr = new int[m * n];
		for (int i = 0; i < m; i++)
		{
			for (int j = 0; j < n; j++)
			{
				//(i*n+j).Dump();
				arr[i * n + j] = (i + 1) * (j + 1);
			}
		}

		Array.Sort(arr);
		//arr.Dump();
		return arr[k - 1];
	}
}