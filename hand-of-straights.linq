<Query Kind="Program" />

void Main()
{
	Solution s = new();
	int[] hand = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,3,6,2,3,4,7,8]");
	//s.IsNStraightHand(hand, 3).Dump();
	hand = System.Text.Json.JsonSerializer.Deserialize<int[]>("[8,8,9,7,7,7,6,7,10,6]");
	s.IsNStraightHand(hand, 2).Dump();
	hand = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1]");
	//s.IsNStraightHand(hand, 1).Dump();
	hand = System.Text.Json.JsonSerializer.Deserialize<int[]>("[8,10,12]");
	//s.IsNStraightHand(hand, 3).Dump();
	hand = System.Text.Json.JsonSerializer.Deserialize<int[]>("[1,2,3,6,2,3,4,7,8]");
	//s.IsNStraightHand(hand, 3).Dump();
	hand = System.Text.Json.JsonSerializer.Deserialize<int[]>("[9,13,15,23,22,25,4,4,29,15,8,23,12,19,24,17,18,11,22,24,17,17,10,23,21,18,14,18,7,6,3,6,19,11,16,11,12,13,8,26,17,20,13,19,22,21,27,9,20,15,20,27,8,13,25,23,22,15,9,14,20,10,6,5,14,12,7,16,21,18,21,24,23,10,21,16,18,16,18,5,20,19,20,10,14,26,2,9,19,12,28,17,5,7,25,22,16,17,21,11]");
	//s.IsNStraightHand(hand, 10).Dump();
}

public class Solution
{
	public bool IsNStraightHand(int[] hand, int groupSize)
	{
		if (groupSize == 1)
			return true;
		if (hand.Length % groupSize != 0)
			return false;
			
		SortedDictionary<int, int> d = new();
		
		for (int i = 0; i < hand.Length; i++)
		{
			if (d.TryGetValue(hand[i], out int count))
			{
				d[hand[i]] = count + 1;
			}
			else
			{
				d[hand[i]] = 1;
			}
		}
		
		Queue<int> q = new(capacity: groupSize);
		Queue<int> nextQ = new(capacity: groupSize);
		foreach (var k in d.Keys.ToList())
		{
			if (q.Count < groupSize - 1)
			{
				q.Enqueue(k);
				continue;
			}
			
			q.Enqueue(k);
			while (q.Count > 0)
			{
				int current = q.Dequeue();
				if (q.TryPeek(out int next))
				{
					if (next != current + 1)
						return false;
				}
				
				int count = d[current];
				//(current, count).ToString().Dump();
				if (count > 1)
				{
					d[current] = count - 1;
					nextQ.Enqueue(current);
				}
			}
			
			if (nextQ.TryPeek(out int deq) && nextQ.Count == groupSize)
			{
				int decrementCount = d[deq];
				foreach (var nq in nextQ)
				{
					d[nq] -= decrementCount;
				}
			}
			
			while (nextQ.Count > 0)
			{
				int key = nextQ.Dequeue();
				int count = d[key];
				if (count > 0)
					q.Enqueue(key);
			}
		}
		
		return q.Count == 0;
	}
}