<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	/*
	s.CheckOverlap(1, 0, 0, 1, -1, 3, 2).Dump();
	s.CheckOverlap(1, 1, 1, 1, -3, 2, -1).Dump();
	s.CheckOverlap(1, 0, 0, -1, 0, 0, 1).Dump();
	*/
	s.CheckOverlap(1415, 807, -784, -733, 623, 533, 1005).Dump();
}

public class Solution
{
	public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
	{
		double distance(int x, int y) => Math.Sqrt(Math.Pow(xCenter - x, 2d) + Math.Pow(yCenter - y, 2d));

		if (xCenter >= x1 && xCenter <= x2 && yCenter >= y1 && yCenter <= y2)
			return true;
			
		var closestX = Math.Clamp(xCenter, x1, x2);
		var closestY = Math.Clamp(yCenter, y1, y2);
		if (distance(closestX, y1) <= radius
			|| distance(closestX, y2) <= radius
			|| distance(x1, closestY) <= radius
			|| distance(x2, closestY) <= radius)
			return true;
			
		return false;
	}
}