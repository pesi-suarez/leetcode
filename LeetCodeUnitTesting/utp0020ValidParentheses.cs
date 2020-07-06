using Microsoft.VisualStudio.TestTools.UnitTesting;
using p0020ValidParentheses;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp0020ValidParentheses
    {
        [TestMethod]
        public void CustomTests()
        {
            Solution solution = new Solution();

            Assert.IsTrue(solution.IsValid("()(()(()))"));
            Assert.IsFalse(solution.IsValid("(())())("));
            Assert.IsFalse(solution.IsValid("()(()(()))(("));
            Assert.IsFalse(solution.IsValid("()[]{}["));
        }

        [TestMethod]
        public void DescriptionTests()
        {
            Solution solution = new Solution();

            Assert.IsTrue(solution.IsValid("()"));
            Assert.IsTrue(solution.IsValid("()[]{}"));
            Assert.IsFalse(solution.IsValid("(]"));
            Assert.IsFalse(solution.IsValid("([)]"));
            Assert.IsTrue(solution.IsValid("{[]}"));
        }

    }
}
