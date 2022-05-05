<Query Kind="Program" />

void Main()
{
	Solution s = new();
	int[][] q = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[0,1],[1,0],[4,0],[0,4],[3,3],[2,4]]");
	int[] k = System.Text.Json.JsonSerializer.Deserialize<int[]>("[0,0]");
	s.QueensAttacktheKing(q, k).Dump();
	q = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[0,0],[1,1],[2,2],[3,4],[3,5],[4,4],[4,5]]");
	k = System.Text.Json.JsonSerializer.Deserialize<int[]>("[3,3]");
	s.QueensAttacktheKing(q, k).Dump();
	q = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[5,6],[7,7],[2,1],[0,7],[1,6],[5,1],[3,7],[0,3],[4,0],[1,2],[6,3],[5,0],[0,4],[2,2],[1,1],[6,4],[5,4],[0,0],[2,6],[4,5],[5,2],[1,4],[7,5],[2,3],[0,5],[4,2],[1,0],[2,7],[0,1],[4,6],[6,1],[0,6],[4,3],[1,7]]");
	k = System.Text.Json.JsonSerializer.Deserialize<int[]>("[3,4]");
	s.QueensAttacktheKing(q, k).Dump();
}

public class Solution
{
	public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
	{
		List<IList<int>> result = new();
		(int x, int y)[] moves = new[]
		{
			(-1, -1),
			(-1, 0),
			(-1, 1),
			(0, -1),
			(0, 1),
			(1, -1),
			(1, 0),
			(1, 1),
		};
		foreach (int[] q in queens)
		{
			//q.Dump("Queen");
			foreach (var (x, y) in moves)
			{
				//(x, y).ToString().Dump("move");
				for (int i = 1; i < 8; i++)
				{
					int xx = i * x + q[0];
					int yy = i * y + q[1];
					//(xx, yy).ToString().Dump();
					if (xx < 0 || xx > 7)
						break;
					if (yy < 0 || yy > 7)
						break;
						
					if (queens.Any(qu => qu[0] == xx && qu[1] == yy))
						break;
						
					if (xx == king[0] && yy == king[1])
						result.Add(q);
				}
			}
		}
		return result;
	}
}