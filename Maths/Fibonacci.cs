using System;
using System.Collections.Generic;
using System.Text;

namespace leetCode.Maths
{
    internal class Fibonacci
    {
        //find nth fibonacci term
        public int Recursive(int n)
        {
            //top-down
            //base criteria
            if (n <= 1) return n;
            return Recursive(n - 1) + Recursive(n - 2);
        }

        public int Iterative(int n)
        {
            //bottom-up Dynammic Programming
            int f0 = 0;
            int f1 = 1;
            for (int i = 2; i <= n; i++)
            {
                var val = f1 + f0;
                f0 = f1;
                f1 = val;
            }
            return f1;
        }
    }
}
