<Query Kind="Program" />

void Main()
{
	Solution s = new();
	s.MinFlips(2, 6, 5).Dump();
	s.MinFlips(4, 2, 7).Dump();
	s.MinFlips(1, 2, 3).Dump();
	s.MinFlips(8, 3, 5).Dump();
}

public class Solution
{
	public int MinFlips(int a, int b, int c)
	{
		string aa = Convert.ToString(a, 2);
		string bb = Convert.ToString(b, 2);
		string cc = Convert.ToString(c, 2);
		int maxLen = Math.Max(Math.Max(aa.Length, bb.Length), cc.Length);
		aa = aa.PadLeft(maxLen, '0');
		bb = bb.PadLeft(maxLen, '0');
		cc = cc.PadLeft(maxLen, '0');
		//(aa, bb, cc).ToString().Dump();
		
		int flips = 0;
		for (int i = 0; i < maxLen; i++)
		{
			if (cc[i] == '0')
			{
				if (aa[i] == '1')
				{
					flips++;
				}
				
				if (bb[i] == '1')
				{
					flips++;
				}
			}
			else
			{
				if (aa[i] == '0' && bb[i] == '0')
				{
					flips++;
				}
			}
		}
		
		return flips;
	}
}