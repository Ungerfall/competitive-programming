#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
int[] nums = "[1,1,1,3,3,4,3,2,4,2]".DeserializeToArray();
var result = s.ContainsDuplicate(nums);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> seen = new(capacity: nums.Length);
        foreach (int num in nums)
        {
            if (!seen.Add(num))
            {
                return true;
            }
        }

        return false;
    }
}
