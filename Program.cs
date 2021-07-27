﻿using System;

namespace leetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //callTwoSums();
            //callMaxProfit();
            //callContainsDuplicate();

            //callHouseRobber();
            //callReverseLl();
            //callLenOfSubArray();
            //callCombinationSums();
            callProductExceptSelf();

            Console.ReadKey();
            
        }



        #region Easy
    public static void callTwoSums(){
        TwoSum prb = new TwoSum();
        Console.WriteLine(prb.FindTargetWithHash(new int[]{ 3,2, 4}, 6));
    }

    public static void callMaxProfit(){
        MaxProfit prb = new MaxProfit();
        Console.WriteLine(prb.GetMaxProfit(new int[]{7,6,4,3,1}));
    }

    private static void callContainsDuplicate()
    {
        ContainsDuplicate dups = new ContainsDuplicate();
        Console.WriteLine(dups.hasDuplicate(new int[]{1,2,3,1}));
    }
        
    #endregion 
    #region Medium
    public static void callHouseRobber(){
        SticklerThief prb = new SticklerThief();
        Console.WriteLine(prb.FindMaxSum(new int[]{ 2,1,1,2 }, 4));
    }

    public static void callLenOfSubArray(){
        LengthOfLongestSubstring prb = new LengthOfLongestSubstring();
        Console.WriteLine(prb.GetLongestSubstringLen("dvdf"));
    }

    public static void callCombinationSums(){
        CombinationSum prb = new CombinationSum();
        var retval = prb.FindCombination(new int[]{2,7,6,3,5,1}, 9);
        Console.ReadKey();
    }

    public static void callReverseLl(){
        //reverse linked list
        LinkedList llist = new LinkedList();
        llist.head = new LinkedList.Node(1);

        LinkedList.Node nodeA = new LinkedList.Node(2);
        llist.head.nextNode = nodeA;

        LinkedList.Node nodeB= new LinkedList.Node(3);
        nodeA.nextNode = nodeB;
        LinkedList.Node nodeC = new LinkedList.Node(4);
        nodeB.nextNode = nodeC;
        LinkedList.Node nodeD = new LinkedList.Node(5);
        nodeC.nextNode = nodeD;

        //llist.pointerReverse();
        llist.callrecurrenceReverse();
    }

    public static void callProductExceptSelf(){
        ProductExceptSelf prob = new ProductExceptSelf();
        prob.GetProductExceptSelf(new int[]{1,2,3,4});
    }
    #endregion        
    }
}

