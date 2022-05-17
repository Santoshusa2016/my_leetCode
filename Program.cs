using System;
using System.Collections.Generic;
using leetCode.Easy;
using leetCode.Examples;

namespace leetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //callTwoSums();
            //callMaxProfit();
            //callContainsDuplicate();
            //callMaxSubArray();
            //callMajElement();
            //callIsAnagram();
            //callValidPalindrome();
            //callValidParantheses();
            //callReverseLinkedList();
            callMergeLinkedList();

            //callHouseRobber();
            //callReverseLl();
            //callLenOfSubArray();
            //callCombinationSums();
            //callProductExceptSelf();
            //callMaxProdArray();
            //callMinRotatedArray();
            //callContainerMax();
            //callLongestSubSeq();
            //callLongestCommonSubSeq();


            
            callApproaches();
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
        private static void callIsAnagram()
    {
        Anagram prob = new Anagram();
            //var response = prob.isAnagramV2("rat", "car")
        var response = prob.isAnagramNeetCode("rat", "car");
        Console.WriteLine(response);
    }

        private static void callMaxSubArray()
        {
            MaxSubArray prb = new MaxSubArray();
            Console.WriteLine(prb.GetMaxSubArrayDC(new int[]{-2,3,0,2,-2,3}));

        }

        public static void callMajElement(){
            int[] nbrs = { 2,1,2,3,2,4}; 
            var lstNbr = new List<int>();
            lstNbr.AddRange(nbrs);

            MajorityElement prb = new MajorityElement();
            Console.WriteLine(prb.majorityElement02(lstNbr));
        }

        private static void callValidPalindrome()
        {
            ValidPalindrome prob = new ValidPalindrome();
            var response = prob.IsPalindrome("race a car");
            Console.WriteLine(response);
        }
        private static void callValidParantheses()
        {
            ValidParentheses prob = new ValidParentheses();
            var response = prob.IsValid("){");
            Console.WriteLine(response);
        }

        private static void callReverseLinkedList()
        {
            reverseLinkedlist prob = new reverseLinkedlist(new int[] {1,2,3,4,5});
            var response = prob.ReverseList(new ListNode(1));
            Console.WriteLine(response);
        }

        private static void callMergeLinkedList()
        {
            MergeSortedList prob = new MergeSortedList();
            ListNode link1 = new ListNode(1,
                new ListNode(2, new ListNode(3,null)));
            ListNode link2 = new ListNode(1,
               new ListNode(3, new ListNode(4, null)));

            var response = prob.MergeTwoListsOpt(link1, link2);
            Console.WriteLine(response);
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

    private static void callMaxProdArray()
    {
        MaxProdArray prb = new MaxProdArray();
        Console.WriteLine(prb.GetMaxSubArrayKadens(new int[]{2,0,-1,8}));

    }

    private static void callMinRotatedArray()
    {
        MinimumRotatedArray prb = new MinimumRotatedArray();
        Console.WriteLine(prb.FindMin(new int[]{4,5,6,7,0,1,2}));
    }

    private static void callContainerMax()
    {
        containerMaxWater prb = new containerMaxWater();
        Console.WriteLine(prb.MaxArea(new int[]{1,8,6,2,5,4,8,3,7}));
    }

    private static void callLongestSubSeq()
    {
        LongestSubsequence prb = new LongestSubsequence();
        Console.WriteLine(prb.GetLongestSubsequence(new int[]{0,1,0,3,2,3}));
    }

    private static void callLongestCommonSubSeq()
    {
        LongestCommonSubseq prb = new LongestCommonSubseq();
        Console.WriteLine(prb.GetLongestCommonSubseq("stone","longest"));
    }
        #endregion


        #region Examples
        private static void callApproaches()
        {
            Approach prob = new Approach();
            int factorialBottomUp = prob.FactorialBottomUp(5) ;
            int factorialTopDown = prob.FactorialTopDown(5);

            Console.WriteLine("factorialBottomUp: "+ factorialBottomUp);
            Console.WriteLine("factorialBottomUp: " + factorialBottomUp);

        }
        #endregion
    }
}

