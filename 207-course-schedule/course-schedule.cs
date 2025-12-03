public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        //[2] --> [1,3] i.e currCourse -> all preReq
        var map = new Dictionary<int, List<int>>();

        var visited = new HashSet<int>();

        for(int i=0; i<numCourses; i++){
            map.Add(i, new List<int>());
        }

        foreach(int[]p in prerequisites){
            int courseToTake = p[0];
            int courseDependsOn = p[1];

            map[courseToTake].Add(courseDependsOn); // using .Add since its a list

        }

        //iterate on all courses -- iteratimg like this since map can be disconnected
        //1 --> 2
        //3--> 4
        foreach(int n in Enumerable.Range(0, numCourses)){
           if(!dfs(n,map,visited)){
               return false;
           }
        }

        return true;
    }

    public bool dfs(int n, Dictionary<int, List<int>> map, HashSet<int> visited){
        if(visited.Contains(n)){
            return false;
        }

        if(map[n]== new List<int>()) return true;

        visited.Add(n); // Adding current node to set
        foreach(int i in map[n]){
            if(!dfs(i,map, visited)){
                return false;
            }
        }
        visited.Remove(n);
        map[n] = new List<int>();
        return true;
    }
}