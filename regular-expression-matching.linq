<Query Kind="Program" />

void Main()
{
	var s =new Solution();
	s.IsMatch("aa", "a").Dump();
	
}

public class Solution
{
	public bool IsMatch(string s, string p)
	{
		return Regex.IsMatch(s, $"^{p}$", RegexOptions.None);
	}
}
