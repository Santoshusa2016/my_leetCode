using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    internal class PushDominoes
    {
        /*
         * Ref: https://leetcode.com/problems/push-dominoes/
         * LeetCode: 838. Push Dominoes
         * Date: 09/27/2022
         * Test case:"RR.L", ".L.R...LR..L.."
         * Failed: ".L.R."
         * Hint: 
         * Time Complexity:
         * Space Complexity:
         */
        string solve(string dominoes)
        {
            //step01: convert string to list, so that we can update the values
            List<char> doms = dominoes.ToList();
            Queue<int> domsQueue = new Queue<int>();
            for (int i = 0; i < doms.Count; i++)
            {
                if (doms[i] != '.')
                {
                    //step02: Add all non standing items to queue
                    domsQueue.Enqueue(i);
                }
            }

            //step03: process items in queue by tilting them. Each iteration represent 1 sec
            while (domsQueue.Count>0)
            {
                int index = domsQueue.Dequeue();
                //check boundary condition. LEFT min is 0
                if (index > 0 && doms[index] == 'L')
                {
                    if (doms[index-1] == '.')
                    {
                        doms[index - 1] = 'L'; //push dominoes to left
                        domsQueue.Enqueue(index - 1);
                    }
                }
                else if (index+1 < doms.Count 
                    && doms[index] == 'R')
                {
                    if(doms[index + 1] == '.')
                    {
                        //step04: process items in queue
                        if ((index + 2)< doms.Count && doms[index + 2] == 'L')
                        {
                            domsQueue.Dequeue();
                        }
                        else
                        {
                            doms[index + 1] = 'R'; //push dominoes to right
                            domsQueue.Enqueue(index + 1);
                        }
                    }
                }
            }

            return string.Concat(doms);
        }


        public void Driver()
        {
            string inputVal = ".L.R.";
            string retVal = solve(inputVal);
            Console.WriteLine("PushDominoes");
        }
    }
}
