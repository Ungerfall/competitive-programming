#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int[] nums = "[-2,1,-3,4,-1,2,1,-5,4]".DeserializeToArray();
var result = s.MaxSubArray(nums);
string print = result.ToString();
Console.WriteLine(print);

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        if (nums is null || nums.Length == 0)
        {
            return 0;
        }

        int running = nums[0];
        int max = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            running = Math.Max(nums[i], running + nums[i]);
            max = Math.Max(max, running);
        }

        return max;
    }
}
