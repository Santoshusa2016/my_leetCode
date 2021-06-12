using System;

namespace leetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //callHouseRobber();
            //callTwoSums();
            //callReverseLl();
            callLenOfSubArray();

            Console.ReadKey();
            
        }

        public static void callHouseRobber(){
            SticklerThief prb = new SticklerThief();
            Console.WriteLine(prb.FindMaxSum(new int[]{ 2,1,1,2 }, 4));
        }

        public static void callTwoSums(){
            TwoSum prb = new TwoSum();
            Console.WriteLine(prb.FindTargetWithHash(new int[]{ 3,2, 4}, 6));
        }

        public static void callLenOfSubArray(){
            LengthOfLongestSubstring prb = new LengthOfLongestSubstring();
            Console.WriteLine(prb.GetLongestSubstringLen("dvdf"));
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
    }
}

