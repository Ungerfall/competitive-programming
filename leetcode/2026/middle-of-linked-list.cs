#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
ListNode? head = "[1,2,3,4,5,6]".DeserializeToLinkedList();
var result = s.MiddleNode(head);
result.Print(Console.Out);

public class Solution {
    public ListNode MiddleNode(ListNode head) {
        if (head?.next is null)
        {
            return head;
        }

        ListNode slow = head;
        ListNode fast = head;

        while (fast is not null && fast.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}
