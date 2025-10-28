public class Solution {
    public string MinWindow(string s, string t) {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || s.Length < t.Length) {
            return "";
        }

        int[] map = new int[128];
        int count = t.Length;
        int start = 0, end = 0, minLen = int.MaxValue, startIndex = 0;
     
        foreach (char c in t) {
            map[c]++;
        }

        char[] chS = s.ToCharArray();

        while (end < chS.Length) {
            if (map[chS[end++]]-- > 0) {
                count--;
            }

            while (count == 0) {
                if (end - start < minLen) {
                    startIndex = start;
                    minLen = end - start;
                }

                if (map[chS[start++]]++ == 0) {
                    count++;
                }
            }
        }

        return minLen == int.MaxValue ? "" : new string(chS, startIndex, minLen);
    }
}