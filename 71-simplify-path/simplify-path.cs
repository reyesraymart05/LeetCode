public class Solution 
{
    public string SimplifyPath(string path)
    {
        var stack = new Stack<string>();
        var parts = path.Split('/');
        foreach (var part in parts)
        {
            if (part == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (part != "." && part != "")
            {
                stack.Push(part);
            }
        }
        var result = new StringBuilder();
        while (stack.Count > 0)
        {
            result.Insert(0, stack.Pop());
            result.Insert(0, "/");
        }
        return result.Length == 0 ? "/" : result.ToString();
    }
}