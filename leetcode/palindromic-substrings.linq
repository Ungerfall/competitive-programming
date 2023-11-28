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
		int[] even = new int[s.Length];
		int[] odd = new int[s.Length];
		for (int i = 0; i < s.Length; i++)
		{
			odd[i] = 1;
			while (i - odd[i] >= 0 && i + odd[i] < s.Length && s[i - odd[i]] == s[i + odd[i]])
			{
				odd[i]++;
			}

			even[i] = 0;
			while (i - even[i] - 1 >= 0 && i + even[i] < s.Length && s[i - even[i] - 1] == s[i + even[i]])
			{
				even[i]++;
			}
		}

		return odd.Sum() + even.Sum();
	}
}
