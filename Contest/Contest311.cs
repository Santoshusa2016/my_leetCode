using System;
using System.Collections.Generic;
using System.Text;
using static leetCode.Daily.Tree2str;

namespace leetCode.Contest
{
    internal class Contest311
    {
        public int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 0)
            {
                return n;
            }
            else
            {
                return n * 2;
            }
        }

        int LongestContinuousSubstring(string s)
        {
            int tempMax, max, i;
            max = i = 0;
            tempMax = 1;
            if (s.Length == 1)
                max = tempMax;
            else
            {
                while (i < s.Length - 1)
                {
                    if ((s[i + 1] - s[i]) == 1)
                    {
                        tempMax++;
                    }
                    else
                    {
                        tempMax = 1;
                    }
                    max = Math.Max(tempMax, max);
                    i++;
                }
            }
            return max;
        }

        void ReverseOddLevels(TreeNode root1, TreeNode root2, int index)
        {
            //step 01: base criteria
            if (root1 == null && root2 == null)
                return;

            //step 02: decison tree
            if(index%2 == 0)
            {
                //swap
                (root1.val, root2.val) = (root2.val, root1.val);
            }
               
            //step 03: swap parents (roo1=Isha,root2=Akash, root=Mukesh)
            ReverseOddLevels(root1.left, root2.right, index+1);
            ReverseOddLevels(root2.left, root1.right, index + 1);

        }

        public TreeNode ReverseOddLevels(TreeNode root)
        {
            //approach - BFS

            //queue here acts a pointer so we dont need to maintain pointer for items processed
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            bool odd = false;

            while (queue.Count > 0 && queue.Peek() != null)
            {
                List<TreeNode> list = new List<TreeNode>();

                //list is populated with nodes to be processed
                while (queue.Count > 0) list.Add(queue.Dequeue());
                if (odd)
                {
                    int i = 0, j = list.Count - 1;
                    while (i < j)
                    {
                        //two pointer one for left and another right. LR
                        int temp = list[i].val;
                        list[i++].val = list[j].val;
                        list[j--].val = temp;
                    }
                }

                foreach (TreeNode node in list)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                odd = !odd;
            }
            return root;
        }

        public void Driver()
        {
            //var retval = LongestContinuousSubstring("awy");



            var inputReq = new TreeNode(
                2
                , new TreeNode(3, new TreeNode(8, null, null), new TreeNode(13, null, null))
                , new TreeNode(5, new TreeNode(21, null, null) , new TreeNode(34, null, null))
                );

            var leftNode = new TreeNode(1,null,null);
            var rightNode = new TreeNode(2,null,null);
            var inputReq2 = new TreeNode(
                0
                , new TreeNode(1, new TreeNode(0, leftNode, leftNode), new TreeNode(0, leftNode, leftNode))
                , new TreeNode(2, new TreeNode(0, rightNode, rightNode), new TreeNode(0, rightNode, rightNode))
                );
            //ReverseOddLevels(inputReq.left,inputReq.right, 0);
            ReverseOddLevels(inputReq2);
        }
    }
}
