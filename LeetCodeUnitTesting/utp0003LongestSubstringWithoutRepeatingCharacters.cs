using p0003LongestSubstringWithoutRepeatingCharacters;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0003LongestSubstringWithoutRepeatingCharacters
    {
        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.Equal(3, solution.LengthOfLongestSubstring("abcabcbb"));
            Assert.Equal(1, solution.LengthOfLongestSubstring("bbbbb"));
            Assert.Equal(3, solution.LengthOfLongestSubstring("pwwkew"));
            Assert.Equal(0, solution.LengthOfLongestSubstring(""));
        }
    }
}
