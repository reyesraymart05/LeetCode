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
        List<Node> curLevel = new List<Node>();
        if(root == null){
            return root;
        }
        curLevel.Add(root);
        ConnectLevel(curLevel);
        return root;
    }
    public void ConnectLevel(List<Node> nodes) {
        List<Node> nextLevel = new List<Node>();
        for(int i =0; i < nodes.Count(); i++){
            if(i + 1 < nodes.Count()){
                nodes[i].next  = nodes[i+1];
            }
            else{
                nodes[i].next = null;
            }
            if(nodes[i].left != null){
                nextLevel.Add(nodes[i].left);
            }
            if(nodes[i].right != null){
                nextLevel.Add(nodes[i].right);
            }
        }
        if(nextLevel.Count() == 0){
            return;
        }
        ConnectLevel(nextLevel);
    }
}