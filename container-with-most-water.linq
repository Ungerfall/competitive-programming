<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.MaxArea(new[]{1,8,6,2,5,4,8,3,7}).Dump();
	s.MaxArea(new[]{3,9,3,4,7,2,12,6}).Dump();
	s.MaxArea(new[]{2,3,4,5,18,17,6}).Dump();
	s.MaxArea(new[]{1,8,6,2,5,4,8,3,7}).Dump();
}

public class Solution
{
	public int MaxArea(int[] height)
	{
		if (height.Length == 2)
			return Math.Min(height[0], height[1]);

		int max = 0;
		int left = 0;
		int right = height.Length - 1;
		while (left < right)
		{
			max = Math.Max(max, CalcArea(left, right, height[left], height[right]));
			if (height[left] < height[right])
			{
				left++;
			}
			else
			{
				right--;
			}
		}

		return max;
	}
	
	static int CalcArea(int left, int right, int hLeft, int hRight)
	{
		return Math.Min(hLeft, hRight) * (right - left);
	}
}