#!/usr/bin/env dotnet run

Solution s = new();
var result = s.TwoSum([2,7,11,15], 9);
string print = result switch
{
    [] => "[]",
    [..] => string.Join(',', result),
    _ => result.ToString()
};
Console.WriteLine(print);

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> targets = [];
        for (int i = 0; i < nums.Length; i++)
        {
            int remaining = target - nums[i];
            if (targets.TryGetValue(remaining, out int index))
            {
                return [index, i];
            }

            targets[nums[i]] = i;
        }

        return [];
    }
}
