<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	int[][]? q = System.Text.Json.JsonSerializer.Deserialize<int[][]?>("[[2,5],[5,9]]");
	ArgumentNullException.ThrowIfNull(q);
	s.PlatesBetweenCandles("**|**|***|", q).Dump();

}
public class Solution
{
	public int[] PlatesBetweenCandles(string s, int[][] queries)
	{
		int n = s.Length;
		const char plate = '*';
		const char candle = '|';
		int?[] candlesNearestLeft = new int?[n];
		int?[] candlesNearestRight = new int?[n];
		int[] platesSum = new int[n];
		int? currentCandle = null;
		for (int i = 0; i < n; i++)
		{
			if (s[i] == candle)
			{
				currentCandle = i;
			}

			candlesNearestLeft[i] = currentCandle;
		}

		currentCandle = null;
		for (int i = n - 1; i >= 0; i--)
		{
			if (s[i] == candle)
			{
				currentCandle = i;
			}

			candlesNearestRight[i] = currentCandle;
		}

		int totalPlates = 0;
		for (int i = 0; i < n; i++)
		{
			if (s[i] == plate)
			{
				totalPlates++;
			}

			platesSum[i] = totalPlates;
		}

		int[] results = new int[queries.Length];
		for (int i = 0; i < queries.Length; i++)
		{
			int start = queries[i][0];
			int end = queries[i][1];
			int? startingCandle = candlesNearestRight[start];
			int? endingCandle = candlesNearestLeft[end];
			(new {start, end, startingCandle, endingCandle}.ToString()).Dump();
			if (startingCandle is null || endingCandle is null || startingCandle >= endingCandle)
			{
				results[i] = 0;
			}
			else
			{
				results[i] = platesSum[endingCandle.Value]
				  - platesSum[startingCandle.Value];
			}
		}

		return results;
	}
}