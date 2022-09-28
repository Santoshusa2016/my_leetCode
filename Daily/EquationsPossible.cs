using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace leetCode.Daily
{
    internal class EquationsPossible
    {
        static Func<int, int, bool> checkEquals = (a, b) => a == b;
        static Func<int, int, bool> checkNotEquals = (a, b) => a != b;
        bool solve(string[] equations)
        {
            int i = 0;
            int j = equations.Length - 1;
            Dictionary<char, int> dictVar = new Dictionary<char, int>();
            
            while (i<=j )
            {
                //step01: basic validations
                if (equations[i].Length != 4 || equations[j].Length != 4)
                    return false;

                //step02: check if char variable exist in dict? If not assign value
                AddItems(equations, i, dictVar);
                AddItems(equations, j, dictVar);

                //step03: evaluate expression
                if (ValidateCondition(equations, i, dictVar) == false)
                    return false;

                if (ValidateCondition(equations, j, dictVar) == false)
                    return false;

                i++; j--;
            }
            return true ;
        }

        private static bool ValidateCondition(string[] equations, int i, Dictionary<char, int> dictVar)
        {
            char lkey = equations[i][0];
            char rkey = equations[i][3];
            bool isValid = false;

            if (equations[i].Contains("=="))
                isValid = checkEquals(dictVar[lkey], dictVar[rkey]);
            else
                isValid = checkNotEquals(dictVar[lkey], dictVar[rkey]);

            return isValid;
        }

        private static void AddItems(string[] equations, int i, Dictionary<char, int> dictVar)
        {
            if (!dictVar.ContainsKey(equations[i][0]))
            {
                dictVar.Add(equations[i][0], 1);
            }
            if (!dictVar.ContainsKey(equations[i][3]))
            {
                dictVar.Add(equations[i][3], 1);
            }
        }


        public void Driver()
        {
            string[] inputVal = new string[] { "c==c", "b==d", "x!=z" };
            bool retVal = solve(inputVal);

            Console.WriteLine("EquationsPossible:{0}", retVal);
        }
    }
}
