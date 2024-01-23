<Query Kind="Program" />

void Main()
{
	AtmState[] initial = new AtmState[]
	{
		new AtmState { Nominal = 50, Count = 1},
		new AtmState { Nominal = 100, Count = 4},
		new AtmState { Nominal = 1000, Count = 1},
	};
	AtmState[] initial2 = new AtmState[]
	{
		new AtmState { Nominal = 50, Count = 0},
		new AtmState { Nominal = 100, Count = 0},
		new AtmState { Nominal = 1000, Count = 0},
	};
	AtmState[] initial3 = new AtmState[]
	{
		new AtmState { Nominal = 5000, Count = 1},
	};
	
	AtmState[] initial4 = new AtmState[]
	{
		new AtmState { Nominal = 50, Count = 2},
		new AtmState { Nominal = 500, Count = 1},
	};
	AtmState[] initial5 = new AtmState[]
	{
		new AtmState { Nominal = 50, Count = 1},
	};
	
	Test(150, initial);
	Test(12345, initial2);
	Test(4950, initial3);
	Test(550, initial4);
	Test(100, initial5);
}

void Test(decimal requestedAmount, AtmState[] state)
{
	var atm = new ATM(state);
	var (err, response) = atm.Withdraw(requestedAmount);
	if (!err)
	{
		//response.Dump();
		Console.WriteLine("Success");
		decimal amount = response.Sum(x => x.Key * x.Value);
		Console.WriteLine($"Are amount equal: {(amount == requestedAmount)}");
	}
	else
	{
		Console.WriteLine("Error");
	}
	
}

/*
 * Банкомат.
 * Инициализируется набором купюр и умеет выдавать купюры для заданной суммы, либо отвечать отказом. 
 * При выдаче купюры списываются с баланса банкомата.
 * Допустимые номиналы: 50₽, 100₽, 500₽, 1000₽, 5000₽.
 */

public class AtmResponse
{
	public int Nominal { get; set; }
	public int Count { get; set;}
}
public class AtmState
{
	public int Nominal { get; set; }
	public int Count { get; set;}
}
public class ATM
{
	private Dictionary<int, int> _state;
	public ATM(IReadOnlyCollection<AtmState> initial)
	{
		_state = initial.ToDictionary(x => x.Nominal, v => v.Count);
	}
	
	public (bool error, Dictionary<int, int> response) Withdraw(decimal requestedAmount)
	{
		decimal availableAmount = _state.Sum(x => x.Key * x.Value);
		if (availableAmount < requestedAmount)
		{
			return (error: true, new Dictionary<int, int>());
		}
		
		var response = new Dictionary<int, int>();
		var nominalsCopy = DeepCopy(_state);
		bool canChangeRequested = canChange(ref requestedAmount, response);
		if (canChangeRequested)
		{
			_state = nominalsCopy;
		}
		
		return (!canChangeRequested, response);
		
		bool canChange(ref decimal amount, Dictionary<int, int> response)
		{
			if (amount == 0)
			{
				return true;
			}
			
			//(nominalsCopy, amount).Dump();
			bool nomianlFound = false;
			foreach (var n in nominalsCopy.OrderByDescending(x => x.Key))
			{
				// 150: 100 + 50 OR 50 + 50 + 50
				int nominal = n.Key;
				if (nominal <= amount && n.Value > 0 && amount > 0)
				{
					nominalsCopy[nominal]--;
					nomianlFound = true;
					if (response.TryGetValue(n.Key, out int count))
					{
						response[nominal] = count + 1;
					}
					else
					{
						response[nominal] = 1;
					}
					
					amount -= nominal;
					nomianlFound = canChange(ref amount, response);
					break;
				}
			}

			//$"Here {nomianlFound}".Dump();
			return nomianlFound && amount == 0;
		}
	}
	
	Dictionary<int, int> DeepCopy(Dictionary<int, int> state)
	{
		var copy = new Dictionary<int, int>();
		foreach (var s in state)
		{
			copy[s.Key] = s.Value;
		}
		
		return copy;
	}
}
