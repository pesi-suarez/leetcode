using p0994RottingOranges;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0994RottingOranges
    {
        [Fact]
        public void CustomTests()
        {
            Solution solution = new Solution();
            Assert.Equal(1, solution.OrangesRotting(new int[][]
            {
                new int[] { 1, 2 }
            }));
        }

        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.Equal(4, solution.OrangesRotting(new int[][]
            {
                new int[] { 2, 1, 1 },
                new int[] { 1, 1, 0 },
                new int[] { 0, 1, 1 }
            }));
            Assert.Equal(-1, solution.OrangesRotting(new int[][]
            {
                new int[] { 2, 1, 1 },
                new int[] { 0, 1, 1 },
                new int[] { 1, 0, 1 }
            }));
            Assert.Equal(0, solution.OrangesRotting(new int[][]
            {
                new int[] { 0, 2 }
            }));
        }

    }
}
