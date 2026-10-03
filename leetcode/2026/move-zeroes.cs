#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int[] nums = "[0,1,0,3,12]".DeserializeToArray();
s.MoveZeroes(nums);
Console.WriteLine(string.Join(',', nums));

public class Solution {
    public void MoveZeroes(int[] nums) {
        int offset = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                offset++;
            }
            else if (offset > 0)
            {
                nums[i - offset] = nums[i];
                nums[i] = 0;
            }
        }
    }
}
