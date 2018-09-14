using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var total = 0;
            if (l1 == null && l2 == null)
            {
                return null;
            }
            else if (l1 == null && l2 != null)
            {
                total = l2.val;
            }
            else if (l1 != null && l2 == null)
            {
                total = l1.val;
            }
            else
            {
                total = l1.val + l2.val;
            }

            if (total >= 10)
            {
                if (l1 != null)
                {
                    if (l1.next != null)
                    {
                        l1.next.val = l1.next.val + 1;
                    }
                    else
                    {
                        l1.next = new ListNode(1);
                    }
                }
                else if (l2 != null)
                {
                    if (l2.next != null)
                    {
                        l2.next.val = l2.next.val + 1;
                    }
                    else
                    {
                        l2.next = new ListNode(1);
                    }
                }
                total = total % 10;
            }

            if (l1 == null && l2 != null)
            {
                return new ListNode(total)
                {
                    next = AddTwoNumbers(null, l2.next)
                };
            }
            else if (l1 != null && l2 == null)
            {
                return new ListNode(total)
                {
                    next = AddTwoNumbers(l1.next, null)
                };
            }
            else
            {
                return new ListNode(total)
                {
                    next = AddTwoNumbers(l1.next, l2.next)
                };
            }

        }
    }
}
