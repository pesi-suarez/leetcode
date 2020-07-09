using p0020ValidParentheses;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0020ValidParentheses
    {
        [Fact]
        public void CustomTests()
        {
            Solution solution = new Solution();

            Assert.True(solution.IsValid("()(()(()))"));
            Assert.False(solution.IsValid("(())())("));
            Assert.False(solution.IsValid("()(()(()))(("));
            Assert.False(solution.IsValid("()[]{}["));
        }

        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();

            Assert.True(solution.IsValid("()"));
            Assert.True(solution.IsValid("()[]{}"));
            Assert.False(solution.IsValid("(]"));
            Assert.False(solution.IsValid("([)]"));
            Assert.True(solution.IsValid("{[]}"));
        }

    }
}
