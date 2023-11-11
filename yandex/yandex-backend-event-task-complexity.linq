<Query Kind="Program" />

void Main()
{
	var input = """
		8
		2 4 5 6 6 7 10 17
	""";
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		TaskComplexity.Find();
	}
}

public class TaskComplexity
{
	public static void Find()
	{
		int n = int.Parse(Console.ReadLine());
		var tasks = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
		
		if (tasks.Length % 2 != 0)
		{
			Console.WriteLine(-1);
			return;
		}
		
		bool possible = true;
		int taskComplecity = tasks[0] + tasks[^1];
		if (tasks.Length == 2)
		{
			Console.WriteLine(taskComplecity);
		}
		
		int left = 1;
		int right = tasks.Length - 2;
		while (left < right)
		{
			if (tasks[left] + tasks[right] != taskComplecity)
			{
				possible = false;
				break;
			}
			
			left++;
			right--;
		}
		
		if (possible)
		{
			Console.WriteLine(taskComplecity);
		}
		else
		{
			Console.WriteLine(-1);
		}
	}
}