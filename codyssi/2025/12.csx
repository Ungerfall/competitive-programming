#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using System.Text.RegularExpressions;
using Dumpify;

const int MOD = 1073741824;

string? line = null;
List<int[]> gridBuilder = [];
while ((line = Console.ReadLine()) is not null)
{
    string[] split = line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    if (split.Length == 0)
    {
        break;
    }

    gridBuilder.Add(split.Select(int.Parse).ToArray());
}

int rows = gridBuilder.Count;
int cols = gridBuilder[0].Length;
int[][] grid = BuildGrid(gridBuilder);

LinkedList<string> instructions = new();
while ((line = Console.ReadLine()) is not null)
{
    line = line.Trim();
    if (line.Equals(string.Empty))
    {
        break;
    }

    instructions.AddLast(line);
}

foreach (string instruction in instructions)
{
    RunInstruction(instruction, grid);
}
long largestLineAfterRunningInstructions = GetLargestLine(grid);

// flow-control actions
List<string> flowControlActions = new();
while ((line = Console.ReadLine()) is not null)
{
    flowControlActions.Add(line);
}

grid = BuildGrid(gridBuilder);
RunOneCycleOfFlowControlActions(flowControlActions, instructions, grid);
long largestLineAfterFlowControlActions = GetLargestLine(grid);

while (instructions.Count > 0)
{
    RunOneCycleOfFlowControlActions(flowControlActions, instructions, grid);
}
long largestLineAfterFlowControlActionsAndInstructions = GetLargestLine(grid);

largestLineAfterRunningInstructions.Dump();
largestLineAfterFlowControlActions.Dump();
largestLineAfterFlowControlActionsAndInstructions.Dump();

public static int Mod(long a, int b = MOD)
{
    long result = a % b;
    return (result < 0) ? (int)(result + b) : (int)result;
}

public static void RunInstruction(string instruction, int[][] grid)
{
    int rows = grid.Length;
    int cols = grid[0].Length;
    string[] words = instruction.Split();
    if (words[0].Equals("SHIFT"))
    {
        int number = int.Parse(words[2]) - 1;
        int by = int.Parse(words[4]);
        if (words[1].Equals("ROW"))
        {
            int row = number;
            int[] buffer = new int[cols];
            by = by % cols;
            for (int col = 0; col < cols; col++)
            {
                int newPlace = (col + by) % cols;
                buffer[newPlace] = grid[row][col];
            }

            grid[row] = buffer;
        }
        else
        {
            int col = number;
            int[] buffer = new int[rows];
            by = by % rows;
            for (int row = 0; row < rows; row++)
            {
                int newPlace = (row + by) % rows;
                buffer[newPlace] = grid[row][col];
            }

            for (int row = 0; row < rows; row++)
            {
                grid[row][col] = buffer[row];
            }
        }
    }
    else
    {
        string op = words[0];
        int amount = int.Parse(words[1]);
        bool isAll = words[2].Equals("ALL");
        int? opRow = !isAll && words[2].Equals("ROW") ? int.Parse(words[3]) - 1 : (int?)null;
        int? opCol = !isAll && words[2].Equals("COL") ? int.Parse(words[3]) - 1 : (int?)null;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (isAll || (opRow is not null && opRow == row) || (opCol is not null && opCol == col))
                {
                    grid[row][col] = op switch
                    {
                        "ADD" => Mod(grid[row][col] + Mod(amount)),
                        "SUB" => Mod(grid[row][col] - Mod(amount)),
                        "MULTIPLY" => Mod(grid[row][col] * (long)Mod(amount)),
                        _ => throw new ArgumentException(nameof(op))
                    };
                }
            }
        }
    }
}

public static long GetLargestLine(int[][] grid)
{
    int rows = grid.Length;
    int cols = grid[0].Length;
    long largestLine = 0L;
    for (int row = 0; row < rows; row++)
    {
        largestLine = Math.Max(largestLine, grid[row].Sum(x => (long)x));
    }

    for (int col = 0; col < cols; col++)
    {
        long colSum = 0L;
        for (int row = 0; row < rows; row++)
        {
            colSum += grid[row][col];
        }

        largestLine = Math.Max(largestLine, colSum);
    }

    return largestLine;
}

public static void DumpGrid(int[][] grid, string? instruction = null)
{
    int rows = grid.Length;
    int cols = grid[0].Length;
    int[,] prettyGrid = new int[rows, cols];
    for (int row = 0; row < rows; row++)
    {
        for (int col = 0; col < cols; col++)
        {
            prettyGrid[row, col] = grid[row][col];
        }
    }

    prettyGrid.Dump(instruction);
}

public static int[][] BuildGrid(List<int[]> builder)
{
    int[][] a = new int[builder.Count][];
    for (int i = 0; i < builder.Count; i++)
    {
        int[] source = builder[i];
        int[] dest = new int[source.Length];
        Array.Copy(source, dest, dest.Length);
        a[i] = dest;
    }

    return a;
}

public static void RunOneCycleOfFlowControlActions(List<string> actions, LinkedList<string> instructions, int[][] grid)
{
    LinkedListNode<string>? head = instructions.First;
    if (head is null)
    {
        return;
    }

    foreach (string action in actions)
    {
        if (head is null)
        {
            break;
        }

        if (action.Equals("TAKE"))
        {
            continue;
        }

        LinkedListNode<string>? next = head.Next;
        if (action.Equals("ACT"))
        {
            RunInstruction(head.Value, grid);
            instructions.Remove(head);
        }
        else
        {
            instructions.Remove(head);
            instructions.AddLast(head);
        }

        head = next ?? instructions.First;
    }
}
public static void DumpInstructions(LinkedList<string> instructions)
{
    foreach (string instruction in instructions)
    {
        instruction.Dump();
    }
}
