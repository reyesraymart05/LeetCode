public class Solution {
    public Node CloneGraph(Node node) {
        if (node is null) return null;
        var queue = new Queue<Node>();
        var visited = new Dictionary<Node, (Node, bool)>();
        queue.Enqueue(node);
        visited.Add(node, (new Node(node.val), false));

        while (queue.Any()) {
            var current = queue.Dequeue();
            var copy = visited[current].Item1;

            foreach (var neighbor in current.neighbors) {
                if (!visited.ContainsKey(neighbor))
                    visited.Add(neighbor, (new Node(neighbor.val), false));

                copy.neighbors.Add(visited[neighbor].Item1);

                if (!visited[neighbor].Item2 && !queue.Contains(neighbor))
                    queue.Enqueue(neighbor);
            }

            visited[current] = (visited[current].Item1, true);
        }

        return visited[node].Item1;
    }
}