using leetCode.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/odd-even-linked-list
    * LeetCode:328. Odd Even Linked List
    * Tag: #medium, #linkedlist
    * Company:
    * Date: 12/05/2022
    * Time Complexity: 0(N)
    * Space Complexity:O(3)
    */

    internal class OddEvenList
    {
        ListNode solve(ListNode head)
        {
            if (head == null)
                return null;

            ListNode oddCur = new ListNode(),
                     evenDummy = new ListNode(),
                     evenCur = evenDummy;

            /*when pointer node changes, the reference in parent node also changes*/

            oddCur = head; // pointer to head node which keeps changing
            evenDummy = head.next; // a dummy node for storing head->next
            evenCur = evenDummy; // pointer to dummynode which keeps changing

            while (evenCur != null && evenCur.next != null)
            {
                oddCur.next = evenCur.next;
                oddCur = oddCur.next;

                evenCur.next = oddCur.next;
                evenCur = evenCur.next;
            }

            oddCur.next = evenDummy;
            return head;
        }

        ListNode solveV2(ListNode head)
        {
            if (head == null)
                return head;

            ListNode oddDummy = new ListNode(),
                     oddCur = oddDummy,
                     evenDummy = new ListNode(),
                     evenCur = evenDummy;
            int i = 1;

            while (head != null)
                if (i++ % 2 != 0)
                {
                    oddCur = head;
                    head = head.next;
                    oddCur.next = null;
                    
                }
                else
                {
                    evenCur.next = head;
                    evenCur = evenCur.next;
                    head = head.next;
                    evenCur.next = null;
                }

            oddCur.next = evenDummy.next;

            return oddDummy.next;
        }

        public void Driver()
        {
            var inputVal1 = new ListNode(1, new ListNode(2,
                                new ListNode(3, new ListNode(4))
                            ));
            var retVal = solve(inputVal1);

            
            var inputVal2 = new ListNode(1, new ListNode(2,
                                new ListNode(3, new ListNode(4,
                                    new ListNode(5)))
                            ));
            retVal = solve(inputVal2);

            Console.WriteLine("OddEvenList");

        }
    }
}
