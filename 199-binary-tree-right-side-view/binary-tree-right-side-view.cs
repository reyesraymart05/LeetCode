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
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        var globalLevel = 0;
        Traversal(root);
        return result;
        
        void Traversal(TreeNode root, int curLevel = 0)
        {
            if (root == null) return;

            if (curLevel == globalLevel)
            {
                result.Add(root.val);
                globalLevel++;
            }
            
            curLevel++;
            Traversal(root.right, curLevel);
            Traversal(root.left, curLevel);
        }
    }
}