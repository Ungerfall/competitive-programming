<Query Kind="Program">
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	var input = @"10 5
	10 0 1 0 3";
	/*
	var input = @"1 3
	1 1 1";
	*/
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		Program.Main(null);
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		checked
		{
			var line = Console.ReadLine();
			var split = line.Trim().Split();
			int n = int.Parse(split[0]);
			int m = int.Parse(split[1]);
			line = Console.ReadLine();
			int[] primaryScore = line.Trim().Split().Select(x => int.Parse(x)).ToArray();

			long secondaryScore = (long)primaryScore[m - 1] * primaryScore[m - 1];
			var runningScore = new List<long>();
			if (secondaryScore > 0)
			{
				runningScore.Add(primaryScore[m - 1]);
			}
			for (int i = m - 2; i >= 0; i--)
			{
				if (primaryScore[i] == 0)
				{
					continue;
				}

				int primary = primaryScore[i];
				long score = (long)primary * primary;
				long runningScorePrev = 0;
				if (runningScore.Count != 0)
				{
					runningScorePrev = runningScore[runningScore.Count - 1];
					score += primary >= runningScore.Count
						? runningScorePrev
						: runningScorePrev - runningScore[runningScore.Count - primary - 1];
				}

				runningScore.Add(runningScorePrev + primary);
				secondaryScore += score;
			}

			Console.WriteLine(secondaryScore);
		}
	}
}