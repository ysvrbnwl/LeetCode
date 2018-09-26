public class Solution
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
        {
            return null;
        }

        ListNode minNode = lists[0];
        int indexMin = 0;

        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null)
            {
                if (minNode == null || minNode.val >= lists[i].val)
                {
                    minNode = lists[i];
                    indexMin = i;
                }
            }
        }
        if (minNode == null)
        {
            return null;
        }

        ListNode result = minNode;
        lists[indexMin] = lists[indexMin].next;

        return new ListNode(result.val)
        {
            next = MergeKLists(lists)
        };
    }
}
