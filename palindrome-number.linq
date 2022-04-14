<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.IsPalindrome(121).Dump();
	s.IsPalindrome(-121).Dump();
	s.IsPalindrome(10).Dump();
}

public class Solution
{
	public bool IsPalindrome(int x)
	{
		if (x < 0)
			return false;
		if (x >= 0 && x < 10)
			return true;
			
		int[] arr = ToArr(x);
		return IsPalindrome(arr);
	}
	
	public static bool IsPalindrome(int[] s)
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
	
	internal static int[] ToArr(int x)
	{
		var reversed = new List<int>(10);
		do
		{
			reversed.Add(x % 10);
			x /= 10;
		} while (x != 0);
		
		var arr = reversed.ToArray();
		Array.Reverse(arr);
		
		return arr;
	}
}
