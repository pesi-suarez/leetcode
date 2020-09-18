using p0004MedianOfTwoSortedArrays;
using Xunit;

namespace LeetCodeUnitTesting
{
    //1 2 4 5 [7] 9 12 21 32
    /* Este ejemplo demuestra que no puedo quedarme con un único elemento en el array más pequeño, porque puede ser que la mediana del conjunto final esté entre dos elementos de este array. Por suerte coincide el resultado, pero es porque 7  está en el array grande.
     1 4 [7 12] 21 32
     2 [5] 9

     1 4 [7] 12 21 
     [5 9]

     4 7 12 21
     5

     4 5 7 12 21 -> 7

     1 2 4 5 9 12 21 32 -> (5+9) / 2 = 7
     */
    /*
     Tal vez la estrategia es eliminar hasta quedarme con 1 o 2 en el más pequeño y ordenar esos más los 1 o 2 de la mediana del otro 
     */
    public class utp0004MedianOfTwoSortedArrays
    {
        [Fact]
        public void CustomTests()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 4, 7, 12, 21, 32 };
            int[] nums2 = new int[] { 2, 5, 9 };
            Assert.Equal(7, solution.FindMedianSortedArrays(nums1, nums2));
        }

        [Fact]
        public void DescriptionTest00()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 3 };
            int[] nums2 = new int[] { 2 };
            Assert.Equal(2, solution.FindMedianSortedArrays(nums1, nums2));
        }

        [Fact]
        public void DescriptionTest01()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 2 };
            int[] nums2 = new int[] { 3, 4 };
            Assert.Equal(2.5, solution.FindMedianSortedArrays(nums1, nums2));
        }

        [Fact]
        public void DescriptionTest02()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { };
            int[] nums2 = new int[] { 1 };
            Assert.Equal(1, solution.FindMedianSortedArrays(nums1, nums2));
        }

        [Fact]
        public void DescriptionTest03()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1 };
            int[] nums2 = new int[] { 1 };
            Assert.Equal(1, solution.FindMedianSortedArrays(nums1, nums2));
        }

        [Fact]
        public void DescriptionTest04()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 1, 1 };
            int[] nums2 = new int[] { 1, 1, 1 };
            Assert.Equal(1, solution.FindMedianSortedArrays(nums1, nums2));
        }

        [Fact]
        public void DescriptionTest05()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1 };
            int[] nums2 = new int[] { 2, 3, 4, 5 };
            Assert.Equal(3, solution.FindMedianSortedArrays(nums1, nums2));
        }

        /*
         * 2 [3 4] 7
         * 1 [5] 6
         * 3 [4] 7
         * [1 5]
         * 1 3 4 5 7 -> 4
         
         */
        [Fact]
        public void DescriptionTest06()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 5, 6 };
            int[] nums2 = new int[] { 2, 3, 4, 7 };
            Assert.Equal(4, solution.FindMedianSortedArrays(nums1, nums2));
        }
        /*
         * 1 [2] 5
         * 3 [4] 6
         * [2 5]
         * [3 4]
         * 2 3 4 5 -> 3.5
         * 
         */
        [Fact]
        public void DescriptionTest07()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 2, 5 };
            int[] nums2 = new int[] { 3, 4, 6 };
            Assert.Equal(3.5, solution.FindMedianSortedArrays(nums1, nums2));
        }

        /*
         * 1 [2 6] 7
         * 3 [4 5] 8
         * 2 [6] 7
         * 3 [4] 5
         * [2 6]
         * [4 5]
         * 2 4 5 6 -> 4.5
         */
        [Fact]
        public void DescriptionTest08()
        {
            Solution solution = new Solution();
            int[] nums1 = new int[] { 1, 2, 6, 7 };
            int[] nums2 = new int[] { 3, 4, 5, 8 };
            Assert.Equal(4.5, solution.FindMedianSortedArrays(nums1, nums2));
        }
    }
}
