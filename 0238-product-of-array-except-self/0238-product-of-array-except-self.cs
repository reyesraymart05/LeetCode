public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int[] answers = Enumerable.Repeat(1, nums.Length).ToArray();
        
        for (int i = 0; i < nums.Length; i++) {
            if (i == 0) {
                answers[i] = 1;
            }
            if (i - 1> -1) {
                var pre = answers[i -1] * nums[i - 1];
                answers[i] *= pre;
            }
        }
        var suf = 1;
        for (int i = nums.Length -1 ; i >= 0; i --) {

                answers[i] *= suf;
                suf *= nums[i];
            
        }
        
        return answers;

    }
}
