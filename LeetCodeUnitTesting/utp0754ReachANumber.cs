using p754ReachANumber;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0754ReachANumber
    {
        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.Equal(2, solution.ReachNumber(3));
            Assert.Equal(3, solution.ReachNumber(2));
        }
    }
}
