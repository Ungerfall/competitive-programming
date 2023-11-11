<Query Kind="Program" />

void Main()
{
	var input = """
		100000 100000 
	""";
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		TimePalindrome.Solve();
	}
}

public class TimePalindrome
{
	public static void Solve()
	{
		var (n, m) = Console.ReadLine().Trim().Split();
		var length = Math.Max(n - 1, m - 1).ToString().Length;

		int palinromeCount = 0;
		int min = Math.Min(n - 1, m - 1);
		int max = Math.Max(n - 1, m - 1);
		for (int i = 0; i <= min; i++)
		{
			string hours = i.ToString().PadLeft(length, '0');
			string minutes = new string(hours.Reverse().ToArray());
			int mirror = int.Parse(minutes);
			if (mirror <= max)
			{
				//$"{hours}:{minutes}".Dump();
				palinromeCount++;
			}
		}

		Console.WriteLine(palinromeCount);
	}
}

public static class StringArrayExtensions
{
	public static void Deconstruct(this string[] array, out int first, out int second)
	{
		first = array.Length > 0 ? int.Parse(array[0]) : default;
		second = array.Length > 1 ? int.Parse(array[1]) : default;
	}
}
