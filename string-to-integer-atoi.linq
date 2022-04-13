<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.MyAtoi("42").Dump();
	s.MyAtoi("   -42").Dump();
	s.MyAtoi("4193 with words").Dump();

	s.MyAtoi("words and 987").Dump();
}

public class Solution
{
	public int MyAtoi(string s)
	{
		var span = s.AsSpan().TrimStart();
		if (span.Length == 0)
			return 0;
			
		int start = 0;
		bool isNegative = false;
		if (span[start] == '-' || span[start] == '+')
		{
			isNegative = span[start] == '-';
			start++;
		}
		
		int i = start;
		while (i < span.Length && IsDigit(span[i]))
		{
			i++;
		}

		var slice = span.Slice(start, i - start);
		if (slice.Length == 0)
			return 0;
		//new { i, start }.Dump();
		var (number, overflow) = ToInt(slice);
		if (overflow)
		{
			return isNegative ? Int32.MinValue : Int32.MaxValue;
		}
		
		return isNegative ? -1 * number : number;
	}
	
	internal static bool IsDigit(char c)
	{
		return c >= '0' && c <= '9';
	}
	
	internal static (int number, bool overflow) ToInt(ReadOnlySpan<char> s)
	{
		//s.Dump();
		if (!Int32.TryParse(s, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out int number))
		{
			return (number, true);
		}
		
		return (number, false);
	}
}