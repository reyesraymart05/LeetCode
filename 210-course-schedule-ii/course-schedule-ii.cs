public class Topo{
    int n;
    int[] degree;
    List<int>[] graph;
    
    public Topo(int n, int[][] edges){
        this.n = n;
        
        degree = new int[n];
        graph = new List<int>[n];
        for(int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach(var edge in edges){
            int u = edge[0], v = edge[1];

            graph[v].Add(u);
            degree[u]++;
        }
    }
    
    public List<int> Bfs(){
        List<int> ans = new();

        var q = new Queue<int>();
        for(int i = 0; i < n; i++){
            if(degree[i] == 0)
                q.Enqueue(i);
        }

        while(q.Count > 0){
            var u = q.Dequeue();
            ans.Add(u);

            foreach(var v in graph[u]){
                if(--degree[v] == 0)
                    q.Enqueue(v);
            }
        }

        return ans;
    }

    public List<int> Dfs(){
        List<int> ans = new();
        bool hasCycle = false;

        var check = new bool[n];
        var checkCycle = new bool[n];
        void Dfs(int u){
            if(hasCycle)
                return;

            check[u] = true;
            checkCycle[u] = true;

            foreach(var v in graph[u]){
                if(!check[v]){
                    Dfs(v);
                }
                else if(checkCycle[v]){
                    hasCycle = true;
                    return;
                }
                    
            }
            
            checkCycle[u] = false;
            ans.Add(u);
        }

        for(int i = 0; i < n; i++){
            if(!check[i])
                Dfs(i);
        }

        if(hasCycle)
            return new List<int>();

        ans.Reverse();
        return ans;
    }
}

public class Solution {
    public int[] FindOrder(int n, int[][] edges) {
        Topo t = new(n, edges);
        var ans = t.Dfs().ToArray();
        return ans;
    }
}