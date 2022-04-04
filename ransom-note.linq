<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.CanConstruct("a", "b").Dump();
	s.CanConstruct("aa", "ab").Dump();
	s.CanConstruct("aa", "aab").Dump();
	s.CanConstruct("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj").Dump();
}

public class Solution
{
	public bool CanConstruct(string ransomNote, string magazine)
	{
		if (ransomNote.Length > magazine.Length)
			return false;
			
		int left = ransomNote.Length;
		Dictionary<char, int> chars = ransomNote.GroupBy(c => c).ToDictionary(c => c.Key, v => v.Count());
		for (int i = 0; i < magazine.Length; i++)
		{
			if (left == 0)
				break;
				
			var ch = magazine[i];
			if (chars.TryGetValue(ch, out int count))
			{
				if (count > 0)
				{
					left--;
					chars[ch] = count - 1;
				}
			}
		}
		
		return left == 0;
	}
}