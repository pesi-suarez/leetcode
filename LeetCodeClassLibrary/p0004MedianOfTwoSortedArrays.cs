using System;
using System.Collections.Generic;
using System.Linq;

namespace p0004MedianOfTwoSortedArrays
{
    public class Solution
    {
        //Accepted answer ft 57.35%
        private class Indexes
        {
            public int Nums1Ini { get; set; }
            public int Nums1Fin { get; set; }
            public int Nums2Ini { get; set; }
            public int Nums2Fin { get; set; }
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length >= nums2.Length)
            {
                Indexes indexes = new Indexes
                {
                    Nums1Ini = 0,
                    Nums1Fin = nums1.Length,
                    Nums2Ini = 0,
                    Nums2Fin = nums2.Length
                };
                return Recursion(nums1, nums2, indexes);
            }
            else
            {
                Indexes indexes = new Indexes
                {
                    Nums1Ini = 0,
                    Nums1Fin = nums2.Length,
                    Nums2Ini = 0,
                    Nums2Fin = nums1.Length
                };
                return Recursion(nums2, nums1, indexes);
            }
        }

        //The first array will always be bigger or equal in length
        private double Recursion(int[] nums1, int[] nums2, Indexes indexes)
        {
            if (BaseCaseCondition(indexes))
            {
                return FindMedianBaseCase(nums1, nums2, indexes);
            }
            else
            {
                double nums1Median = ComputeMedian(nums1, indexes.Nums1Ini, indexes.Nums1Fin);
                double nums2Median = ComputeMedian(nums2, indexes.Nums2Ini, indexes.Nums2Fin);
                int skippedElements = (indexes.Nums2Fin - indexes.Nums2Ini) % 2 != 0 ?
                    (indexes.Nums2Fin - indexes.Nums2Ini) / 2 :
                    (indexes.Nums2Fin - indexes.Nums2Ini) / 2 - 1;
                if (nums1Median < nums2Median)
                {
                    indexes = new Indexes
                    {
                        Nums1Ini = indexes.Nums1Ini + skippedElements,
                        Nums1Fin = indexes.Nums1Fin,
                        Nums2Ini = indexes.Nums2Ini,
                        Nums2Fin = indexes.Nums2Fin - skippedElements
                    };
                    return Recursion(nums1, nums2, indexes);
                }
                else
                {
                    indexes = new Indexes
                    {
                        Nums1Ini = indexes.Nums1Ini,
                        Nums1Fin = indexes.Nums1Fin - skippedElements,
                        Nums2Ini = indexes.Nums2Ini + skippedElements,
                        Nums2Fin = indexes.Nums2Fin
                    };
                    return Recursion(nums1, nums2, indexes);
                }
            }
        }

        private double ComputeMedian(int[] nums, int ini, int fin)
        {
            return (fin - ini) % 2 != 0 ? nums[ini + (fin - ini) / 2] : (nums[ini + (fin - ini) / 2 - 1] + nums[ini + (fin - ini) / 2]) / 2d;
        }

        private bool BaseCaseCondition(Indexes indexes)
        {
            return
                indexes.Nums2Fin - indexes.Nums2Ini <= 2;
        }

        private double FindMedianBaseCase(int[] bigArray, int[] smallArray, Indexes indexes)
        {
            if (smallArray.Length == 0)
                return ComputeMedian(bigArray, 0, bigArray.Length);
            int[] bigArrayCenter = BigArrayLength(indexes) % 2 != 0 ? GetOddCenter(bigArray, indexes) : GetEvenCenter(bigArray, indexes);
            int[] smallArrayCenter = indexes.Nums2Fin - indexes.Nums2Ini == 2 ?
                new int[] { smallArray[indexes.Nums2Ini], smallArray[indexes.Nums2Fin-1] } :
                new int[] { smallArray[indexes.Nums2Ini] };
            int[] mergedCenter = bigArrayCenter.Concat(smallArrayCenter).ToArray();
            Array.Sort(mergedCenter);
            return ComputeMedian(mergedCenter, 0, mergedCenter.Length);
        }

        private int[] GetOddCenter(int[] bigArray, Indexes indexes)
        {
            if (bigArray.Length == 1)
                return bigArray;
            int centerIndex = indexes.Nums1Ini + (indexes.Nums1Fin - indexes.Nums1Ini) / 2;
            return new int[] { bigArray[centerIndex - 1], bigArray[centerIndex], bigArray[centerIndex + 1] };
        }

        private int[] GetEvenCenter(int[] bigArray, Indexes indexes)
        {
            if (BigArrayLength(indexes) == 2)
                return new int[] { bigArray[indexes.Nums1Ini], bigArray[indexes.Nums1Ini + 1] };
            int centerIndex = indexes.Nums1Ini + (indexes.Nums1Fin - indexes.Nums1Ini) / 2 - 1;
            return new int[] { bigArray[centerIndex - 1], bigArray[centerIndex], bigArray[centerIndex + 1], bigArray[centerIndex + 2] };
        }

        private int BigArrayLength(Indexes indexes)
        {
            return indexes.Nums1Fin - indexes.Nums1Ini;
        }

    }
}
