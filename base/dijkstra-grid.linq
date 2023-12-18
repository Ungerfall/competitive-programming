<Query Kind="Program">
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

void Main()
{
	string grid =
"""
2413432311323
3215453535623
3255245654254
3446585845452
4546657867536
1438598798454
4457876987766
3637877979653
4654967986887
4564679986453
1224686865563
2546548887735
4322674655533
""";
	Solution s = new(grid);
	var (min, path) = s.FindShortestPath(start: (0, 0), dest: (12, 12));
	min.Dump();
	path.Dump();
}
public class Solution
{
	private readonly int[,] _grid;
	private readonly int maxRow;
	private readonly int maxCol;

	public Solution(string grid)
	{
		string[] lines = grid.Split(Environment.NewLine);
		maxRow = lines.Length;
		maxCol = lines[0].Length;
		_grid = new int[maxRow, maxCol];
		for (int row = 0; row < maxRow; row++)
		{
			for (int col = 0; col < maxCol; col++)
			{
				_grid[row, col] = (int)Char.GetNumericValue(lines[row][col]);
			}
		}
	}

	public (int min, bool[,] path) FindShortestPath((int row, int col) start, (int row, int col) dest)
	{
		(int rx, int cx)[] dirs = new[] { (0, -1), (0, 1), (-1, 0), (1, 0) };
		int[,] bestDist = new int[maxRow, maxCol];
		for (int row = 0; row < maxRow; row++)
		{
			for (int col = 0; col < maxCol; col++)
			{
				bestDist[row, col] = int.MaxValue;
			}
		}

		bestDist[start.row, start.col] = 0;
		(int row, int col)[,] parent = new (int row, int col)[maxRow, maxCol];
		parent[0, 0] = (0, 0);
		var heap = new PriorityQueue<(int row, int col), int>();
		heap.Enqueue(start, priority: 0);
		while (heap.Count > 0)
		{
			var (row, col) = heap.Dequeue();
			if (row == dest.row && col == dest.col)
			{
				return (bestDist[row, col], reconstructPath(parent, start, dest));
			}

			foreach (var (rx, cx) in dirs)
			{
				int rr = row + rx;
				int cc = col + cx;
				if (rr < 0 || rr >= maxRow || cc < 0 || cc >= maxCol)
				{
					continue;
				}

				int newDist = checked(bestDist[row, col] + _grid[rr, cc]);
				if (newDist < bestDist[rr, cc])
				{
					bestDist[rr, cc] = newDist;
					parent[rr, cc] = (row, col);
					heap.Enqueue((rr, cc), newDist);
				}
			}
		}

		throw new ArgumentException("Shortest path has not been found");
	}

	private bool[,] reconstructPath((int row, int col)[,] parent, (int row, int col) start, (int row, int col) destination)
	{
		bool[,] path = new bool[parent.GetLength(0), parent.GetLength(1)];
		path[start.row, start.col] = true;
		path[destination.row, destination.col] = true;
		var (parentRow, parentCol) = parent[destination.row, destination.col];
		while ((parentRow, parentCol) != (0, 0))
		{
			path[parentRow, parentCol] = true;
			(parentRow, parentCol) = parent[parentRow, parentCol];
		}

		return path;
	}
}

