using System;
using System.Collections.Generic;
using System.Text;

namespace my_leetCode.Daily
{
    /*
    * Ref: https://leetcode.com/problems/minimum-genetic-mutation/
    * LeetCode: 433. Minimum Genetic Mutation
    * Tag: #bfs, #medium, #simulation
    * Company:
    * Date: 11/02/2022
    * Test case:
    * Time Complexity: 
    * Space Complexity:
    */

    internal class MinMutation
    {
        int solve(string start, string end, string[] bank)
        {
            //step01: convert array to set, because checking item in set is easy
            HashSet<string> bankSet = new HashSet<string>(bank);

            //step02: exit if end gene is not valid
            if (bankSet.Contains(end) == false)
                return -1;


            //step03: create a queue & list for traversal
            //queue for BFS
            Queue<string> processQueue = new Queue<string>();
            processQueue.Enqueue(start);
            //dictionary to keep track of items already processed
            int numMutation = 0;
            Dictionary<string, int> visitedGeneSet = new Dictionary<string, int>();
            visitedGeneSet.Add(start, numMutation);

            while (processQueue.Count > 0)
            {
                string gene = processQueue.Dequeue();
                if (gene == end)
                    return visitedGeneSet[gene];

                numMutation++;
                
                for (int i = 0; i < gene.Length; i++)
                {
                    char[] chars = gene.ToCharArray();
                    foreach (char newChar in "ACGT")
                    {
                        chars[i] = newChar;
                        string new_gene = String.Join("", chars);
                        if (bankSet.Contains(new_gene)
                            && !visitedGeneSet.ContainsKey(new_gene))
                        {
                            processQueue.Enqueue(new_gene);
                            visitedGeneSet.Add(new_gene, numMutation);
                        }
                    }
                }
                
            }
            return -1;
        }

        public void Driver()
        {
            string startGene = "AAAACCCC";
            string endGene = "CCCCCCCC";
            string[] bank = new string[] { "AAAACCCA", "AAACCCCA", "AACCCCCA", "AACCCCCC", "ACCCCCCC", "CCCCCCCC", "AAACCCCC", "AACCCCCC" };
            int retVal = solve(startGene, endGene, bank);


            Console.WriteLine("MinMutation:{0}", retVal);
        }
    }
}
