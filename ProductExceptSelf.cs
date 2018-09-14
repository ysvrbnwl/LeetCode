using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] res = new int[nums.Length];
            List<int> zeros = new List<int>();
            var total = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    total = total * nums[i];
                }
                else
                {
                    zeros.Add(i);
                }
            }

            if (zeros.Count > 1)
            {
                return res;
            }
            else if (zeros.Count == 1)
            {
                res[zeros[0]] = total;
                return res;
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    res[i] = total / nums[i];
                }
            }

            return res;
        }
    }
}
