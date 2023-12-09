<Query Kind="Program">
  <RemoveNamespace>System</RemoveNamespace>
  <RemoveNamespace>System.Collections</RemoveNamespace>
  <RemoveNamespace>System.Collections.Generic</RemoveNamespace>
  <RemoveNamespace>System.Data</RemoveNamespace>
  <RemoveNamespace>System.Diagnostics</RemoveNamespace>
  <RemoveNamespace>System.IO</RemoveNamespace>
  <RemoveNamespace>System.Linq</RemoveNamespace>
  <RemoveNamespace>System.Linq.Expressions</RemoveNamespace>
  <RemoveNamespace>System.Reflection</RemoveNamespace>
  <RemoveNamespace>System.Text</RemoveNamespace>
  <RemoveNamespace>System.Text.RegularExpressions</RemoveNamespace>
  <RemoveNamespace>System.Threading</RemoveNamespace>
  <RemoveNamespace>System.Transactions</RemoveNamespace>
  <RemoveNamespace>System.Xml</RemoveNamespace>
  <RemoveNamespace>System.Xml.Linq</RemoveNamespace>
  <RemoveNamespace>System.Xml.XPath</RemoveNamespace>
</Query>

// copy template to destination `cp template.linq problem123.linq`
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Transactions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Program
{
	public class Program
	{
		public static void Main(string[] args)
		{
#if LINQPAD
			string linqpadInput =
"""
4
2 1
0 0
3 3
1 1
3 1
1 3
4 4
0 0
8 0
4 2
1 4
3 4
""";
			using var stringReader = new StringReader(linqpadInput);
			Console.SetIn(stringReader);
#endif
			int t = Scanner.Int();
			foreach (var _ in Enumerable.Range(0, t))
			{
				(int knightRowDx, int knightColDx) = Scanner.IntInt();
				(int kingRow, int kingCol) = Scanner.IntInt();
				(int qRow, int qCol) = Scanner.IntInt();
				int count = 0;
				if (knightRowDx == knightColDx)
				{
					(int dRow, int dCol)[] dirs = new[]
					{
						(-1, -1),
						(-1, 1),
						(1, -1),
						(1, 1)
					};
					for (int i = 0; i < 4; i++)
					{
						int nnRow = kingRow + dirs[i].dRow * knightRowDx;
						int nnCol = kingCol + dirs[i].dCol * knightColDx;
						for (int j = 0; j < 4; j++)
						{
							int qqRow = nnRow + dirs[j].dRow * knightRowDx;
							int qqCol = nnCol + dirs[j].dCol * knightColDx;
							if (qqRow == qRow && qqCol == qCol)
							{
								count++;
							}
						}
					}
				}
				else
				{
					(int dRow, int dCol)[] dirs = new[]
					{
						(-1, -1),
						(-1, 1),
						(1, -1),
						(1, 1)
					};
					for (int i = 0; i < 4; i++)
					{
						int nnRow = kingRow + dirs[i].dRow * knightRowDx;
						int nnCol = kingCol + dirs[i].dCol * knightColDx;
						//(new { kingRow, kingCol, qRow, qCol, nnRow, nnCol }).ToString().Dump();
						for (int j = 0; j < 4; j++)
						{
							int qqRow = nnRow + dirs[j].dRow * knightRowDx;
							int qqCol = nnCol + dirs[j].dCol * knightColDx;
							if (qqRow == qRow && qqCol == qCol)
							{
								count++;
							}

							qqRow = nnRow + dirs[j].dRow * knightColDx;
							qqCol = nnCol + dirs[j].dCol * knightRowDx;
							if (qqRow == qRow && qqCol == qCol)
							{
								count++;
							}
						}
						
						nnRow = kingRow + dirs[i].dRow * knightColDx;
						nnCol = kingCol + dirs[i].dCol * knightRowDx;
						//(new { kingRow, kingCol, qRow, qCol, nnRow, nnCol }).ToString().Dump();
						for (int j = 0; j < 4; j++)
						{
							int qqRow = nnRow + dirs[j].dRow * knightRowDx;
							int qqCol = nnCol + dirs[j].dCol * knightColDx;
							if (qqRow == qRow && qqCol == qCol)
							{
								count++;
							}

							qqRow = nnRow + dirs[j].dRow * knightColDx;
							qqCol = nnCol + dirs[j].dCol * knightRowDx;
							if (qqRow == qRow && qqCol == qCol)
							{
								count++;
							}
						}
					}
				}

				Console.WriteLine(count);
			}
		}
	}

	public static class Scanner
	{
		public static string String() => Console.ReadLine().Trim();
		public static int Int() => int.Parse(Console.ReadLine().Trim());
		public static long Long() => long.Parse(Console.ReadLine().Trim());
		public static (int, int) IntInt()
		{
			int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			Debug.Assert(line.Length == 2);
			return (line[0], line[1]);
		}
		public static (int, int, int) IntIntInt()
		{
			int[] line = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
			Debug.Assert(line.Length == 3);
			return (line[0], line[1], line[2]);
		}
		public static T[] Array<T>() => Console.ReadLine().Trim()
			.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
			.Select(x => (T)Convert.ChangeType(x, typeof(T)))
			.ToArray();
	}
}
