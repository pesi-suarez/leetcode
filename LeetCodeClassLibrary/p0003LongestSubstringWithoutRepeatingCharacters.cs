using System;
using System.Collections.Generic;
using System.Linq;

namespace p0003LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        //Creo que esto no funciona porque no hay manera de generar correctamente c y d de forma lineal.
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;
            if (s.Length == 1)
                return 1;
            int a = LengthOfLongestSubstring(s.Substring(0, s.Length / 2));
            int b = LengthOfLongestSubstring(s.Substring(s.Length / 2));
            int c = LengthOfLongestCentralSubstring(s);
            int d = LengthOfLongestCentralSubstring(Reverse(s));
            List<int> data = new List<int> { a, b, c, d };
            return data.Max();
        }

        private int LengthOfLongestCentralSubstring(string s)
        {
            int substringLength = 0;
            bool leftBound = false;
            bool rightBound = false;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < s.Length/2+1; i++)
            {
                if (!leftBound && s.Length / 2 - i - 1 >= 0)
                {
                    if (dict.ContainsKey(s[s.Length / 2 - i - 1]))
                        leftBound = true;
                    else
                    {
                        substringLength++;
                        dict.Add(s[s.Length / 2 - i - 1], 0);
                    }
                        
                }
 
            }
            for (int i = 0; i < s.Length / 2 + 1; i++)
            {
                if (!rightBound && s.Length / 2 + i < s.Length)
                {
                    if (dict.ContainsKey(s[s.Length / 2 + i]))
                        rightBound = true;
                    else
                    {
                        substringLength++;
                        dict.Add(s[s.Length / 2 + i], 0);
                    }

                }
            }
            return substringLength;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        //O(n2) solution
        /*
        public int LengthOfLongestSubstring(string s)
        {
            int maxSubstringLength = 0;
            for (int i = 0; i < s.Length; i++)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                int currentSubstringLength = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (dict.ContainsKey(s[j]))
                    {
                        break;
                    }
                    dict.Add(s[j], j);
                    currentSubstringLength++;
                    maxSubstringLength = currentSubstringLength > maxSubstringLength ? currentSubstringLength : maxSubstringLength;
                }
            }
            return maxSubstringLength;
        }
        */
    }
}
