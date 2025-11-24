public class BSTIterator {
    private Stack<TreeNode> stack;

    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        PushLeft(root);
    }

    private void PushLeft(TreeNode node) {
        while (node != null) {
            stack.Push(node);
            node = node.left;
        }
    }

    public int Next() {
        TreeNode node = stack.Pop();
        if (node.right != null) {
            PushLeft(node.right);
        }
        return node.val;
    }

    public bool HasNext() {
        return stack.Count > 0;
    }
}