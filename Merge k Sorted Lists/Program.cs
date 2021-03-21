using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_k_Sorted_Lists
{
    class Program
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        static void Main(string[] args)
        {
            ListNode[] lists = new ListNode[3];
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(5);
            lists[0] = l1;

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);
            lists[1] = l2;

            ListNode l3 = new ListNode(2);
            l3.next = new ListNode(6);
            lists[2] = l3;

            var result = MergeKLists(lists);
            while(result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }

        static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0) return null;
            return Partition(lists, 0, lists.Length - 1);
        }

        static ListNode Partition(ListNode[] listNodes, int start, int end)
        {
            if (start == end) return listNodes[start];
            else if(start < end)
            {
                int mid = start + (end - start) / 2;
                ListNode left = Partition(listNodes, start, mid);
                ListNode right = Partition(listNodes, mid + 1, end);
                return Merge(left, right);
            }
            else
            {
                return null;
            }
        }

        static ListNode Merge(ListNode left, ListNode right)
        {
            if (left == null) return right;
            if (right == null) return left;

            if(left.val < right.val)
            {
                left.next = Merge(left.next, right);
                return left;
            }
            else
            {
                right.next = Merge(left, right.next);
                return right;
            }
        }
    }
}
