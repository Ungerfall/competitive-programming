<Query Kind="Program" />

void Main()
{
	var s = new Solution();
	s.MiddleNode(ToListNode(new[] {1,2,3,4,5})).Dump();
	s.MiddleNode(ToListNode(new[] {1,2,3,4,5,6})).Dump();
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
	public ListNode MiddleNode(ListNode head)
	{
		if (head.next == null)
			return head;

		ListNode one = head;
		ListNode two = head.next;
		while (two != null)
		{
			one = one.next;
			two = two.next?.next;
		}
		
		return one;
	}
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
