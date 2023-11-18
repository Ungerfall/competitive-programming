<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.CoinChange(new[] {3,7,405,436}, 8839).Dump();

}
public class Solution
{
	public int CoinChange(int[] coins, int amount)
	{
		var subProblems = new Dictionary<int, int?>();
		int? best = change(amount);
		return best ?? -1;

		int? change(int amount)
		{
			if (amount < 0)
			{
				return null;
			}

			if (amount == 0)
			{
				return 0;
			}

			var key = amount;
			if (subProblems.ContainsKey(key))
			{
				return subProblems[key];
			}
			
			int? min = null;
			for (int i = 0; i < coins.Length; i++)
			{
				int? ways = change(amount - coins[i]) + 1;
				if (ways < (min ?? int.MaxValue))
				{
					min = ways;
				}
			}

			subProblems[key] = min;
			return min;
		}
	}
}