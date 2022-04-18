<Query Kind="Program" />

void Main()
{
	int[][] arr1 = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[0,2],[5,10],[13,23],[24,25]]");
	int[][] arr2 = System.Text.Json.JsonSerializer.Deserialize<int[][]>("[[1,5],[8,12],[15,24],[25,26]]");
	var s = new Solution();
	s.IntervalIntersection(arr1, arr2).Dump();
}

public class Solution
{
	public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
	{
		var result = new List<int[]>();
		
		int i = 0;
		int j = 0;
		while (i < firstList.Length && j < secondList.Length)
		{
			if (firstList[i][1] < secondList[j][0])
			{
				i++;
			}
			else if (secondList[j][1] < firstList[i][0])
			{
				j++;
			}
			else
			{
				//new { arr1 = firstList[i], arr2 = secondList[j] }.Dump();
				int start = Math.Max(firstList[i][0], secondList[j][0]);
				int end = Math.Min(firstList[i][1], secondList[j][1]);
				result.Add(new[] {start, end});
				if (firstList[i][1] > secondList[j][1])
				{
					j++;
				}
				else
				{
					i++;
				}
			}
		}
		
		return result.ToArray();
	}
}

