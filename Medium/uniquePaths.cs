using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace leetCode.Medium
{
    /*
     * Hint: DFS.
     * Test cases: (3,2) (3,7)
     * Failed:(1,1)
     */
    internal class uniquePaths
    {
        //Driver
        public int Solve(int m, int n)
        {
            int[,] matrix = new int[m, n];
            //return Recurse(0, 0, matrix, m, n);

            return DP(m, n);
        }

        public int Recurse(int rowIndex
            , int colIndex, int[,] matrix , int m, int n)
        {
            //base condition
            if (rowIndex >= m || colIndex >= n)
                return 0;

            if (matrix[rowIndex, colIndex] != 0)
                return matrix[rowIndex, colIndex];

            if (rowIndex == m-1 && colIndex == n-1)
                return 1;


            //Decision Tree
            //go right: R2, C3
            int colVal = Recurse(rowIndex, colIndex + 1, matrix, m, n);

            //go down: R3, C2
            int rowVal = Recurse(rowIndex + 1, colIndex, matrix, m, n);

            matrix[rowIndex, colIndex] = matrix[rowIndex, colIndex] + colVal + rowVal;
            return matrix[rowIndex, colIndex];
        }

        //NeetCode
        public int DP(int m, int n)
        {
            int[,] matrix = new int[m, n];
            for (int i = (m-1); i >= 0; i--)
            {
                for (int j = (n-1); j >=0; j--)
                {
                    /*
                     * assuming there is only 1 way for last cell to reach itself update val=1
                     * the adjacent cells in last row, col also has only 1 way to reach the last cell
                    */
                    if (i == m-1 || j == n-1)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = matrix[i, j+1] + matrix[i+1, j];
                }
            }
            return matrix[0, 0];
        }
    }
}
