using Microsoft.VisualStudio.TestTools.UnitTesting;
using p42TrappingRainWater;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp42TrappingRainWater
    {
        [TestMethod]
        public void DescriptionTest()
        {
            Solution solution = new Solution();
            Assert.AreEqual(6, solution.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }

        [TestMethod]
        public void FailedTest0()
        {
            Solution solution = new Solution();
            Assert.AreEqual(0, solution.Trap(new int[] {  }));
        }

        [TestMethod]
        public void FailedTest1()
        {
            Solution solution = new Solution();
            Assert.AreEqual(2, solution.Trap(new int[] { 2, 0, 2}));
        }

        [TestMethod]
        public void SmallArray0()
        {
            Solution solution = new Solution();
            Assert.AreEqual(0, solution.Trap(new int[] { 4 }));
        }

        [TestMethod]
        public void SmallArray1()
        {
            Solution solution = new Solution();
            Assert.AreEqual(0, solution.Trap(new int[] { 4, 5 }));
        }
    }
}
