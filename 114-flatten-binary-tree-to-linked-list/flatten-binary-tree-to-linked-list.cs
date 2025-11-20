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
    public void Flatten(TreeNode root) {
        TreeNode current = root;
        while (current != null)
        {
            if (current.left != null)
            {
                TreeNode temp = current.left;
                while (temp.right != null)          // Find the rightmost node of the left subtree
                    temp = temp.right;
                temp.right = current.right;         // Connect it to the current's right subtree
                current.right = current.left;       // Move left subtree to right
                current.left = null;
            }
            current = current.right;
        }
    }
}