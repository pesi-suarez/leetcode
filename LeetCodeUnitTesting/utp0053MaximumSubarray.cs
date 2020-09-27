using p0053MaximumSubarray.cs;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0053MaximumSubarray
    {
        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.Equal(6, solution.MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4  }));
            Assert.Equal(1, solution.MaxSubArray(new int[] { 1 }));
            Assert.Equal(0, solution.MaxSubArray(new int[] { 0 }));
            Assert.Equal(-1, solution.MaxSubArray(new int[] { -1 }));
            Assert.Equal(-2147483647, solution.MaxSubArray(new int[] { -2147483647 })); 
        }
    }
}
