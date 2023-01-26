using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static leetCode.Daily.NaryLevelOrderTrav;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/number-of-_nodes-in-the-sub-tree-with-the-same-label/description/
    * LeetCode:149. Max Points on a Line
    * Tag: #hard, #adjacency, #dfs, #postorder, #graph
    * Company:
    * Date: 01/12/2023
    * Time Complexity:O(26*n), 0(n)
    * Space Complexity:O(n)-adjacency list
    */
    internal class CountSubTrees
    {
        private Dictionary<int, List<int>> _adj;
        private int[] _nodeCounts = new int[26];

        public CountSubTrees()
        {
            //intialize adjacency list
            _adj = new Dictionary<int, List<int>>();
        }
        public int[] solve(int n, int[][] edges, string labels)
        {
            int[] ans = new int[n];
            var addIfNotExist = new Action<int, int>((t1, t2) =>
            {
                if (_adj.ContainsKey(t1))
                    _adj[t1].Add(t2);
                else
                    _adj.Add(t1, new List<int> { t2 });
            });

            for (int i = 0; i < n - 1; i++)
            {
                var kv = edges[i];
                //created undirected graph
                addIfNotExist(kv[0], kv[1]);
                addIfNotExist(kv[1], kv[0]);
            }

            //dfs(0, -1, _nodes, labels, ans);
            dfsv1(0, -1, labels, ans);

            return ans;
        }

        int[] dfs(int node, int parent, Dictionary<int, List<int>> _nodes
            , string labels, int[] ans)
        {
            int[] nodeCounts = new int[26];
            nodeCounts[labels[node] - 'a'] = 1; //mylabel

            for (int i = 0; i < _nodes[node].Count; i++)
            {
                var child = _nodes[node][i];
                //dont reverse process the node.
                if (child == parent)
                    continue;

                int[] childCounts = dfs(child, node, _nodes, labels, ans);

                // Add frequencies of the child node in the parent node's frequency array.
                for (int j = 0; j < 26; j++)
                {
                    nodeCounts[j] += childCounts[j];
                }
            }

            ans[node] = nodeCounts[labels[node] - 'a'];//updated index value
            return nodeCounts;
        }

        void dfsv1(int node, int parent, string label, int[] ans)
        {
            int charIndex = label[node] - 'a';
            int prevCount = _nodeCounts[charIndex];
            _nodeCounts[charIndex] += 1;

            for (int i = 0; i < _adj[node].Count; i++)
            {
                var child = _adj[node][i];

                //parent & child already processed.
                if (child == parent)
                    continue;

                dfsv1(child, node, label, ans);
            }

            //the golden formula is to store prevcount and subtract with current to get curr val.
            ans[node] = _nodeCounts[charIndex] - prevCount;
        }

        public void Driver()
        {
            /*var retVal = solve(5,
                new int[4][] {
                new int[]{0, 1},
                new int[]{0, 2},
                new int[]{1, 3},
                new int[]{0, 4},
                }, "aabab");*/

            var retVal = solve(7,
                new int[6][] {
                new int[]{0, 1},
                new int[]{0, 2},
                new int[]{1, 4},
                new int[]{1, 5},
                new int[]{2, 3},
                new int[]{2, 6},
                }, "abaedcd");

            //[0,1],[1,2],[2,3],[3,4],[4,5],[5,6], "aaabaaa"
            //[[0,2],[0,3],[1,2]] , "aeed"
            Console.WriteLine($"CountSubTrees:{retVal.Length}");
        }
    }
}
