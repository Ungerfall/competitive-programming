<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.LongestPalindrome("babad").Dump();
	s.LongestPalindrome("cbbd").Dump();
	s.LongestPalindrome("bb").Dump();
	
}

public class Solution
{
	public string LongestPalindrome(string s)
	{
		if (s.Length == 1)
			return s;

		int start = 0;
		int lenMax = 0;
		for (int i = 0; i < s.Length-1; i++)
		{
			for (int j = i; j < s.Length; j++)
			{
				int len = j - i + 1; 
				if (IsPalindrome(s.AsSpan(i, len)))
				{
					if (lenMax < len)
					{
						start = i;
						lenMax = len;
					}
				}
			}
		}
		
		return s.Substring(start, lenMax);
	}
	
	public static bool IsPalindrome(ReadOnlySpan<char> s)
	{
		int start = 0;
		int end = s.Length-1;
		while (end > start)
		{
			if (s[end--] != s[start++])
			{
				return false;
			}
		}
		
		return true;
	}
}