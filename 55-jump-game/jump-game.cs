public class Solution {
    public bool CanJump(int[] nums) {
        int goal = nums.Length - 1;
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            if (i + nums[i] >= goal)
                goal = i;
        }
        return goal ==0;
    }
}