using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace leetCode.Easy
{
    internal class Anagram
    {
        /*
         * cases: anagram, nagaram (using all chars of string1 create a new word)
         * failed cases: [rat,car], [a, ab], [ab, a]
         * took too long
         */
        public bool isAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            while (s.Length > 0)
            {
                if (t.Length > 0)
                {
                    int removeItemIndex = t.IndexOf(s[0]);
                    if (removeItemIndex != -1)
                    {
                        t = t.Remove(removeItemIndex, 1);
                        s = s.Remove(0, 1);
                    }
                    else { break; } //1 - exit loop
                }
                else { break; }//3 exit loop
            }

            return (s.Length == 0 && t.Length == 0); //2 return
        }

        public bool isAnagramV2(string s, string t)
        {
            if (s.Length != t.Length) return false;
            
            //sort the array
            s = String.Concat(s.OrderBy(x => x));
            t = String.Concat(t.OrderBy(x => x));

            int i ,j;
            i = j = 0;

            while (i < s.Length && j< t.Length)
            {
                if (s[i] != t[j]) return false;
                else { i++; j++;}
            }
            return true;
        }

        public bool isAnagramNeetCode(string s, string t)
        {

            if (s.Length != t.Length) return false; //Anagram and not palindrome

            Dictionary<char, int> sdict = new Dictionary<char, int>(s.Length);
            Dictionary<char, int> tdict = new Dictionary<char, int>(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                if (sdict.ContainsKey(s[i]))
                    sdict[s[i]] = 1 + sdict[s[i]];
                else
                    sdict.Add(s[i], 1);

                if (tdict.ContainsKey(t[i]))
                    tdict[t[i]] = 1 + tdict[t[i]];
                else
                    tdict.Add(t[i], 1);
                
            }

            foreach (var item in sdict.Keys)
            {
                if (!tdict.ContainsKey(item) || sdict[item] != tdict[item])
                    return false;
            }

            return true;
        }
    }
}
