using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Examples
{
    internal class ReverseArray
    {
        public static int __(int x, int y) { return x; }

        public static void reverseArray(int[] arr,
                                    int n)
        {
            for (int i = 0; i < n / 2; i++)
                arr[i] = __(arr[n - i - 1],
                            arr[n - i - 1] = arr[i]);
        }

        /* Utility function to print an array */
        public static void printArray(int[] arr,
                                    int size)
        {
            for (int i = 0; i < size; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }

        // Driver code
        public void Main()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            int n = arr.Length;
            printArray(arr, n);
            reverseArray(arr, n);
            Console.WriteLine("Reversed array is");
            printArray(arr, n);
        }

    }
}
