public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        if(nums.Length <= 2)
            return false;
        
        int first = int.MaxValue;
        int mid = int.MaxValue;

        for(int i = 0; i < nums.Length; i++)
        {
            if(mid < nums[i])
                return true;
            
            if(first >= nums[i])
                first = nums[i];
            else
                mid = nums[i];
        }
        return false;
    }
}