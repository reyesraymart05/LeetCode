public class Solution {
    int maxSum = int.MinValue;
    int DFS(TreeNode root) {
        if (root == null) return 0;
        int left = Math.Max(DFS(root.left), 0);
        int right = Math.Max(DFS(root.right), 0);
        maxSum = Math.Max(maxSum, root.val + left + right);
        return root.val + Math.Max(left, right);
    }
    public int MaxPathSum(TreeNode root) {
        DFS(root);
        return maxSum;
    }
}