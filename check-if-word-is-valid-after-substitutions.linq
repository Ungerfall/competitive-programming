<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.IsValid("aabcbc").Dump();
	s.IsValid("abcabcababcc").Dump();
	s.IsValid("abccba").Dump();
	s.IsValid("abcabcabcabcabcabcabcabcabcabc").Dump();
}

public class Solution
{
	public bool IsValid(string s)
	{
		if (string.Empty.Equals(s) || "abc".Equals(s))
			return true;

		if (s.Length % 3 != 0)
			return false;

		const string abc = "abc";
		while (s.Contains(abc))
		{
			s = s.Replace(abc, string.Empty);
		}
		
		return string.Empty.Equals(s);
	}
}