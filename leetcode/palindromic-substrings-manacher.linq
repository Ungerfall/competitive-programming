<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.CountSubstrings("abc").Dump();
	s.CountSubstrings("aaa").Dump();
}

public class Solution
{
	public int CountSubstrings(string s)
	{
		int[] odd = new int[s.Length];
		int center = 0;
		int rightBoundary = -1;
		for (int i = 0; i < s.Length; i++)
		{
			int mirror = center + rightBoundary - i;
			int maxRadius = rightBoundary >= i ? Math.Min(odd[mirror], rightBoundary - i + 1) : 1;
			while (i + maxRadius < s.Length && i - maxRadius >= 0 && s[i + maxRadius] == s[i - maxRadius])
			{
				maxRadius++;
			}

			odd[i] = maxRadius;
			if (i + maxRadius - 1 > rightBoundary)
			{
				center = i - maxRadius + 1;
				rightBoundary = i + maxRadius - 1;
			}
		}

		int[] even = new int[s.Length];
		center = 0;
		rightBoundary = -1;
		for (int i = 0; i < s.Length; i++)
		{
			int mirror = center + rightBoundary - i + 1;
			int maxRadius = rightBoundary >= i ? Math.Min(even[mirror], rightBoundary - i + 1) : 0;
			while (i + maxRadius < s.Length && i - maxRadius - 1 >= 0 && s[i + maxRadius] == s[i - maxRadius - 1])
			{
				maxRadius++;
			}

			even[i] = maxRadius;
			if (i + maxRadius - 1 > rightBoundary)
			{
				center = i - maxRadius;
				rightBoundary = i + maxRadius - 1;
			}
		}

		return odd.Sum() + even.Sum();
	}
}
