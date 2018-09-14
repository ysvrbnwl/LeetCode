class Solution {
    // O N2
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
            return s;

        int start = 0, end = 0;
        string longest = string.Empty;

        for (int i = 0; i < s.Length; i++)
        {
            int len1 = expandAroundCenter(s, i, i);
            int len2 = expandAroundCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);
            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    public int expandAroundCenter(string s, int left, int right)
    {
        int L = left;
        int R = right;

        while (L >= 0 && R < s.Length && s[L] == s[R])
        {
            L--;
            R++;
        }
        return R - L - 1;
    }
    
    // Brute Force
    public string LongestPalindromeBruteForce(string s)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s) || isPalindrome(s))
            return s;

        int size = 0;
        string longest = string.Empty;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j <= s.Length; j++)
            {
                if (isPalindrome(s.Substring(i, j - i)))
                {
                    if (j - i >= size)
                    {
                        size = j - i;
                        longest = s.Substring(i, j - i);
                    }
                }
            }
        }
        return longest;
    }

    public bool isPalindrome(string s)
    {
        return s.SequenceEqual(s.Reverse());
    }
}
