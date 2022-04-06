<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	int[][] mat = new[]
	{
		new[] {1,1,0,0,0},
		new[] {1,1,1,1,0},
		new[] {1,0,0,0,0},
		new[] {1,1,0,0,0},
		new[] {1,1,1,1,1},
	};
	
	s.KWeakestRows(mat, 3).Dump();
	
	mat = new[]
	{
		new[]{1,0,0,0},
		new[]{1,1,1,1},
		new[]{1,0,0,0},
		new[]{1,0,0,0},
	};
	s.KWeakestRows(mat, 2).Dump();
}

public class Solution
{
	public int[] KWeakestRows(int[][] mat, int k)
	{
		var keyValues = mat.Select((x, index) =>
		{
			string number = string.Join(string.Empty, x);
			return new KeyValuePair<int, string>(index, number);
		})
		.ToList();

		keyValues.Sort((p1, p2) =>
		{
			var c1 = p1.Value.CompareTo(p2.Value);
			if (c1 == 0)
				return p1.Key.CompareTo(p2.Key);
			return c1;
		});
		
		return keyValues.Take(k).Select(v => v.Key).ToArray();
	}
}
