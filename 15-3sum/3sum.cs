public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
         IList<IList<int>> result= new List<IList<int>>();
        int n= nums.Length;
        Array.Sort(nums);
        for(int i=0;i<n;i++)
        {
            if(i>0 && nums[i]==nums[i-1]) continue;
            int j=i+1;
            int k=n-1;
            while(j<k)
            {
                int sum= nums[i]+nums[j]+nums[k];
                if(sum>0){
                    k--;
                }
                else if (sum<0){
                    j++;
                }
                else{
                    IList<int> temp= new List<int>{nums[i],nums[j],nums[k]};
                    result.Add(temp);
                    j++ ;
                    k--;
                    while(j<k && nums[j]==nums[j-1]) j++;
                    while(j<k && nums[k]==nums[k+1]) k--;
                }
            }
        }
        return result;
    }
}