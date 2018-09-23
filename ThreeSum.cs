    class Solution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<string> uniqueTriplets = new List<string>();
            List<List<int>> list = new List<List<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(nums[i]);
                        sb.Append(":");
                        sb.Append(nums[j]);
                        sb.Append(":");
                        sb.Append(nums[k]);
                        var temp = sb.ToString();
                        if (!uniqueTriplets.Any(x => x == temp))
                        {
                            uniqueTriplets.Add(temp);
                            Console.WriteLine(temp);
                            list.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        }
                        j++;
                        k--;
                    }
                    else if (nums[i] + nums[j] + nums[k] > 0)
                    {
                        k--;
                    }
                    else
                    {
                        j++;
                    }

                }
            }

            return list.ToArray();
        }
    }
