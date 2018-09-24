public class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }

        bool[] indices = new bool[s.Length];
        for (int i = 1; i <= s.Length; i++)
        {
            var str = s.Substring(0, i);
            if (wordDict.Any(a => a == str))
            {
                var substr = s.Substring(i);
                if (substr.Length == 0)
                {
                    return true;
                }
                indices[i - 1] = WordBreak(substr, wordDict);
                if (indices[i - 1] == true)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

public class Solution2
{
    public bool WordBreak(String s, List<String> wordDict)
    {
        HashSet<String> wordDictSet = new HashSet<string>(wordDict);
        bool[] dp = new bool[s.Length + 1];
        dp[0] = true;
        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && wordDictSet.Contains(s.Substring(j, i - j)))
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[s.Length];
    }
}
