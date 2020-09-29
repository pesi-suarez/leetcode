using System;
using System.Collections.Generic;

namespace p0003LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
        //O(n) solution, based on https://bit.ly/3jfbRYu
        //j nunca puede volver hacia atrás, así nunca se considera un substring con una repetición anidada
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxLength = 0;
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (dict.ContainsKey(s[i]))
                {
                    j = Math.Max(j, dict[s[i]] + 1); 
                    dict[s[i]] = i;
                }
                else
                    dict.Add(s[i], i);
                maxLength = Math.Max(maxLength, i - j + 1);
            }
            return maxLength;
        }

    }
}
