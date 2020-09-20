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
            int limit = i < s.Length / 2 ? i + 1 : s.Length-i-1;
            //center of odd-length string
            if (i == s.Length - i - 1)
                limit--;
            for (int j = 0; j < limit; j++)
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
            int limit = i < s.Length / 2 ? i : s.Length-i-1;
            for (int j = 0; j < limit; j++)
            {
                if (s[i - j - 1] == s[i + j + 1])
                    palindrome = s[i - j - 1] + palindrome + s[i + j + 1];
                else break;
            }
            return palindrome;
        }
    }
}
