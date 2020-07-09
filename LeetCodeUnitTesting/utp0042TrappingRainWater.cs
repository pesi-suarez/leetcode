using p42TrappingRainWater;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0042TrappingRainWater
    {
        [Fact]
        public void DescriptionTest()
        {
            Solution solution = new Solution();
            Assert.Equal(6, solution.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }));
        }

        [Fact]
        public void FailedTest0()
        {
            Solution solution = new Solution();
            Assert.Equal(0, solution.Trap(new int[] {  }));
        }

        [Fact]
        public void FailedTest1()
        {
            Solution solution = new Solution();
            Assert.Equal(2, solution.Trap(new int[] { 2, 0, 2}));
        }

        [Fact]
        public void SmallArray0()
        {
            Solution solution = new Solution();
            Assert.Equal(0, solution.Trap(new int[] { 4 }));
        }

        [Fact]
        public void SmallArray1()
        {
            Solution solution = new Solution();
            Assert.Equal(0, solution.Trap(new int[] { 4, 5 }));
        }
    }
}
