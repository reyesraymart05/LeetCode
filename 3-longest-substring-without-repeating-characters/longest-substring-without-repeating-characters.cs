using System;
using System.Collections.Generic;

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> seen = new Dictionary<char, int>();
        int i = 0, res = 0;

        for (int j = 0; j < s.Length; j++) {
            char currentChar = s[j];
            if (seen.ContainsKey(currentChar)) {
                i = Math.Max(i, seen[currentChar] + 1);
            }
            seen[currentChar] = j;
            res = Math.Max(res, j - i + 1);
        }

        return res;
    }
}