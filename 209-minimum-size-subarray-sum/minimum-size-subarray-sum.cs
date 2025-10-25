public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int start = 0, currSum = 0;
        int minSize = int.MaxValue;

        for (int i = 0; i < nums.Length; i++) {
            currSum += nums[i];

            while (currSum >= target) {
                minSize = Math.Min(minSize, i - start + 1);
                currSum -= nums[start];
                start++;
            }
        }
        return minSize == int.MaxValue ? 0 : minSize;
    }
}