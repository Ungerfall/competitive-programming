<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.UniquePaths(3, 7).Dump();
	s.UniquePaths(3, 2).Dump();
}

public class Solution
{
	public int UniquePaths(int m, int n)
	{
		int[,] paths = new int[m, n];
		for (int i = 0; i < m; i++)
		{
			paths[i, n - 1] = 1;
		}
		for (int i = 0; i < n; i++)
		{
			paths[m - 1, i] = 1;
		}
		for (int r = m - 2; r >= 0; r--)
		{
			for (int c = n - 2; c >= 0; c--)
			{
				paths[r, c] = paths[r, c + 1] + paths[r + 1, c];
			}
		}

		return paths[0, 0];
	}
}
