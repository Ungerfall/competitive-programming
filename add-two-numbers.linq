<Query Kind="Program" />

void Main()
{
	var a0 = new[] {9,9,9,9,9,9,9};
	var a1 = new[] {9,9,9,9};

	var s = new Solution();
	var l0 = ToListNode(a0);
	var l1 = ToListNode(a1);
	
	s.AddTwoNumbers(l0, l1).Dump();
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
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		ListNode start = new();
		ListNode node = start;
		var add = 0;		
		while (true)
		{
			int l1Val = l1?.val ?? 0;
			int l2Val = l2?.val ?? 0;
			int sum = l1Val + l2Val + add;
			add = sum / 10;
			node.val = sum % 10;
			l1 = l1?.next;
			l2 = l2?.next;
			if (l1 == null && l2 == null)
				break;
				
			node.next = new ListNode();
			node = node.next;
		}
		
		if (add == 1)
			node.next = new ListNode(add, null);
			
		return start;
	}
}