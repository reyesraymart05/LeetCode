using System;
using System.Collections.Generic;

public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        int[] inDegree = new int[numCourses];
        Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();
        
        foreach (var pre in prerequisites) {
            if (!adj.ContainsKey(pre[0])) adj[pre[0]] = new List<int>();
            adj[pre[0]].Add(pre[1]);
        }
        
        foreach (var key in adj.Keys) {
            foreach (var node in adj[key]) {
                inDegree[node]++;
            }
        }
        
        Queue<int> q = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0) q.Enqueue(i);
        }
        
        List<int> ans = new List<int>();
        while (q.Count > 0) {
            int node = q.Dequeue();
            ans.Add(node);
            if (adj.ContainsKey(node)) {
                foreach (var ngbr in adj[node]) {
                    inDegree[ngbr]--;
                    if (inDegree[ngbr] == 0) q.Enqueue(ngbr);
                }
            }
        }
        
        ans.Reverse();
        return ans.Count == numCourses ? ans.ToArray() : new int[0];
    }
}