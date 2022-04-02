<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	(s.RomanToInt("III") == 3).Dump();
	(s.RomanToInt("LVIII") == 58).Dump();
	(s.RomanToInt("MCMXCIV") == 1994).Dump();
}

public class Solution
{
	public int RomanToInt(string s)
	{
		var map = new Dictionary<char, int>
		{
			['I'] = 1,
			['V'] = 5,
			['X'] = 10,
			['L'] = 50,
			['C'] = 100,
			['D'] = 500,
			['M'] = 1000,
		};
		int prev = map[s[0]];
		var result = prev;

		for (int i = 1; i < s.Length; i++)
		{
			var curr = map[s[i]];
			if (curr > prev)
			{
				result += curr - (2 * prev);// prev already in result
			}
			else
			{
				result += curr;
			}

			prev = curr;
		}

		return result;
	}
}
