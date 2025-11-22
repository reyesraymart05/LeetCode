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
        if (root == null) return null;

        Connect(root.right, root);
        Connect(root.left, root);

        return root;
    }

    private void Connect(Node root, Node parent) {
        if (root == null) return;

        if (parent.left == root && parent.right != null) {
            root.next = parent.right;
        } else {
            var tmp = parent.next;
            while (root.next == null && tmp != null) {
                root.next = tmp.left ?? tmp.right;
                tmp = tmp.next;
            }
        }

        Connect(root.right, root);
        Connect(root.left, root);
    }
}