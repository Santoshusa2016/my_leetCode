using leetCode.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Medium
{
    /*
    * Ref: https://leetcode.com/problems/reorder-list/
    * LeetCode:143. Reorder List
    * Tag: #medium #linkedlist
    * Company:
    * Date: 11/15/2022
    * Test case:
    * Time Complexity: 
    * Space Complexity:
    */

    internal class ReorderList
    {
        ListNode solve(ListNode head)
        {
            int i, j;
            i = j = 0;
            ListNode tempNode = head;
            Stack<int> nodeStack = new Stack<int>();
            while (tempNode != null)
            {
                j++;
                nodeStack.Push(tempNode.val);
                tempNode = tempNode.next;
            }





            tempNode = head;
            ListNode newNode = new ListNode(0, null);

            for (i = 0; i <= j/2; i++)
            {
                //left pointer
                newNode.next = tempNode;
                tempNode = tempNode.next;
                newNode = newNode.next;

                newNode.next = new ListNode(nodeStack.Pop());
                newNode = newNode.next;
            }
            newNode = null;

            return head;
        }

        public void Driver()
        {
            //var inputVal1 = new ListNode(1, new ListNode(2,
            //                    new ListNode(3, new ListNode(4))
            //                ));

            var inputVal1 = new ListNode(1, new ListNode(2,
                                new ListNode(3, new ListNode(4,
                                    new ListNode(5)))
                            ));

            solve(inputVal1);
            Console.WriteLine("ReorderList");
        }
    }
}
