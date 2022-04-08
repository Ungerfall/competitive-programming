<Query Kind="Program" />

void Main()
{
	var s = new Solution();


	var arr1 = new[] { 1, 2 };
	var arr2 = new[] { 3, 4 };
	s.FindMedianSortedArrays(arr1, arr2).Dump();
	
}

public class Solution
{
	public double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		int[] merged = new int[nums1.Length+nums2.Length];
		
		int i = 0;
		int j = 0;
		int k = 0;
		
		while (i < nums1.Length && j < nums2.Length)
		{
			if (nums1[i] < nums2[j])
			{
				merged[k] = nums1[i];
				i++;
				k++;
			}
			else
			{
				merged[k] = nums2[j];
				j++;
				k++;
			}
		}
		
		while (i < nums1.Length)
		{
			merged[k] = nums1[i];
			i++;
			k++;
		}
		
		while (j < nums2.Length)
		{
			merged[k] = nums2[j];
			j++;
			k++;
		}
		
		return (merged.Length % 2 == 0)
			? (double)(merged[merged.Length/2]+merged[merged.Length/2-1]) / 2
			: merged[merged.Length/2];
	}
}