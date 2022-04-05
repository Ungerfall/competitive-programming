<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.FizzBuzz(1).Dump();
	s.FizzBuzz(3).Dump();
	s.FizzBuzz(15).Dump();
}

public class Solution
{
	public IList<string> FizzBuzz(int n)
	{
		var output = new List<string>();
		for (int i = 1; i <= n; i++)
		{
			string w = (i % 3, i % 5) switch
			{
				(0, 0) => "FizzBuzz",
				(0, _) => "Fizz",
				(_, 0) => "Buzz",
				_ => i.ToString()
			};
			output.Add(w);
		}
		
		return output;
	}
}