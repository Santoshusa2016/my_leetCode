using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_leetCode.Daily
{
    internal class MakeGreatString
    {
        public string MakeGood(string s)
        {
            int i = 1;
            Stack<char> stackChars = new Stack<char>();
            stackChars.Push(s[0]);

            while (i < s.Length)
            {
                int diff = 0;
                if (stackChars.Count > 0)
                    diff = ((int)s[i] - (int)stackChars.Peek());

                if (Math.Abs(diff) != 32)
                    stackChars.Push(s[i]);
                else
                    stackChars.Pop();
                i++;
            }
            return string.Concat(stackChars.Reverse());
        }

        public void Driver()
        {
            string inputReq = "abBAcC";
            string retVal = MakeGood(inputReq);
            Console.WriteLine("MakeGreatString:" + retVal);
        }
    }
}
