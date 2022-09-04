using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Easy
{
    /*
    * Question:
    * Hint:
    * Test cases:
    * Failed cases:
    * Explain:
    */
    internal class reverseLinkedlist
    {
        List<LinkedList.ListNode> singlyLinkedList = new List<LinkedList.ListNode>();
        public reverseLinkedlist(int[] linkedarray)
        {
            for (int i = 0; i <= linkedarray.Length - 1; i++)
            {
                singlyLinkedList.Add(new LinkedList.ListNode(linkedarray[i]));
            }

            for (int i = 0; i <= singlyLinkedList.Count - 1; i++)
            {
                if (i != (singlyLinkedList.Count - 1))
                    singlyLinkedList[i].next = singlyLinkedList[i + 1];
            }
        }

        public LinkedList.ListNode ReverseList(LinkedList.ListNode head)
        {
            if (head == null) return null;
            LinkedList.ListNode next, current, previous;
            next = current = singlyLinkedList[0];
            previous = null;

            while (next.next != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;

            }
            current.next = previous;

            head = current;
            return head;
        }
    }

    public class LinkedList
    {
        public ListNode Head { get; set; }
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
    }

}

