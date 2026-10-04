#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int[][] intervals = "[[1,2],[3,5],[6,7],[8,10],[12,16]]".DeserializeTo2DJaggedArray();
int[] newInterval = "[4,8]".DeserializeToArray();
var result = s.Insert(intervals, newInterval);
// [[1,2],[3,10],[12,16]]
result.Print(Console.Out);

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0)
        {
            return [newInterval];
        }

        int newLeft = newInterval[0];
        int newRight = newInterval[1];
        if (intervals[0][0] > newRight)
        {
            return [newInterval, .. intervals];
        }

        if (intervals[^1][1] < newLeft)
        {
            return [.. intervals, newInterval];
        }

        List<int[]> newIntervals = [];
        int i = 0;
        for (; i < intervals.Length; i++)
        {
            int left = intervals[i][0];
            int right = intervals[i][1];
            if (right < newLeft)
            {
                newIntervals.Add(intervals[i]);
            }
            else if (left <= newLeft && right >= newLeft)
            {
                newLeft = left;
                break;
            }
            else
            {
                break;
            }
        }

        for (; i < intervals.Length; i++)
        {
            int left = intervals[i][0];
            int right = intervals[i][1];
            if (left <= newRight && right >= newRight)
            {
                newRight = right;
                i++;
                break;
            }
            else if (left > newRight)
            {
                break;
            }
        }

        newIntervals.Add([newLeft, newRight]);
        newIntervals.AddRange(intervals[i..]);

        return [.. newIntervals];
    }
}
