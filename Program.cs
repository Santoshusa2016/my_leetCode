using System;
using System.Collections.Generic;
using leetCode.Arrays;
using leetCode.Daily;
using leetCode.Easy;
using leetCode.Examples;
using leetCode.Examples.Maths;
using leetCode.Maths;
using leetCode.Medium;
using leetCode.Common;
using my_leetCode.Daily;
using my_leetCode.Contest;
using my_leetCode.Medium;
using my_leetCode.Sliding;
using my_leetCode.Arrays;
using my_leetCode.Dynammic;

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
            //callMergeLinkedList();
            //callInvertBTree();


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
            //callUniquePath();


            //callApproaches();
            //callPrintPrime();


            //callMinValue();
            //callNinjaCandies();


            //callNumsSameConsecDiff();
            
            
            callDailyChallenge();

            //callCodingContest();


            //callArraySolns();
            //callLinkedListSolns();

            Console.ReadKey();

        }


        #region Easy
        public static void callTwoSums()
        {
            TwoSum prb = new TwoSum();
            Console.WriteLine(prb.FindTargetWithHash(new int[] { 3, 2, 4 }, 6));
        }

        private static void callContainsDuplicate()
        {
            ContainsDuplicate dups = new ContainsDuplicate();
            Console.WriteLine(dups.hasDuplicate(new int[] { 1, 2, 3, 1 }));
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
            Console.WriteLine(prb.GetMaxSubArrayDC(new int[] { 8, -19, 5, -4, 20 }));

        }

        public static void callMajElement()
        {
            int[] nbrs = { 2, 1, 2, 3, 2, 4 };
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
            reverseLinkedlist prob = new reverseLinkedlist(new int[] { 1, 2, 3, 4, 5 });
            var response = prob.ReverseList(new ListNode(1));
            Console.WriteLine(response);
        }

        private static void callInvertBTree()
        {
            InvertBTree prob = new InvertBTree();
            TreeNode node = new TreeNode()
            {
                val = 4,
                left = new TreeNode(2, new TreeNode(1), new TreeNode(3)),
                right = new TreeNode(7, new TreeNode(6), new TreeNode(9))
            };
            var response = prob.Solution(node);
            Console.WriteLine(response);
        }

        private static void callFindPair()
        {
            int[] a = { 1, -2, 1, 0, 5 };
            int z = 0;
            int n = a.Length;
            findPair prob = new findPair();
            var response = prob.Solve(a, n, z);
            Console.WriteLine(response);
        }

        private static void callCountFreq()
        {
            int[] arr = new int[] { 10, 20, 20, 10, 10, 20, 5, 20 };
            int n = arr.Length;
            countFreq prob = new countFreq();
            prob.solveV1(arr, n);
        }

        #endregion

        #region Medium
        public static void callHouseRobber()
        {
            SticklerThief prb = new SticklerThief();
            Console.WriteLine(prb.FindMaxSum(new int[] { 2, 1, 1, 2 }, 4));
        }

        public static void callLenOfSubArray()
        {
            LengthOfLongestSubstring prb = new LengthOfLongestSubstring();
            Console.WriteLine(prb.GetLongestSubstringLen("dvdf"));
        }

        public static void callCombinationSums()
        {
            CombinationSum prb = new CombinationSum();
            var retval = prb.FindCombination(new int[] { 2, 7, 6, 3, 5, 1 }, 9);
            Console.ReadKey();
        }

        private static void callMaxProdArray()
        {
            MaxProdArray prb = new MaxProdArray();
            Console.WriteLine(prb.GetMaxProduct(new int[] { 2, 0, -1, 8 }));
        }

        private static void callMinRotatedArray()
        {
            MinimumRotatedArray prb = new MinimumRotatedArray();
            Console.WriteLine(prb.FindMinWithBS(new int[] { 4, 5, 6, 7, 0, 1, 2 }));
        }

        private static void callContainerMax()
        {
            containerMaxWater prb = new containerMaxWater();
            Console.WriteLine(prb.MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
        }

        private static void callLongestSubSeq()
        {
            LongestIncreasingSeq prb = new LongestIncreasingSeq();
            Console.WriteLine(prb.LIS(new int[] { 0, 1, 0, 3, 2, 3 }));
        }

        private static void callUniquePath()
        {
            //(3,2) , (3,7,)
            uniquePaths prb = new uniquePaths();
            Console.WriteLine(prb.Solve(3, 2));
        }
        #endregion

        #region Maths
        private static void callPrintPrime()
        {
            PrimeNumber prob = new PrimeNumber();
            prob.Run(new string[] { "Santosh" });
        }

        private static void callApproaches()
        {
            Factorial prob = new Factorial();
            int factorialBottomUp = prob.FactorialBottomUp(5);
            int factorialTopDown = prob.FactorialTopDown(5);

            Console.WriteLine("factorialBottomUp: " + factorialBottomUp);
            Console.WriteLine("factorialBottomUp: " + factorialBottomUp);

        }
        #endregion

        #region codingNinjas
        private static void callMinValue()
        {
            MinValue prb = new MinValue();
            var retVal = prb.Solve(1, 1) ?? 0;
            Console.WriteLine("the retVal is: " + retVal);
        }

        private static void callNinjaCandies()
        {
            NinjaCandies prb = new NinjaCandies();
            var retVal = prb.Solve(new int[] { 1, 2 }, 2, 3);
            Console.WriteLine("the retVal is: " + retVal);
        }

        #endregion

        #region daily challenge
        private static void callNumsSameConsecDiff()
        {
            NumsSameConsecDiff prb = new NumsSameConsecDiff();
            prb.Driver(2, 1);
        }

        private static void callNaryLevelOrderTraversal()
        {
            NaryLevelOrderTrav prb = new NaryLevelOrderTrav();

            NaryLevelOrderTrav.Node parentNode = new NaryLevelOrderTrav.Node();
            parentNode.val = 1;
            var level1Node = new NaryLevelOrderTrav.Node();

        }

        private static void callDailyChallenge()
        {
            //PruneTree prb = new PruneTree();
            //NumberOfWeakCharacters prb = new NumberOfWeakCharacters();
            //var prb = new Motorola();
            //var prb = new BagOfTokensScore();
            //var prb = new ValidUtf8();
            //var prb = new PseudoPalindromicPaths();
            //var prb = new FindOriginalArray();
            //var prb = new MaximumScore();
            //var prb = new PalindromePairs();
            //var prb = new FindLength();
            //var prb = new FindDuplicate();
            //var prb = new SumEvenAfterQueries();
            //var prb = new ReverseWords();
            //var prb = new ConcatenatedBinary();
            //var prb = new EquationsPossible();
            //var prb = new PushDominoes();
            //var prb = new FindClosestElements();
            //var prb = new NumDecodings();
            //var prb = new MinCost();
            //var prb = new GetSkyline();
            //var prb = new HasPathSum();
            //var prb = new TimeMap();
            //var prb = new MyCalendarThree();
            //var prb = new BreakPalindrome();
            //var prb = new LargestPerimeter();
            //var prb = new CheckIfPangram();
            //var prb = new MinDifficulty();
            //var prb = new CountAndSay();
            //var prb = new ContainsNearbyDuplicate();
            //var prb = new IntToRoman();
            //var prb = new CheckSubarraySum();
            //var prb = new FindBall();
            //var prb = new MinMutation();
            //var prb = new Maximum69Number();
            //var prb = new MakeGreatString();
            //var prb = new StockSpanner();
            //var prb = new RemoveDuplicates();
            //var prb = new Calculate();
            //var prb = new NearestExit();
            //var prb = new OddEvenList();
            //var prb = new MaxProduct();
            //var prb = new NumTilings();
            //var prb = new CanJump();
            //var prb = new MaximumBags();
            //var prb = new DetectCapitalUse();

            var prb = new MaxPoints();
            prb.Driver();
        }
        #endregion

        #region coding contest
        private static void callCodingContest()
        {
            //var prb = new Contest311();
            //var prb = new Contest312();
            //var prb = new Contest315();

            var prb = new Contest319();
            prb.Driver();
        }
        #endregion

        #region array
        static void callArraySolns()
        {
            var prb = new LongestConsecutive();
            //var prb = new GroupAnagrams();
            prb.Driver();
        }
        #endregion

        #region LinkedList
        static void callLinkedListSolns()
        {
            //var prb = new LongestConsecutive();
            //var prb = new MergeTwoLists();
            //var prb = new DeleteNode();
            //var prb = new DeleteMiddle();
            var prb = new ReorderList();
            prb.Driver();
        }
        #endregion

    }
}

