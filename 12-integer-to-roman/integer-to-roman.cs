public class Solution {
    public string IntToRoman(int num) {
        int[] values = new int[]{1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] symbols = new[]{"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX","V", "IV","I"};
    
        StringBuilder romanValue = new StringBuilder();
        for (int i = 0; i < 13 && num > 0; )
        {
            if (num >= values[i]) {
                romanValue.Append(symbols[i]);
                num = num - values[i];
            }
            else {
                i++;
            }
        }

        return romanValue.ToString();
    }
}