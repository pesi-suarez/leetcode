using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p709ToLowerCase;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp0709ToLowerCase
    {
        [TestMethod]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.AreEqual("hello", solution.ToLowerCase("Hello"));
            Assert.AreEqual("here", solution.ToLowerCase("here"));
            Assert.AreEqual("lovely", solution.ToLowerCase("LOVELY"));
        }
    }
}
