#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

int[][] points = "[[1,3],[-2,2]]".DeserializeTo2DJaggedArray();
int k = 1;
Solution s = new();
points.Print(Console.Out);
var result = s.KClosest(points, k);
result.Print(Console.Out);

public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        int[][] closest = new int[k][];
        PriorityQueue<int[], double> heap = new(initialCapacity: points.Length);
        for (int i = 0; i < points.Length; i++)
        {
            int x = points[i][0];
            int y = points[i][1];
            double dist = Math.Sqrt(x * x + y * y);
            heap.Enqueue(points[i], dist);
        }

        for (int i = 0; i < k; i++)
        {
            int[] point = heap.Dequeue();
            closest[i] = point;
        }

        return closest;
    }
}
