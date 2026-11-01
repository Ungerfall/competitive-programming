#!/usr/bin/env dotnet run

#:include utils.cs

using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

Solution solution = new();
int[] nums = "[-1,0,1,2,-1,-4]".DeserializeToArray();
var result = solution.ThreeSum(nums);
result.Print(Console.Out);

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        List<int[]> valid = [];
        HashSet<(int first, int second, int third)> uniques = [];
        for (int i = 0; i < nums.Length; i++)
        {
            int target = 0 - nums[i];
            Dictionary<int, int> targets = [];
            for (int j = i + 1; j < nums.Length; j++)
            {
                int remaining = target - nums[j];
                if (targets.TryGetValue(remaining, out int index))
                {
                    valid.Add([nums[i], nums[j], nums[index]]);
                }

                targets[nums[j]] = j;
            }
        }

        foreach (int[] triple in valid)
        {
            Array.Sort(triple);
            uniques.Add((triple[0], triple[1], triple[2]));
        }

        return uniques
            .Select(x => (IList<int>)[x.first, x.second, x.third])
            .ToList();
    }
}
