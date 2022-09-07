using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://practice.geeksforgeeks.org/problems/minimum-cost-to-cut-a-board-into-squares/1
     * LeetCode: 967
     * hint:
     * Date: 09/03/2022
     * Test case: [3,1] [2,0], [3,7]
     * Time Complexity: O(9*2^N)
     * Space Complexity: O(2^N)
     */

    internal class NaryLevelOrderTrav
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            //base criteria
            if (root == null) return new List<IList<int>>();

            //step 01: BFS Add the root element to queue
            Queue level = new Queue();
            level.Enqueue(root);
            List<IList<int>> ans = new List<IList<int>>();


            //step 02: check if any element exist in queue
            while (level.Count>0)
            {
                int noOfNodes = level.Count;
                List<int> levels = new List<int>();

                //step 03: start exploring each item in queue
                for (int i = 0; i < noOfNodes; i++)
                {                    
                    Node element = (Node)level.Dequeue();
                    if (element.children != null)
                    {
                        foreach (var item in element.children)
                        {
                            //step 04: add child nodes to queue
                            level.Enqueue(item);
                        }                        
                    }

                    //step 05: at end of each node exploration remove item from queue and add to list
                    levels.Add(element.val);
                }

                //step 06: at end of each level exploation add item to parent list
                ans.Add(levels);
            }

            return ans;
        }


        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }
    }

    
}
