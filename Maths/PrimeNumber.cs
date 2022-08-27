using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Examples.Maths
{
    internal class PrimeNumber
    {
        /*
        App 01: iterate from 2 to n-1
        App 02: i < n/2. if i is greater than n/2 we cannot divide
        App 03: i <= sqRoot(N). The idea is to find the lowest divisor in the pair for N.
        Time complexity: O(nRootn)
        */
        bool isPrimeV1(int n)
        {
            //since 0 and 1 is not prime return false.
            if (n == 1 || n == 0) return false;

            for (int i = 2; i <= Math.Floor(Math.Sqrt(n)); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        //Most numbers are divisible by 2/3 so take that case out and start from 5 nd increment by 6
        bool isPrimeV2(int n)
        {
            if (n == 1 || n == 0 || n == 2 || n == 3) return false;

            if (n % 2 == 0 || n % 3 == 0) return false;
            Console.Write("SqRoot: {0}", Math.Floor(Math.Sqrt(n)));

            for (int i = 5; i <= Math.Floor(Math.Sqrt(n)); i = i + 6)
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
            }
            return true;
        }


        /*
         * Sieve of Eratosthenes
         * Time complexity: O(nloglogn)
         * aux space complexity: O(n)
        */
        public static void simpleSieve(int n)
        {
            /* https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes */

            bool[] isPrime = new bool[n + 1];
            Array.Fill(isPrime, true);

            //generate all prime less than sqRoot of N. sq(greater num) will be >n
            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p] == true)
                {
                    //mark all divisor of prime as composite
                    for (int i = p * p; i <= n; i += p)
                        isPrime[i] = false;
                }
            }

            // Print all isPrime numbers
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i] == true)
                    Console.Write(i + " ");
            }
        }


        public static void sieve(int n, ref ArrayList prime)
        {
            bool[] isPrime = new bool[n + 1];
            Array.Fill(isPrime, true);

            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p] == true)
                {
                    prime.Add(p);
                    //mark all divisor of prime as composite
                    for (int i = p * p; i <= n; i += p)
                        isPrime[i] = false;
                }
            }
        }

        /*
         * Time complexity: 
         * aux space complexity:
        */
        void segmentedSieve(int n)
        {
            //step 01: create a segment
            int limit = (int)(Math.Floor(Math.Sqrt(n)));
            ArrayList primeArray = new ArrayList();

            //step 02: generate prime within segment
            sieve(limit, ref primeArray);

            //create segments
            int low = limit + 1;
            int high = 2 * limit;

            while (low < n)
            {
                if (high > n)
                    high = n;

                Console.WriteLine("low:{0}, high:{1}", low, high);

                //step 03: create a dummy array based on segment
                bool[] mark = new bool[limit];
                for (int i = 0; i < mark.Length; i++)
                    mark[i] = true;

                //Step 04: Use the primes found using sieve() to find mutiples/prime in current range
                for (int i = 0; i < primeArray.Count; i++)
                {
                    int k = (int)primeArray[i];
                    var multiple = (double)(low / k);
                    int loLim = (int)Math.Floor(multiple) * k;
                                        
                    Console.WriteLine("multiple:{0}, loLim:{1}", multiple, loLim);

                    if (loLim < low)
                        loLim += k;

                    for (int j = loLim; j <= high; j += k)
                    {
                        int index = j-low;
                        mark[index] = false;
                    }
                }

                // Numbers which are not marked as false are prime
                for (int i = low; i <= high; i++)
                { 
                    if (mark[i - low] == true)
                    { 
                        Console.Write(i + " ");
                        primeArray.Add(i);
                    }
                }
                low = low + limit;
                high = high + limit;
            }
        }


        // Driver code
        public void Run(string[] args)
        {
            int N = 100; //121,1031
            segmentedSieve(N);
        }
    }
}
