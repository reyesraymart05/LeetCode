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
    public int KthSmallest(TreeNode root, int k) 
    {
        List<int> list = new List<int>();
        InorderTraversal(root, list);
        return list[k-1];
    }

    public void InorderTraversal(TreeNode root, List<int> list)
    {
        if(root is null)
            return;

        InorderTraversal(root.left, list);
        list.Add(root.val);
        InorderTraversal(root.right, list);
    }
}