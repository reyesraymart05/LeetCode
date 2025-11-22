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
        if(root == null) return root;
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(root);
        while(q.Count > 0){
            int count = q.Count;
            Node prev = null;
            for(int i = 0; i < count;i++){
                Node cur = q.Dequeue();
                if(cur.right != null)  q.Enqueue(cur.right);
                if(cur.left != null)  q.Enqueue(cur.left);
                cur.next = prev;
                prev = cur;
            }
        }
        return root;
    }
}










