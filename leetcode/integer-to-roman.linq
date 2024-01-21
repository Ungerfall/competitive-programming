<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	Solution s = new();
	s.IntToRoman(3).Dump("ans");
	s.IntToRoman(58).Dump("ans");
	s.IntToRoman(1994).Dump("ans");
}

public class Solution
{
	public string IntToRoman(int num)
	{
		Dictionary<int, char> intToRoman = new Dictionary<int, char>
		{
			[1] = 'I',
			[5] = 'V',
			[10] = 'X',
			[50] = 'L',
			[100] = 'C',
			[500] = 'D',
			[1000] = 'M',
		};
		int magnitude = 1;
		var sb = new StringBuilder();
		while (num > 0)
		{
			int digit = num % 10;
			if (digit == 4 || digit == 9)
			{
				sb.Insert(0, intToRoman[(digit * magnitude) + magnitude]);
				sb.Insert(0, intToRoman[magnitude]);
			}
			else if (digit < 4)
			{
				string roman = new string(intToRoman[magnitude], digit);
				sb.Insert(0, roman);
			}
			else if (digit > 4)
			{
				char fiveishRoman = intToRoman[5 * magnitude];
				string addition = new string(intToRoman[magnitude], digit - 5);
				sb.Insert(0, addition);
				sb.Insert(0, fiveishRoman);
			}
			else
			{
				throw new ArgumentException("unknown");
			}
			
			num /= 10;
			magnitude *= 10;
		}

		return sb.ToString();
	}
}

