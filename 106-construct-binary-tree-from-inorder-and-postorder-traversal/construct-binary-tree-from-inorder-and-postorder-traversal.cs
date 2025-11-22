public class Solution {
    private Dictionary<int, int> inorderIndexMap;
    private int[] postorder;

    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        this.postorder = postorder;
        inorderIndexMap = new Dictionary<int, int>();
        for (int i = 0; i < inorder.Length; i++) {
            inorderIndexMap[inorder[i]] = i;
        }
        return BuildSubtree(0, 0, inorder.Length);
    }

    private TreeNode BuildSubtree(int inorderStart, int postorderStart, int subtreeSize) {
        if (subtreeSize <= 0) return null;

        int rootVal = postorder[postorderStart + subtreeSize - 1];
        int rootIndexInorder = inorderIndexMap[rootVal];
        int leftSubtreeSize = rootIndexInorder - inorderStart;

        TreeNode leftChild = BuildSubtree(inorderStart, postorderStart, leftSubtreeSize);
        TreeNode rightChild = BuildSubtree(rootIndexInorder + 1, postorderStart + leftSubtreeSize, subtreeSize - leftSubtreeSize - 1);

        return new TreeNode(rootVal, leftChild, rightChild);
    }
}