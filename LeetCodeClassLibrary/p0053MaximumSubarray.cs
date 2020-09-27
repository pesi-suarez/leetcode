using System;
using System.Collections.Generic;
using System.Linq;

namespace p0053MaximumSubarray.cs
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            if (nums.All(num => num >= 0))
                return nums.Sum();
            else if (nums.All(num => num < 0))
                return nums.Max();
            else
            {
                int currentSum = 0;
                int maxSum = nums[0];
                for (int i = 0; i < nums.Length; i++)
                {
                    currentSum += nums[i];
                    if (currentSum < 0)
                        currentSum = 0;
                    else
                        maxSum = currentSum > maxSum ? currentSum : maxSum;
                }
                return maxSum;
            }
        }

        //O(n2)
        /*
        public int MaxSubArray(int[] nums)
        {
            int candidate = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    candidate = sum > candidate ? sum : candidate;
                }
            }
            return candidate;
        }
        */
    }
}
