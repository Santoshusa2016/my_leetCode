using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Daily
{
    /*
     * Ref: https://leetcode.com/problems/find-duplicate-file-in-system/
     * LeetCode: 609. Find Duplicate File in System 
     * Date: 09/18/2022
     * Test case:
     * Failed:
     * Time Complexity:
     * Space Complexity:
     */
    internal class FindDuplicate
    {
        IList<IList<string>> solve(string[] paths)
        {
            Dictionary<string, List<string>> dupslist = 
                new Dictionary<string, List<string>>();
            IList<IList<string>> uniqueFileList = new List<IList<string>>();

            for (int i = 0; i < paths.Length; i++)
            {
                string dirPath = paths[i];
                string[] files = dirPath.Split(" ");
                string folder = files[0];

                for (int j = 1; j < files.Length; j++)
                {
                    string key = files[j].Split(".")[1];
                    string dir = folder + "/" + files[j].Split("(")[0];
                    if (dupslist.ContainsKey(key))
                    {
                        var filesAdded = dupslist[key];
                        filesAdded.Add(dir);
                        dupslist[key] = filesAdded;
                    }
                    else
                    {
                        dupslist.Add(key, new List<string> { dir });
                    }                    
                }
            }

            foreach (var item in dupslist)
            {
                if(item.Value.Count>1)
                    uniqueFileList.Add(item.Value);
            }

            return uniqueFileList;

        }

        public void Driver()
        {
            var input = new string[] {@"root/a 1.txt(abcd) 2.txt(efsfgh)"
                ,"root/c 3.txt(abdfcd)"
                ,"root/c/d 4.txt(efggdfh)"};

            solve(input);
            Console.WriteLine("FindDuplicate");
        }
    }
}
