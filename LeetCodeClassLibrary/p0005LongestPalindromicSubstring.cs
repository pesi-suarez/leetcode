namespace p0005LongestPalindromicSubstring
{
    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            string longestPalindrome = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                string evenPalindrome = GenerateEvenPalindrome(s, i);
                string oddPalindrome = GenerateOddPalindrome(s, i);
                string candidatePalindrome = evenPalindrome.Length > oddPalindrome.Length ? evenPalindrome : oddPalindrome;
                longestPalindrome = candidatePalindrome.Length > longestPalindrome.Length ? candidatePalindrome : longestPalindrome;
            }
            return longestPalindrome;
        }

        private string GenerateEvenPalindrome(string s, int i)
        {
            if (i == s.Length - 1)
                return string.Empty;
            string palindrome = string.Empty;
            for (int j = 0; i-j >= 0 && i+j+1 < s.Length; j++)
            {
                if (s[i - j] == s[i + j + 1])
                    palindrome = s[i - j] + palindrome + s[i + j + 1];
                else break;
            }
            return palindrome;
        }

        private string GenerateOddPalindrome(string s, int i)
        {
            if (i == s.Length - 1)
                return s[i].ToString();
            string palindrome = s[i].ToString();
            for (int j = 0; i-j-1 >= 0 && i+j+1 < s.Length; j++)
            {
                if (s[i - j - 1] == s[i + j + 1])
                    palindrome = s[i - j - 1] + palindrome + s[i + j + 1];
                else break;
            }
            return palindrome;
        }

    }
}
