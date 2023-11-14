<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.Rob(new int[] { 2, 1, 1, 2 }).Dump();

}
public class Solution
{
	public int Rob(int[] nums)
	{
		var maxByHouse = new Dictionary<(int house, int sum), int>();
		return Math.Max(findMax(0, 0), findMax(1, 0));

		int findMax(int house, int sum)
		{
			if (house >= nums.Length)
			{
				return sum;
			}

			var key = (house, sum);
			if (maxByHouse.ContainsKey(key))
			{
				return maxByHouse[key];
			}

			int max = Math.Max(findMax(house + 2, sum + nums[house]), findMax(house + 3, sum + nums[house]));
			maxByHouse[key] = max;
			return max;
		}
	}
}