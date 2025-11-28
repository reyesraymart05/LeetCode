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
    TreeNode prev = null;
    bool result = true;
    public void helper(TreeNode root){
        if(root == null)return;
        helper(root.left);
        if(prev == null)prev = root;
        else if(root.val <= prev.val)result = false;
        else prev = root;
        helper(root.right);
    }
    public bool IsValidBST(TreeNode root) {
         helper(root);
        return result;
    }
}