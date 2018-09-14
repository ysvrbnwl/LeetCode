public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int max = 0;
            int i = 0;
            int j = 1;

            while (j <= s.Length)
            {
                if (hasUnique(s.Substring(i, j - i)))
                {
                    if (j - i >= max)
                    {
                        max = j - i;
                    }
                    j++;
                }
                else
                {
                    i++;
                }
            }
            return max;
        }

        public static bool hasUnique(string s)
        {
            bool[] array = new bool[256];
            foreach (char value in s)
                if (array[(int)value])
                    return false;
                else
                    array[(int)value] = true;

            return true;
        }
    }
