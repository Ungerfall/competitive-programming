<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.LengthOfLongestSubstring("abcabcbb") == 3).Dump();
	(s.LengthOfLongestSubstring("qwertyuiopasdfghjklzxcvbnmq") == 26).Dump();
	(s.LengthOfLongestSubstring("pwwkew") == 3).Dump();
	(s.LengthOfLongestSubstring("aab") == 2).Dump();
	(s.LengthOfLongestSubstring("tmmzuxt") == 5).Dump();
	(s.LengthOfLongestSubstring("cdd") == 2).Dump();
	(s.LengthOfLongestSubstring("dvdf") == 3).Dump();
}

public class Solution
{
	public int LengthOfLongestSubstring(string s)
	{
		var letters = new Dictionary<char, int>();
		int max = 0;
		int start = 0;
		int len = 0;
		int pos = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (letters.TryGetValue(s[i], out pos))
			{
				if (pos >= start)
				{
					len = i - start;
					max = Math.Max(max, len);
					start = pos + 1;
				}
			}
			
			letters[s[i]] = i;
		}
		
		return Math.Max(max, s.Length - start);
	}
}