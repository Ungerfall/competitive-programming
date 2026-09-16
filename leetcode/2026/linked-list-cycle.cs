#!/usr/bin/env dotnet run

#:include utils.cs

using System.Text;
using System.Text.Json.Serialization;

Solution s = new();
ListNode? listNode = "[3,2,0,-4]".DeserializeToLinkedList();
var result = s.HasCycle(listNode);
string print = result.ToString();
Console.WriteLine(print);

public class Solution {
    public bool HasCycle(ListNode head) {
        if (head is null || head.next is null)
        {
            return false;
        }
        
        ListNode? slow = head;
        ListNode? fast = head;

        while (fast is not null && fast.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (object.ReferenceEquals(slow, fast))
            {
                return true;
            }
        }

        return false;
    }
}
