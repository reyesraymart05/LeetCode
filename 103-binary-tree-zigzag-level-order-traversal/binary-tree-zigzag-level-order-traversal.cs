public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        bool ltrt = true; // left-to-right toggle

        while (queue.Count > 0) {
            int size = queue.Count;
            LinkedList<int> level = new LinkedList<int>();

            for (int i = 0; i < size; i++) {
                TreeNode curr = queue.Dequeue();

                if (ltrt)
                    level.AddLast(curr.val);
                else
                    level.AddFirst(curr.val);

                if (curr.left != null) queue.Enqueue(curr.left);
                if (curr.right != null) queue.Enqueue(curr.right);
            }

            result.Add(level.ToList());
            ltrt = !ltrt;
        }

        return result;
    }
}