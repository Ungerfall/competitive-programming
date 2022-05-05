<Query Kind="Program" />

void Main()
{
	int[][] d = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[1,2],[2,1],[3,4],[5,6]]");
	Solution s = new();
	s.NumEquivDominoPairs(d).Dump();
	d = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[1,2],[1,2],[1,1],[1,2],[2,2]]");
	s.NumEquivDominoPairs(d).Dump();
}

public class Solution
{
	public int NumEquivDominoPairs(int[][] dominoes)
	{
		Dictionary<(int a, int b), int> count = new();
		for (int i = 0; i < dominoes.Length; i++)
		{
			var key = (dominoes[i][0], dominoes[i][1]);
			count.TryGetValue(key, out int c);
			count[key] = c + 1;
		}
		
		int same = 0;
		int rev = 0;
		foreach (var (k, v) in count)
		{
			same += (v * (v - 1)) / 2;
			var reversed = (k.b, k.a);
			if (k.a == k.b)
				continue;
				
			if (count.TryGetValue(reversed, out int c))
			{
				rev += v * c;
			}
		}

		//count.Dump();
		//(same, rev).Dump();
		return same + rev / 2;
	}
}