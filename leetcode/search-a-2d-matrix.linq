<Query Kind="Program" />

void Main()
{
	string pathtoinput = "path/to/input";
	int[][] matrix = System.Text.Json.JsonSerializer.Deserialize<int[][]>(File.ReadAllText(pathtoinput));
	int target = -1;
	var s = new Solution();
	s.SearchMatrix(matrix, target).Dump();
}

public class Solution
{
	public bool SearchMatrix(int[][] matrix, int target)
	{
		if (matrix.Length == 0 || matrix[0].Length == 0)
			return false;

		var firstColumn = matrix.Select(x => x[0]).ToArray();
		var rowIndex = Array.BinarySearch(firstColumn, target);
		if (rowIndex >= 0)
		{
			return true;
		}

		rowIndex = ~rowIndex;
		if (rowIndex == 0)
		{
			return false;
		}

		var columnIndex = Array.BinarySearch(matrix[rowIndex - 1], target);

		return columnIndex >= 0;
	}
}

