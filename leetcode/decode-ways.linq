<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.NumDecodings("12").Dump();
	s.NumDecodings("226").Dump();
	s.NumDecodings("06").Dump();
	s.NumDecodings("27").Dump();
	s.NumDecodings("2611055971756562").Dump();
	s.NumDecodings("1").Dump();
}

public class Solution
{
	public int NumDecodings(string s)
	{
		ReadOnlySpan<char> span = s;
		if (s[0] == '0')
		{
			return 0;
		}
		
		if (s.Length == 1)
		{
			return 1;
		}

		var subCombinations = new int?[s.Length + 1];
		return decode(0, span, subCombinations);

		static int decode(int index, ReadOnlySpan<char> span, int?[] subCombinations)
		{
			if (index == span.Length)
			{
				return 1;
			}

			if (subCombinations[index] != null)
			{
				return subCombinations[index].Value;
			}

			int first = int.Parse(span.Slice(index, 1));
			int? second = index + 1 < span.Length ? int.Parse(span.Slice(index + 1, 1)) : (int?)null;

			int min = (first, second) switch
			{
				(0, 0) => 0,
				(0, _) => 0,
				(1, 0) => decode(index + 2, span, subCombinations),
				(2, 0) => decode(index + 2, span, subCombinations),
				(1, not null) => decode(index + 1, span, subCombinations) + decode(index + 2, span, subCombinations),
				(2, <= 6) => decode(index + 1, span, subCombinations) + decode(index + 2, span, subCombinations),
				(2, > 6) => decode(index + 1, span, subCombinations),
				(>=3, _) => decode(index + 1, span, subCombinations),
				(_, null) => decode(index + 1, span, subCombinations),
				_ => throw new ArgumentException($"something wrong with {(first, second)}"),
			};

			//(index, span[index], first, second, min).ToString().Dump();
			subCombinations[index] = Math.Min(subCombinations[index] ?? int.MaxValue, min);
			return min;
		}
	}
}
