namespace p0053MaximumSubarray.cs
{
    public class Solution
    {
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
    }
}
