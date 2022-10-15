using leetCode.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.LinkedList
{
    internal class DeleteMiddle
    {
        /*
        * Ref: https://leetcode.com/problems/delete-the-middle-node-of-a-linked-list/
        * LeetCode: 2095. Delete the Middle Node of a Linked List
        * Tag: #greedy, #2hop, #medium
        * Date: 10/14/2022
        * Test case: [1,3,4,7,1,2,6],  [1,2,3,4], [2,1]
        * Time Complexity: 
        * Space Complexity:
        */

        public ListNode solve(ListNode head)
        {
            if (head == null || head.next == null)
                return null;

            //step01: create int vars to hold numOfNodes & index of node to remove.
            int noOfItems, indexToRemove;
            noOfItems = 1;
            indexToRemove = 0;
            
            //step02: create 2 dummy node, one to iterate & one placeholder "prevNode" of median
            ListNode tempNode = head;
            ListNode prevNode = head;
            
            while (tempNode.next != null)
            {
                noOfItems++;
                int reminder = noOfItems / 2;

                //step03: if node to remove != storedIndexToRemove update.
                if (reminder - 1 != indexToRemove)
                {
                    indexToRemove++;
                    prevNode = prevNode.next;
                }
                tempNode = tempNode.next;
            }

            prevNode.next = prevNode.next.next;
            return head;
        }

        public ListNode solveV2(ListNode head)
        {
            if (head.next == null)
                return null;
            var slow = head;
            var fast = head.next.next;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;

            return head;
        }

        public void Driver()
        {
            //var inputReq = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
            var inputReq = new ListNode(1, 
                new ListNode(3, 
                new ListNode(4, 
                new ListNode(7, 
                new ListNode(1,
                new ListNode(2,
                new ListNode(6)
                ))))));

            var retVal = solveV2(inputReq);
            Console.WriteLine("DeleteMiddle");
        }
    }
}
