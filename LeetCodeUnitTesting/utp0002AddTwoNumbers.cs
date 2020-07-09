using p2AddTwoNumbers;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0002AddTwoNumbers
    {
        [Fact]
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
            Assert.Equal("708", solution.AddTwoNumbers(a, b).ToString());
        }

        [Fact]
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
            Assert.Equal("01", solution.AddTwoNumbers(a, b).ToString());
        }
    }
}
