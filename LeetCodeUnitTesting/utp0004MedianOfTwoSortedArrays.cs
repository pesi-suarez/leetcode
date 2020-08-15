using p0004MedianOfTwoSortedArrays;
using Xunit;

namespace LeetCodeUnitTesting
{
    /* Este ejemplo demuestra que no puedo quedarme con un único elemento en el array más pequeño, porque puede ser que la mediana del conjunto final esté entre dos elementos del este array. Por suerte coincide el resultado, pero es porque 7  está en el array grande.
     1 4 7 12 21 32
     2 5 9

     1 4 7 12 21 
     5 9

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

        /*
        [Fact]
        public void DescriptionTests()
        {
            
        }
        */
    }
}
