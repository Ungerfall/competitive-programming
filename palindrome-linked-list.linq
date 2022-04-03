<Query Kind="Program" />

void Main()
{
	var a0 = new[] {1,2};

	var s = new Solution();
	var l0 = ToListNode(a0);
	
	s.IsPalindrome(l0).Dump();
}
private ListNode ToListNode(int[] a)
{
	var start = new ListNode(a[0]);
	var node = start;
	for (int i = 1; i < a.Length; i++)
	{
		node.next = new ListNode(a[i]);
		node = node.next;
	}
	
	return start;
}
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}
public class Solution
{
	public bool IsPalindrome(ListNode head)
	{
		var v = new List<int>();
		while (head != null)
		{
			v.Add(head.val);
			head = head.next;
		}
		
		var source = v.ToArray();
		int[] a0;
		int[] a1;
		var middle = v.Count / 2;
		if (v.Count % 2 == 1)
		{
			a0 = source[0..middle];
			a1 = source[(middle+1)..^0];
		}
		else
		{
			a0 = source[0..middle];
			a1 = source[middle..^0];
		}
		
		Array.Reverse(a1);
		
		return a0.SequenceEqual(a1);
	}
}