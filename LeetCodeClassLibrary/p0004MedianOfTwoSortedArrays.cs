using System;

namespace p0004MedianOfTwoSortedArrays
{
    public class Solution
    {
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
                int skippedElements = (indexes.Nums2Fin - indexes.Nums2Ini) / 2;
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
            return (fin - ini) % 2 != 0 ? nums[(fin - ini) / 2] : (nums[(fin - ini) / 2 - 1] + nums[(fin - ini) / 2]) / 2d;
        }

        private bool BaseCaseCondition(Indexes indexes)
        {
            return
                indexes.Nums1Fin - indexes.Nums1Ini == 1 ||
                indexes.Nums2Fin - indexes.Nums2Ini == 1;
        }

        private bool Nums1SliceIsBigger(Indexes indexes)
        {
            return indexes.Nums1Fin - indexes.Nums1Ini > indexes.Nums2Fin - indexes.Nums2Ini;
        }

        private double FindMedianBaseCase(int[] bigArray, int[] smallArray, Indexes indexes)
        {
            if (BigArrayLength(indexes) % 2 != 0)
            {
                int bigArrayMedianIndex = (indexes.Nums1Fin - indexes.Nums1Ini) / 2;
                int bigArrayMedian = bigArray[bigArrayMedianIndex];
                int singleElement = smallArray[indexes.Nums2Ini];
                if (singleElement < bigArrayMedian)
                {
                    if (bigArrayMedianIndex > 0)
                    {
                        if (singleElement > bigArray[bigArrayMedianIndex - 1])
                            return (bigArrayMedian + singleElement) / 2;
                        else
                            return (bigArrayMedian + bigArray[bigArrayMedianIndex - 1]) / 2;
                    }
                    else
                    {
                        return (bigArrayMedian + singleElement) / 2;
                    }
                }
                else
                {
                    if (bigArrayMedianIndex < indexes.Nums1Fin - 1)
                    {
                        if (singleElement < bigArray[bigArrayMedianIndex + 1])
                            return (bigArrayMedian + singleElement) / 2;
                        else
                            return (bigArrayMedian + bigArray[bigArrayMedianIndex + 1]) / 2;

                    }
                    else
                    {
                        return (bigArrayMedian + singleElement) / 2;
                    }
                }
            }
            else
            {
                int bigArrayMedianLowIndex = (indexes.Nums1Fin - indexes.Nums1Ini) / 2;
                int bigArrayMedianHighIndex = (indexes.Nums1Fin - indexes.Nums1Ini) / 2 + 1;
                int singleElement = smallArray[indexes.Nums2Ini];
                if (singleElement < bigArray[bigArrayMedianLowIndex])
                    return bigArray[bigArrayMedianLowIndex];
                else if (singleElement < bigArray[bigArrayMedianHighIndex])
                    return singleElement;
                else return bigArray[bigArrayMedianHighIndex];
            }
        }

        private int BigArrayLength(Indexes indexes)
        {
            return indexes.Nums1Fin - indexes.Nums1Ini;
        }

    }
}
