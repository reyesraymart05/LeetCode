public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int totalTank = 0;
        int currentTank = 0;
        int start = 0;

        for (int i = 0; i < gas.Length; i++)
        {
            int diff = gas[i] - cost[i];
            totalTank += diff;
            currentTank += diff;

            if (currentTank < 0)
            {
                start = i + 1;
                currentTank = 0;
            }
        }

        return totalTank >= 0 ? start : -1;
    }
}