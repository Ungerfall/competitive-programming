<Query Kind="Program">
  <RuntimeVersion>6.0</RuntimeVersion>
</Query>

void Main()
{
	var input = """
		9
		Ivan 1
		Anton 1
		Victor 2
		Anton 3
		Ivan 5
		Denis 10
		Victor 11
		Anton 11
		Ivan 12
	""";
	using (StringReader simulatedInput = new StringReader(input))
	{
		Console.SetIn(simulatedInput);
		Team.Solve();
	}
}

public class Team
{
	public static void Solve()
	{
		var team = new Dictionary<string, TeamExp>();
		var events = int.Parse(Console.ReadLine().Trim());
		var (name, time) = Console.ReadLine().Trim().Split();
		long sum = 0;
		long maxExp = 0;
		int prevTime = time;
		int activeMembers = 1;
		string topExp = name;
		for (int i = 1; i < events; i++)
		{
			(name, time) = Console.ReadLine().Trim().Split();
			int exp = time - prevTime;
			maxExp += exp;
			sum += activeMembers * exp;
			if (team.TryGetValue(name, out TeamExp expa))
			{
				activeMembers--;
				if (expa.Active)
				{
					expa.Active = false;
					sum -= time - expa.Joined;
					if (topExp == name)
					{
						foreach (var member in team)
						{
							
						}
					}
				}
				else
				{
					expa.Active = true;
					expa.Joined = time;
				}
			}
			else
			{
				activeMembers++;
				team[name] = new TeamExp { Joined = time, Active = true };
				if (maxExp == 0 && string.Compare(name, topExp) < 0)
				{
					topExp = name;
				}
			}
			
			//team.Dump();
			//Console.WriteLine($"{name} {time} {topExp[0]} {sum - maxExp - maxExp}");
			Console.WriteLine($"{topExp} {sum - maxExp - maxExp}");
		}
	}
}

public class TeamExp
{
	public int Joined {get;set;}
	public bool Active {get;set;}
}

public static class StringArrayExtensions
{
	public static void Deconstruct(this string[] array, out string first, out int second)
	{
		first = array.Length > 0 ? array[0] : null;
		second = array.Length > 1 ? int.Parse(array[1]) : default;
	}
}
