<Query Kind="Program">
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

void Main()
{
	var input = new[] {
		"YandezCuzwwwwwwwwYandexwwwwww",
		"yandexcup",
		"cupyandex",
		"YandexYetAnotherCup",
		"YanCupdex",
		"salkdfjhdskfgpsajdhfgk",
		};
	foreach (var l in input)
	{
		using (StringReader simulatedInput = new StringReader(l))
		{
			Console.SetIn(simulatedInput);
			Program.Main(null);
		}
	}
}

public class Program
{
	public static void Main(string[] args)
	{
		var line = Console.ReadLine();
		ReadOnlySpan<char> candidate = line;
		ReadOnlySpan<char> yandex = "Yandex";
		ReadOnlySpan<char> cup = "Cup";

		int minTotalDistance = int.MaxValue;
		int closestYandex = 0;
		int closestCup = 0;
		for (int i = 0; i <= candidate.Length - yandex.Length; i++)
		{
			ReadOnlySpan<char> yandexSubstring = candidate.Slice(i, yandex.Length);
			int distance1 = LevenshteinDistance(yandex, yandexSubstring);

			for (int j = i + yandex.Length; j <= candidate.Length - cup.Length; j++)
			{
				ReadOnlySpan<char> cupSubstring = candidate.Slice(j, cup.Length);
				int distance2 = LevenshteinDistance(cup, cupSubstring);

				int totalDistance = distance1 + distance2;

				if (totalDistance < minTotalDistance)
				{
					minTotalDistance = totalDistance;
					closestYandex = i;
					closestCup = j;
					if (minTotalDistance == 0)
					{
						goto FINISH;
					}
				}
			}
		}
FINISH:
		
		Console.WriteLine(line
			.Remove(closestYandex, yandex.Length)
			.Insert(closestYandex, yandex.ToString())
			.Remove(closestCup, cup.Length)
			.Insert(closestCup, cup.ToString())
		);
	}

	static int LevenshteinDistance(ReadOnlySpan<char> s1, ReadOnlySpan<char> s2)
	{
		int[,] dp = new int[s1.Length + 1, s2.Length + 1];

		for (int i = 0; i <= s1.Length; i++)
		{
			for (int j = 0; j <= s2.Length; j++)
			{
				if (i == 0)
					dp[i, j] = j;
				else if (j == 0)
					dp[i, j] = i;
				else if (s1[i - 1] == s2[j - 1])
					dp[i, j] = dp[i - 1, j - 1];
				else
					dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
			}
		}

		return dp[s1.Length, s2.Length];
	}
}