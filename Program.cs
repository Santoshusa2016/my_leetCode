using System;

namespace leetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find maximum sum of non consecutive elements in array
            /*
            {5, 5, 10, 40, 50, 35}

            */
            SticklerThief prb = new SticklerThief();
            Console.WriteLine(prb.FindMaxSum(new int[]{ 2,1,1,2 }, 4));
   
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

            Console.ReadKey();
            
        }
    }
}

