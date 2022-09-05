using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    internal class NaryLevelOrderTra
    {
        public IList<IList<int>> LevelOrder(Node root)
        {
            //base criteria
            if (root == null) return new List<IList<int>>();

            //step 01: BFS Add the root element to queue
            Queue level = new Queue();
            level.Enqueue(root);
            List<IList<int>> ans = new List<IList<int>>();


            //step 02: explore all items in queue
            while (level.Count>0)
            {
                //step 03: find number of elements in each level
                int noOfNodes = level.Count;
                List<int> levels = new List<int>();
                for (int i = 0; i < noOfNodes; i++)
                {
                    //step 04: takeout each element in queue
                    Node element = (Node)level.Dequeue();
                    if (element.children != null)
                    {
                        foreach (var item in element.children)
                        {
                            level.Enqueue(item);
                        }                        
                    }

                    //step 05: at end of each node exploration add item to list
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
