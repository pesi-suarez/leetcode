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

        [Fact]
        public void SubmissionTests()
        {
            Solution solution = new Solution();
            Assert.Equal(8, solution.LengthOfLongestSubstring("pmukfzdskwdyne"));
            Assert.Equal(11, solution.LengthOfLongestSubstring("bziuwnklhqzrxnb"));
            /*
             * Se repiten B, Z y N
             * El substring más largo es iuwnklhqzrx, efectivamente de longitud 11.
             * B Z I U W N K L H Q Z R X N B
             * 
             * Traza:
             * B Z I U W N [K] L H Q Z R X N B | K
             * B Z I U W [N] K L H Q Z R X N B | K, N
             * B Z I U [W] N K L H Q Z R X N B | K, N, W
             * ...
             * [B] Z I U W N K L H Q Z R X N B | K, N, W, U, I, Z, B
             * B Z I U W N K [L] H Q Z R X N B | K, N, W, U, I, Z, B, L
             * B Z I U W N K L [H] Q Z R X N B | K, N, W, U, I, Z, B, L, H
             * B Z I U W N K L H [Q] Z R X N B | K, N, W, U, I, Z, B, L, H, Q
             * B Z I U W N K L H Q [Z] R X N B | K, N, W, U, I, Z, B, L, H, Q Boundright
             */
        }
    }
}
