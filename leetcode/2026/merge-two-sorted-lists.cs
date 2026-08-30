#!/usr/bin/env dotnet run

using System.Text;

Solution s = new();
ListNode? list1 = ListNode.FromJsonArray("[1]");
ListNode? list2 = ListNode.FromJsonArray("[]");
var result = s.MergeTwoLists(list1, list2);
Console.WriteLine(result);

public class Solution
{
    public ListNode MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        ListNode? left = list1;
        ListNode? right = list2;
        ListNode mergedRoot = new();
        ListNode merged = mergedRoot;
        //Console.WriteLine("left: " + left + " right: " + right);
        while (left != null || right != null)
        {
            if (left == null || right?.val < left.val)
            {
                merged.next = new(right.val);
                right = right.next;
            } else if (right == null || left?.val < right.val)
            {
                merged.next = new(left.val);
                left = left.next;
            } else
            {
                merged.next = new(left.val);
                merged.next.next = new(right.val);
                right = right.next;
                left = left.next;
                merged = merged.next;
            }

            merged = merged.next;
            //Console.WriteLine("in loop:" + mergedRoot);
        }

        return mergedRoot.next;
    }
}

public class ListNode
{
    public int val;
    public ListNode? next;
    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }

    public static ListNode? FromJsonArray(string jsonArray)
    {
        ReadOnlySpan<char> body = jsonArray[1..^1].AsSpan().Trim();
        if (body.IsEmpty)
        {
            return null;
        }

        ListNode root = new();
        ListNode current = root;
        foreach (Range range in body.Split(','))
        {
            current.next = new(int.Parse(body[range]));
            current = current.next;
        }

        return root.next;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        for (ListNode? current = this; current != null; current = current.next)
        {
            sb.Append(current.val + "->");
        }

        sb.Length -= 2;
        return sb.ToString();
    }
}
