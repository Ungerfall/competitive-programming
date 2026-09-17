#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
var result = s.FirstBadVersion(10);
string print = result.ToString();
Console.WriteLine(print);

public abstract class VersionControl
{
    protected bool IsBadVersion(int version)
    {
    }
}

public class Solution : VersionControl {
    public int FirstBadVersion(int n) {
        int left = 1;
        int right = n;
        int firstBad = n;
        while (left <= right)
        {
            int mid = left + ((right - left) / 2);
            if (base.IsBadVersion(mid))
            {
                firstBad = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return firstBad;
    }
}
