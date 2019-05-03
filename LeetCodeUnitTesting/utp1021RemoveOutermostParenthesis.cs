using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p1021RemoveOutermostParenthesis;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp1021RemoveOutermostParenthesis
    {
        [TestMethod]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.AreEqual("()()()", solution.RemoveOuterParentheses("(()())(())"));
            Assert.AreEqual("()()()()(())", solution.RemoveOuterParentheses("(()())(())(()(()))"));
            Assert.AreEqual(string.Empty, solution.RemoveOuterParentheses("()"));
        }
    }
}
