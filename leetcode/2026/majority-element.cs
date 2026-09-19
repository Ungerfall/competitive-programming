#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int[] nums = "[2,2,1,1,1,2,2]".DeserializeToArray();
var result = s.MajorityElement(nums);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public int MajorityElement(int[] nums)
    {
        int candidate = -1;
        int votes = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (votes == 0)
            {
                candidate = nums[i];
                votes = 1;
            }
            else
            {
                if (candidate == nums[i])
                {
                    votes++;
                }
                else
                {
                    votes--;
                }
            }
        }

        return candidate;
    }
}
