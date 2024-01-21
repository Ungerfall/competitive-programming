<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	
	Solution s = new();
	s.LengthOfLongestSubstring("abcabcbb").Dump();
	s.LengthOfLongestSubstring("bbbbb").Dump();
	s.LengthOfLongestSubstring("pwwkew").Dump();
	s.LengthOfLongestSubstring("au").Dump();
	s.LengthOfLongestSubstring("abba").Dump();
}

public class Solution
{
	public int LengthOfLongestSubstring(string s)
	{
		if (s.Length <= 1)
		{
			return s.Length;
		}
		
		int longest = 1;
		int start = 0;
		var counter = new Dictionary<char, int>();
		for (int i = 0; i < s.Length; i++)
		{
			char ch = s[i];
			if (counter.TryGetValue(ch, out int firstIndex))
			{
				longest = Math.Max(longest, i - start); // "aba" i = 2, 2 - 0 == 2
				start = firstIndex + 1;
				counter = new Dictionary<char, int>();
				i = firstIndex;
			}
			else
			{
				counter[ch] = i;
			}
		}

		longest = Math.Max(longest, s.Length - start);
		return longest;
	}
}

