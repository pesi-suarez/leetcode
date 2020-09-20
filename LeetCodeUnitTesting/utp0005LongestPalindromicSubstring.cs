using p0005LongestPalindromicSubstring;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0005LongestPalindromicSubstring
    {
        [Fact]
        public void DescriptiopnTests()
        {
            Solution solution = new Solution();
            Assert.Equal("bab", solution.LongestPalindrome("babad"));
            Assert.Equal("bb", solution.LongestPalindrome("cbbd"));
        }

        [Fact]
        public void SubmissionTests()
        {
            Solution solution = new Solution();
            Assert.Equal("a", solution.LongestPalindrome("a"));
            Assert.Equal("ccc", solution.LongestPalindrome("ccc"));
            Assert.Equal("aaaa", solution.LongestPalindrome("aaaa"));
            Assert.Equal("bb", solution.LongestPalindrome("abb"));
        }
    }
}
