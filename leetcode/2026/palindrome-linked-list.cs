#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
ListNode? head = "[1,0,3,4,0,1]".DeserializeToLinkedList();
var result = s.IsPalindrome(head);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public bool IsPalindrome(ListNode head) {
        if (head?.next is null)
        {
            return true;
        }

        ListNode slow = head!;
        ListNode fast = head!;
        while (fast is not null && fast.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        //head.Print(Console.Out);
        //slow.Print(Console.Out);

        ListNode prev = slow;
        ListNode current = slow.next;
        prev.next = null;
        while (current is not null)
        {
            ListNode? next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        ListNode tail = prev;
        while (tail is not null)
        {
            if (tail.val != head.val)
            {
                return false;
            }

            tail = tail.next;
            head = head.next;
        }

        return true;
    }
}
