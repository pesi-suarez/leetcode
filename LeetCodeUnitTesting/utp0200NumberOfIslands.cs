using p200NumberOfIslands;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0200NumberOfIslands
    {
        [Fact]
        public void DescriptionTest00()
        {
            char[][] data = new char[][]
            {
            new char[] {'1', '1', '1', '1', '0'},
            new char[] {'1', '1', '0', '1', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '0', '0', '0'}
            };

            Solution solution = new Solution();
            Assert.Equal(1, solution.NumIslands(data));
        }

        [Fact]
        public void DescriptionTest01()
        {
            char[][] data = new char[][]
            {
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
            };

            Solution solution = new Solution();
            Assert.Equal(3, solution.NumIslands(data));
        }

        [Fact]
        public void Trivial00()
        {
            char[][] data = new char[][]
            {
            };

            Solution solution = new Solution();
            Assert.Equal(0, solution.NumIslands(data));
        }

        [Fact]
        public void Trivial01()
        {
            char[][] data = new char[][]
            {
                new char[] {'1'}
            };

            Solution solution = new Solution();
            Assert.Equal(1, solution.NumIslands(data));
        }

        [Fact]
        public void UShapedIsland()
        {
            char[][] data = new char[][]
            {
            new char[] {'1', '0', '0', '1', '0'},
            new char[] {'1', '1', '1', '1', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
            };

            Solution solution = new Solution();
            Assert.Equal(2, solution.NumIslands(data));
        }

    }
}
