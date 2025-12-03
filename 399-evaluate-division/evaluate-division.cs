public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        var graph = new Dictionary<string, List<(string, double)>>();
        var results = new List<double>();

        BuildGraph(equations, values, graph);

        foreach (var query in queries) {
            var a = query[0];
            var b = query[1];
            var visited = new HashSet<string>();
            double result = -1.0;

            if (Dfs(a, b, visited, graph, ref result, 1.0)) {
                results.Add(result);
            } else {
                results.Add(-1.0);
            }
        }

        return results.ToArray();
    }

    void BuildGraph(IList<IList<string>> equations, double[] values, Dictionary<string, List<(string, double)>> graph) {
        for (int i = 0; i < equations.Count; i++) {
            var a = equations[i][0];
            var b = equations[i][1];
            var val = values[i];

            if (!graph.ContainsKey(a)) graph[a] = new();
            if (!graph.ContainsKey(b)) graph[b] = new();

            graph[a].Add((b, val));
            graph[b].Add((a, 1.0 / val));
        }
    }

    public bool Dfs(string curr, string target, HashSet<string> visited, Dictionary<string, List<(string, double)>> graph, ref double result, double accProduct) {
        if (!graph.ContainsKey(curr) || !graph.ContainsKey(target)) return false;
        if (curr == target) {
            result = accProduct;
            return true;
        }

        visited.Add(curr);
        foreach (var (neigh, weight) in graph[curr]) {
            if (!visited.Contains(neigh)) {
                if (Dfs(neigh, target, visited, graph, ref result, accProduct * weight)) {
                    return true;
                }
            }
        }
        return false;
    }
}