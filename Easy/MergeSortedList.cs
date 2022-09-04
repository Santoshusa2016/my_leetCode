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
    internal class MergeSortedList
    {
        public LinkedList.ListNode MergeTwoLists(LinkedList.ListNode list1, LinkedList.ListNode list2)
        {
            List<LinkedList.ListNode> sortedNodes = new List<LinkedList.ListNode>();

            while (list1 != null && list2 != null)
            {
                //when list1 value is lesser
                while ((list1 != null && list2 != null) && list1.val <= list2.val)
                {
                    sortedNodes.Add(new LinkedList.ListNode(list1.val));
                    list1 = list1.next;                    
                }

                while ((list1 != null && list2 != null) && list1.val > list2.val)
                {
                    sortedNodes.Add(new LinkedList.ListNode(list2.val));
                    list2 = list2.next;
                }
            }

            //If any item from list1 is not added
            while (list1 != null)
            {
                sortedNodes.Add(new LinkedList.ListNode(list1.val));
                list1 = list1.next;
            }

            //If any item from list2 is not added
            while (list2 != null)
            {
                sortedNodes.Add(new LinkedList.ListNode(list2.val));
                list2 = list2.next;
            }

            if (sortedNodes.Count <=0)
                return null;

            //do in reverse
            for (int i = sortedNodes.Count-2; i >= 0; i--)
            {
                sortedNodes[i].next = sortedNodes[i + 1];
            }

            
            return sortedNodes[0];
        }

        public LinkedList.ListNode MergeTwoListsRec(LinkedList.ListNode l1, LinkedList.ListNode l2)
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


        public LinkedList.ListNode MergeTwoListsOpt(LinkedList.ListNode l1, LinkedList.ListNode l2)
        {
            // base case validations
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            var newNode = new LinkedList.ListNode(0); // Creating this dummy node ease the logic
            var tempPointer = newNode; //tempPointer used for pointing to next node

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

                tempPointer = tempPointer.next;
            }

            // Simply add the 'leftover' from the while loop at the end 
            if (l1 != null) tempPointer.next = l1;
            if (l2 != null) tempPointer.next = l2;

            return newNode.next;
        }

       
    }

}
