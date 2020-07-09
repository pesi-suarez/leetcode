using p709ToLowerCase;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0709ToLowerCase
    {
        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            Assert.Equal("hello", solution.ToLowerCase("Hello"));
            Assert.Equal("here", solution.ToLowerCase("here"));
            Assert.Equal("lovely", solution.ToLowerCase("LOVELY"));
        }
    }
}
