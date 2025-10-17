public class Solution {
    public int Jump(int[] nums) {
         int steps = 0, l = 0, r = 0;
        while (r < nums.Length - 1) {
            int farthest = 0;
            for (int i = l; i <= r; i++) {
                farthest = Math.Max(farthest, i + nums[i]);
            }
            l = r + 1;
            r = farthest;
            steps++;
        }
        return steps;
    }
}