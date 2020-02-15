using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2AddTwoNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp0002AddTwoNumbers
    {
        [TestMethod]
        public void DescriptionTest()
        {
            //342 + 465 = 807
            ListNode a = new ListNode
            {
                val = 2,
                next = new ListNode
                {
                    val = 4,
                    next = new ListNode
                    {
                        val = 3,
                        next = null
                    }
                }
            };

            ListNode b = new ListNode
            {
                val = 5,
                next = new ListNode
                {
                    val = 6,
                    next = new ListNode
                    {
                        val = 4,
                        next = null
                    }
                }
            };

            Solution solution = new Solution();
            Assert.AreEqual("708", solution.AddTwoNumbers(a, b).ToString());
        }

        [TestMethod]
        public void FailedTest()
        {
            ListNode a = new ListNode
            {
                val = 5,
                next = null
            };

            ListNode b = new ListNode
            {
                val = 5,
                next = null
            };

            Solution solution = new Solution();
            Assert.AreEqual("01", solution.AddTwoNumbers(a, b).ToString());
        }
    }
}
