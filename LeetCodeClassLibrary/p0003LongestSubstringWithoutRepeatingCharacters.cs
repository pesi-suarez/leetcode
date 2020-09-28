using System.Collections.Generic;

namespace p0003LongestSubstringWithoutRepeatingCharacters
{
    public class Solution
    {
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
    }
}
