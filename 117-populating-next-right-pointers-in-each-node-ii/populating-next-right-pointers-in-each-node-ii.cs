/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
         Node cur = root;
 while (cur != null)
 {
     Node nextHead = null;
     Node nextPrevious = null;
     while (cur != null)
     {
         if (cur.left != null)
         {
             if (nextPrevious != null)
                 nextPrevious.next = cur.left;
             else
                 nextHead = cur.left;
             nextPrevious = cur.left;
         }

         if (cur.right != null)
         {
             if (nextPrevious != null)
                 nextPrevious.next = cur.right;
             else
                 nextHead = cur.right;
             nextPrevious = cur.right;
         }

         cur = cur.next;
     }

     cur = nextHead;
 }

 return root;
    }
}