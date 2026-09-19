#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
ListNode? head = "[1,2,3,4,5]".DeserializeToLinkedList();
head.Print(Console.Out);
var result = s.ReverseList(head);
result.Print(Console.Out);

public class Solution {
    public ListNode ReverseList(ListNode head) {
        if (head?.next is null)
        {
            return head;
        }

        ListNode prev = head;
        head = head.next;
        prev.next = null;
        while (head is not null)
        {
            ListNode? next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
    }
}
