#!/usr/bin/env dotnet run

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int[][] image = "[[1,1,1],[1,1,0],[1,0,1]]".DeserializeTo2DJaggedArray();
int sr = 1;
int sc = 1;
int color = 2;
image.Print(Console.Out);
var result = s.FloodFill(image, sr, sc, color);
result.Print(Console.Out);

[JsonSerializable(typeof(int[]))]
[JsonSerializable(typeof(int[][]))]
internal partial class CorePrimitivesContext : JsonSerializerContext;

public static class TemplateExtensions
{
    extension<T>(Dictionary<T, int> counter)
        where T : notnull
    {
        public Dictionary<T, int> Increment(T key)
        {
            counter[key] = counter.GetValueOrDefault(key) + 1;
            return counter;
        }

        public Dictionary<T, int> Decrement(T key)
        {
            counter[key] = counter.GetValueOrDefault(key) - 1;
            return counter;
        }
    }

    extension(string s)
    {
        public int[] DeserializeToArray()
        {
            return System.Text.Json.JsonSerializer.Deserialize<int[]>(
                    s,
                    CorePrimitivesContext.Default.Int32Array)
                ?? throw new ArgumentNullException();
        }

        public int[][] DeserializeTo2DJaggedArray()
        {
            return System.Text.Json.JsonSerializer.Deserialize<int[][]>(
                    s,
                    CorePrimitivesContext.Default.Int32ArrayArray)
                ?? throw new ArgumentNullException();
        }
    }

    extension<T>(T[][] array)
    {
        public void Print(TextWriter tw)
        {
            StringBuilder sb = new();
            for (int row = 0; row < array.Length; row++)
            {
                sb.AppendJoin(',', array[row]);
                sb.AppendLine();
            }

            tw.WriteLine(sb.ToString());
        }
    }
}

public class Solution
{
    private static readonly (int rx, int cx)[] Directions = new[]
    {
        (0, 1),
        (0, -1),
        (-1, 0),
        (1, 0)
    };

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        if (color == image[sr][sc])
        {
            return image;
        }

        int sourceColor = image[sr][sc];
        image[sr][sc] = color;
        int rows = image.Length;
        int cols = image[0].Length;
        Queue<(int row, int col)> traverseQueue = [];
        traverseQueue.Enqueue((sr, sc));
        while (traverseQueue.Count > 0)
        {
            (int row, int col) = traverseQueue.Dequeue();
            foreach ((int rx, int cx) in Directions)
            {
                int targetRow = row + rx;
                int targetCol = col + cx;
                if (targetRow < 0 || targetRow >= rows)
                {
                    continue;
                }

                if (targetCol < 0 || targetCol >= cols)
                {
                    continue;
                }

                if (image[targetRow][targetCol] != sourceColor)
                {
                    continue;
                }

                image[targetRow][targetCol] = color;
                traverseQueue.Enqueue((targetRow, targetCol));
            }
        }

        return image;
    }
}
