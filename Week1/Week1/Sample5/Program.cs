using System;
using System.Collections.Generic;

namespace Sample5
{
    public class Solution
    {
        public int[] RunningSum(int[] nums)
        {
            List<int> res = new List<int>();
            for (int j = 0; j < nums.Length; ++j)
            {
                int sum = 0;
                for (int i = 0; i <= j; ++i)
                {
                    sum += nums[i];
                }
                res.Add(sum);
            }
            
            return res.ToArray();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution s1 = new Solution();
            foreach (int x in s1.RunningSum(new int[] { 1, 2, 3, 4 }))
            {
                Console.Write(x + " ");
            }
        }
    }
}
