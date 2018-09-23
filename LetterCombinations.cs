public class Solution
{
    public Dictionary<char, string> dict = new Dictionary<char, string>() {
        {'1', ""},
        {'2', "abc"},
        {'3', "def"},
        {'4', "ghi"},
        {'5', "jkl"},
        {'6', "mno"},
        {'7', "pqrs"},
        {'8', "tuv"},
        {'9', "wxyz"}
    };

    public IList<string> LetterCombinations(string digits)
    {
        List<string> list = new List<string>();
        if (string.IsNullOrEmpty(digits))
        {
            return list;
        }
        if (digits.Length == 1)
        {
            foreach (var ch in dict[digits[0]])
            {
                list.Add(ch.ToString());
            }
        }
        else
        {
            var childList = LetterCombinations(digits.Substring(1));
            foreach (var childItem in childList)
            {
                foreach (var ch in dict[digits[0]])
                {
                    list.Add(string.Format("{0}{1}", ch, childItem));
                }
            }
        }
        return list;
    }
}
