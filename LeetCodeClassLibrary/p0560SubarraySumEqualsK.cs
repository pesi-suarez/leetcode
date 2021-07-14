namespace p0560SubarraySumEqualsK
{
    public class Solution
    {
        public int SubarraySum(int[] nums, int k)
        {
            int kCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == k)
                    kCount++;
                int acum = nums[i];
                for (int j = i+1; j < nums.Length; j++)
                {
                    acum += nums[j];
                    if (acum == k)
                        kCount++;
                }
            }
            return kCount;
        }
    }
}
