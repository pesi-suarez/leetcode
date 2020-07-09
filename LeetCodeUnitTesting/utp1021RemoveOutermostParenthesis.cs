using p1021RemoveOutermostParenthesis;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp1021RemoveOutermostParenthesis
    {
        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.Equal("()()()", solution.RemoveOuterParentheses("(()())(())"));
            Assert.Equal("()()()()(())", solution.RemoveOuterParentheses("(()())(())(()(()))"));
            Assert.Equal(string.Empty, solution.RemoveOuterParentheses("()"));
        }
    }
}
