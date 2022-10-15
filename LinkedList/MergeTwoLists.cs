using leetCode.Common;
using System;
using System.Collections.Generic;

namespace leetCode.LinkedList
{
    /*
    * Ref: https://leetcode.com/problems/merge-two-sorted-lists/
    * LeetCode: 21. Merge Two Sorted Lists
    * Tag: #recursion, #easy
    * Date: 10/13/2022
    * Test case: ["eat","tea","tan","ate","nat","bat"],  [""]
    * Time Complexity: 
    * Space Complexity:
    */
    internal class MergeTwoLists
    {
        public ListNode solve(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }

            List<ListNode> listNodes = new List<ListNode>();
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    listNodes.Add(new ListNode(list1.val));
                    list1 = list1.next;
                }
                else
                {
                    listNodes.Add(new ListNode(list2.val));
                    list2 = list2.next;
                }
            }

            while (list1 != null)
            {
                listNodes.Add(new ListNode(list1.val));
                list1 = list1.next;
            }

            while (list2 != null)
            {
                listNodes.Add(new ListNode(list2.val));
                list2 = list2.next;
            }

            for (int i = 0; i < listNodes.Count - 1; i++)
            {
                listNodes[i].next = listNodes[i + 1];
            }

            return listNodes[0];
        }


        ListNode MergeTwoListsRec(ListNode l1, ListNode l2)
        {
            //base condition
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            if (l2.val > l1.val)
            {
                l1.next = MergeTwoListsRec(l1.next, l2);
                return l1;
            }

            l2.next = MergeTwoListsRec(l1, l2.next);
            return l2;

        }


        ListNode MergeTwoListsOpt(ListNode l1, ListNode l2)
        {
            // base case validations
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var newNode = new ListNode(0); // The newNode is mapped to next of TempPointer node
            var tempPointer = newNode; //tempPointer used for pointing to next node

            /*TypedReference tr = __makeref(newNode);
            IntPtr ptr = **(IntPtr**)(&tr);
            TypedReference tr1 = __makeref(tempPointer);
            IntPtr ptr1 = **(IntPtr**)(&tr1);*/

            while (l1 != null && l2 != null)
            {
                if (l1.val >= l2.val)
                {
                    tempPointer.next = l2;
                    l2 = l2.next;
                }
                else
                {
                    tempPointer.next = l1;
                    l1 = l1.next;
                }

                //newNode.Next now points to tempPointer
                tempPointer = tempPointer.next;
            }

            // Simply add the 'leftover' from the while loop at the end 
            if (l1 != null) tempPointer.next = l1;
            if (l2 != null) tempPointer.next = l2;

            return newNode.next;
        }

        public void Driver()
        {
            var inputVal1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            var inputVal2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            MergeTwoListsOpt(inputVal1, inputVal2);
        }

    }
}
