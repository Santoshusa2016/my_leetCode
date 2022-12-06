using leetCode.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/middle-of-the-linked-list/
    * LeetCode:876. Middle of the Linked List
    * Tag: #easy, #slow-fast pointer
    * Company:
    * Date: 12/05/2022
    * Time Complexity: 0(N)
    * Space Complexity:O(1)
    */

    internal class MiddleNode
    {
        ListNode solve(ListNode head)
        {
            if (head == null)
                return null;
            var slowPointer = head;
            var fastPointer = head;
            while (fastPointer != null && fastPointer.next != null)
            {
                slowPointer = slowPointer.next;
                fastPointer = fastPointer.next.next;
            }
            return slowPointer;
        }

        void Driver()
        {

        }
    }
}
