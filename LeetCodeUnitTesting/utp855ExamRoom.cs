using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp855ExamRoom
    {
        [TestMethod]
        public void ArrayInitilizationZero()
        {
            int[] values = new int[10];
            for (int i = 0; i < values.Length; i++)
                Assert.AreEqual(0, values[i]);
        }
    }
}
