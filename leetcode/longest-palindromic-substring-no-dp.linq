<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.LongestPalindrome("babad").Dump();
	s.LongestPalindrome("cbbd").Dump();
	s.LongestPalindrome("bb").Dump();
	s.LongestPalindrome("a").Dump();
	s.LongestPalindrome("ccc").Dump();
}
public class Solution
{
	public string LongestPalindrome(string s)
	{
		int iBest = 0;
		int jBest = 0;
		for (int i = 0; i < s.Length; i++)
		{
			for (int j = s.Length - 1; j > i; j--)
			{
				if (j - i <= jBest - iBest)
				{
					continue;
				}
				
				if (isPalindrome(i, j) && j - i > jBest - iBest)
				{
					iBest = i;
					jBest = j;
					break;
				}
			}
		}
		
		jBest++;
		return s[iBest..jBest];
		
		bool isPalindrome(int i, int j)
		{
			int left = i;
			int right = j;
			while (left < right)
			{
				if (s[left] != s[right])
				{
					return false;
				}
				
				left++;
				right--;
			}
			
			return true;
		}
	}
}

