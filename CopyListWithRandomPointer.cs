public class Solution
{
    public static Dictionary<RandomListNode, RandomListNode> dict = new Dictionary<RandomListNode, RandomListNode>();

    public RandomListNode CopyRandomList(RandomListNode head)
    {
        if (head == null)
        {
            return null;
        }

        if (dict.ContainsKey(head))
        {
            return dict[head];
        }

        RandomListNode value = new RandomListNode(head.label);
        dict.Add(head, value);
        value.next = CopyRandomList(head.next);
        value.random = CopyRandomList(head.random);
        return value;
    }
}
