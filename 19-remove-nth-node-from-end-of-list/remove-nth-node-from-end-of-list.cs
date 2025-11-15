public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode left = dummy;
        ListNode right = dummy;

        // Move right forward n+1 times
        for(int i = 0; i <= n; i++) {
            right = right.next;
        }

        // Move left and right forward until right reaches the end
        while(right != null) {
            left = left.next;
            right = right.next;
        }

        // Remove node
        left.next = left.next.next;

        return dummy.next;
    }
}