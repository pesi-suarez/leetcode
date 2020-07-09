using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0855ExamRoom
    {
        [Fact]
        public void ArrayInitilizationZero()
        {
            int[] values = new int[10];
            for (int i = 0; i < values.Length; i++)
                Assert.Equal(0, values[i]);
        }
    }
}
