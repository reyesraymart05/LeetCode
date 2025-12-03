public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var g = new List<int>[numCourses];
        foreach(var pair in prerequisites)
        {
            if (g[pair[0]] == null)
                g[pair[0]] = new List<int>() { pair[1] };
            else
                g[pair[0]].Add(pair[1]);
        }

        var color = new int[numCourses];
        bool Go(int vertex)
        {
            if (color[vertex] == 2)
                return false;
            if (color[vertex] == 1)
                return true;
            color[vertex] = 1;

            if (g[vertex] != null)
                foreach (var next in g[vertex])
                    if (Go(next))
                        return true;

            color[vertex] = 2;
            return false;
        }

        for (int i = 0; i < numCourses; i++)
            if (color[i] == 0)
                if (Go(i))
                    return false;

        return true;
    }
}