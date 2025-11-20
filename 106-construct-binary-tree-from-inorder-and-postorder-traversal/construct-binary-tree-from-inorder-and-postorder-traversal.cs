/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        int n = inorder.Length;
        var pos = new Dictionary<int, int>(n);
        for (int i = 0; i < n; i++) pos[inorder[i]] = i;

        int p = n - 1;
        return Build(0, n - 1, inorder, postorder, pos, ref p);
    }

    private TreeNode Build(int l, int r, int[] inorder, int[] postorder,
                           Dictionary<int,int> pos, ref int p) {
        if (l > r) return null;
        int val = postorder[p--];
        int m = pos[val];
        var root = new TreeNode(val);
        root.right = Build(m + 1, r, inorder, postorder, pos, ref p);
        root.left  = Build(l, m - 1, inorder, postorder, pos, ref p);
        return root;
    }
}