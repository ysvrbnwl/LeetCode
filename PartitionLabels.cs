using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class Solution
    {
        public IList<int> PartitionLabels(string S)
        {
            List<int> list = new List<int>();
            if (string.IsNullOrEmpty(S))
            {
                return new List<int>();
            }

            for (int i = 0; i < S.Length; i++)
            {
                var lastOccurence = S.LastIndexOf(S[i]);
                List<int> insideList = new List<int>();
                insideList.Add(lastOccurence);
                for (int j = i + 1; j < insideList.Max(); j++)
                {
                    insideList.Add(S.LastIndexOf(S[j]));
                }
                list.Add(insideList.Max() + 1 - i);
                i = list.Sum() - 1;
            }
            return list;
        }
    }

}
