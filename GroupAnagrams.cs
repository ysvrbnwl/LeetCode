public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        List<IList<string>> list = new List<IList<string>>();
        for (int i = 0; i < strs.Length; i++)
        {
            var ordered = String.Concat(strs[i].OrderBy(c => c));
            if (dict.ContainsKey(ordered))
            {
                dict[ordered].Add(strs[i]);
            }
            else
            {
                dict.Add(ordered, new List<string>() { strs[i] });
            }
        }

        foreach (var entry in dict)
        {
            list.Add(entry.Value);
        }
        return list;
    }
}
