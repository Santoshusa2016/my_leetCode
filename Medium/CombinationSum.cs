using System;
using System.Collections.Generic;
using System.Linq;

/*
Test Cases:
[2,3,6,7] - 7
[2,3,5] - 8 - Failed
[2,7,6,3,5,1] - 9
*/
public class CombinationSum {
    public IList<IList<int>> FindCombination(int[] candidates, int target) {

        var combinationlist = new List<IList<int>>();
        var templist = new List<int>();
        FindCombination(candidates, target,0, candidates.Length, templist, combinationlist);
        return combinationlist;
    }

    //Brute Force - Tuned for TempList storage
    public void FindCombination(int[] candidates, int target
    , int start, int end, List<int> tempStore, IList<IList<int>> uniquelist) {

    int tempSum = tempStore.Sum();
    for (int i = start; i < end; i++)
    {
        if(candidates[i]+tempSum == target) {
            /*Deep copy is created because if tempList changes the ref in main list changes
            The candidate is not added because adding it to temp will ref which is not req for next iteration
            */
           var deepCopy = new List<int>(); 
           tempStore.ForEach(a => deepCopy.Add(a));
           deepCopy.Add(candidates[i]);
           uniquelist.Add(deepCopy);
        }
        else{
            
            if(candidates[i] + tempSum < target)
            {
                tempStore.Add(candidates[i]); //Add item to stack and start exploration next - DFS
                PrintLog(tempStore, "Push");
                FindCombination(candidates, target, i, end, tempStore,uniquelist);
                tempStore.RemoveAt(tempStore.Count -1); //Remove item from Stack after exploration is completed
                PrintLog(tempStore, "Pop");

            }
        }        
    }   
}

    private void PrintLog(List<int> tempStore, string type)
    {
        foreach (var item in tempStore)
        {
            Console.WriteLine(type + ": " + item);
        }
    }

    //This Method failed because it does not check against itself
    public IList<IList<int>> FindCombination2(int[] candidates, int target) 
    {
        var uniqueComb = new List<IList<int>>();
       
        for (int i = 0; i < candidates.Length; i++)
        {
            var templist = new List<int>();
            int diff = target - candidates[i];
            if (diff > 0){                
                templist.Add(candidates[i]);
                for (int j = 0; j < candidates.Length; j++)
                {
                    if(candidates[j] <= diff){
                        templist.Add(candidates[j]);
                        diff = (diff - candidates[j]);
                    }
                }
                if(diff == 0){
                    uniqueComb.Add(templist);
                }
            }
            else if (diff == 0){
                uniqueComb.Add(new List<int>{candidates[i]});
            }
        }
        return uniqueComb;
    }
}