using System;
using System.Collections.Generic;

public class Solution {
    const int MOD = 1000000007;
    Dictionary<(int, int, int, int), int> memo = new();

    public int MagicalSum(int m, int k, int[] nums) {
        return DFS(m, k, 0, 0, nums);
    }

    int DFS(int r, int n, int i, int c, int[] nums) {
        if (r < 0 || n < 0 || r + BitCount(c) < n) return 0;
        if (r == 0) return BitCount(c) == n ? 1 : 0;
        if (i >= nums.Length) return 0;

        var key = (r, n, i, c);
        if (memo.TryGetValue(key, out int val)) return val;

        long res = 0;
        for (int t = 0; t <= r; t++) {
            long comb = Comb(r, t);
            long pow = ModPow(nums[i], t);
            int nc = c + t;
            res = (res + comb * pow % MOD * DFS(r - t, n - (nc % 2), i + 1, nc / 2, nums)) % MOD;
        }
        return memo[key] = (int)res;
    }

    int BitCount(int x) {
        int cnt = 0;
        while (x > 0) { cnt += x & 1; x >>= 1; }
        return cnt;
    }

    long ModPow(int a, int b) {
        long res = 1, baseVal = a;
        while (b > 0) {
            if ((b & 1) == 1) res = res * baseVal % MOD;
            baseVal = baseVal * baseVal % MOD;
            b >>= 1;
        }
        return res;
    }

    long Comb(int n, int k) {
        if (k > n) return 0;
        long res = 1;
        for (int i = 0; i < k; i++) res = res * (n - i) / (i + 1);
        return res % MOD;
    }
}