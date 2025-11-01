public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> hs = new HashSet<int>(nums);

        int longest = 0;
        foreach(var num in hs){
            if(!hs.Contains(num-1))
            {
                int length = 1;

                while(hs.Contains(num+length)){
                    length ++;
                }

                longest = Math.Max(length, longest);
            }
        }

        return longest;
    }
}