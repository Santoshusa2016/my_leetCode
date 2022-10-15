using leetCode.Common;
using System;
using static leetCode.Daily.NaryLevelOrderTrav;

namespace leetCode.LinkedList
{

    /*
    * Ref: https://leetcode.com/problems/delete-node-in-a-linked-list/
    * LeetCode: 237. Delete Node in a Linked List
    * Tag: #easy, #medium
    * Date: 10/13/2022
    * Test case: [4,5,1,9]:5,[4,5,1,9]:1
    * Time Complexity: 
    * Space Complexity:
    */

    internal class DeleteNode
    {
        ListNode solve(ListNode node, ListNode _head)
        {
            ListNode currentNode, prevNode = null;
            currentNode = _head; //the idea is to point the temp var to head/child node address

            while (currentNode.val != node.val)
            {
                prevNode = currentNode; 
                currentNode = currentNode.next;
            }

            if (prevNode != null)
                prevNode.next = currentNode.next;
            else
                currentNode = currentNode.next;

            return _head;
        }

        void solveV1(ListNode node)
        {
            if (node == null) return;

            // Step 1: Set value of current node as value of next node
            node.val = node.next == null ? 0 : node.next.val;

            // Step 2: Delete the next node from list
            node.next = node.next == null ? null : node.next.next;
        }
        public void Driver()
        {
            var inputReq = new ListNode(4, new ListNode(5, new ListNode(1, new ListNode(9))));
            ListNode nodeToDelete = new ListNode(5);
            var retVal = solve(nodeToDelete, inputReq);
            Console.WriteLine("DeleteNode");
        }
    }
}
