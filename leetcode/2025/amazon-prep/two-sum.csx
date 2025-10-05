#!/usr/bin/env dotnet-script

#define DEBUG
#r "nuget: Dumpify, 0.6.6"
#nullable enable

using Dumpify;

int[] nums = [2,7,11,15];
int target = 9;
Solution s = new();
s.TwoSum(nums, target).Dump();

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
      Dictionary<int, int> targetAndIndex = [];
      for (int i = 0; i < nums.Length; i++)
      {
        int num = nums[i];
        if (targetAndIndex.TryGetValue(target - num, out int index))
        {
          return [index, i];
        }

        targetAndIndex[num] = i;
      }

      Debug.Fail("result is always exist");
      return [];
    }
}
