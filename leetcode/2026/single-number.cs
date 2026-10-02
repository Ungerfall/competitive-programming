#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
var result = s.SingleNumber([1,2,2]);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public int SingleNumber(int[] nums) {
        int single = nums
            .Skip(1)
            .Aggregate(nums[0], (acc, n) => acc ^ n);

        return single;
    }
}
