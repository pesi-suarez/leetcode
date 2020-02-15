using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p754ReachANumber;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp0754ReachANumber
    {
        [TestMethod]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.AreEqual(2, solution.ReachNumber(3));
            Assert.AreEqual(3, solution.ReachNumber(2));
        }
    }
}
