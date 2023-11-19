namespace Program
{
	using System;
	using System.Collections.Generic;
	
	public class Program
	{
		public static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine().Trim());
			for (int i = 0; i < n; i++)
			{
				var line = Console.ReadLine().Trim().Split();
				var sLen = int.Parse(line[0]);
				var desiredOfB = int.Parse(line[1]);
				var given = Console.ReadLine().Trim();
				int aCount = 0;
				for (int j = 0; j < given.Length; j++)
				{
					if (given[j] == 'A')
					{
						aCount++;
					}
				}
				
				int bCount = given.Length - aCount;
				if (bCount == desiredOfB)
				{
					Console.WriteLine(0);
					continue;
				}
				
				Console.WriteLine(1);
				if (bCount < desiredOfB)
				{
					int toReplace = desiredOfB - bCount;
					for (int j = 0; j <= toReplace && j < given.Length; j++)
					{
						if (given[j] == 'B')
						{
							toReplace++;
						}
					}

					Console.WriteLine($"{toReplace} B");
				}
				else
				{
					int toReplace = bCount - desiredOfB;
					for (int j = 0; j <= toReplace && j < given.Length; j++)
					{
						if (given[j] == 'A')
						{
							toReplace++;
						}
					}

					Console.WriteLine($"{toReplace} A");
				}
			}
		}
	}
}

