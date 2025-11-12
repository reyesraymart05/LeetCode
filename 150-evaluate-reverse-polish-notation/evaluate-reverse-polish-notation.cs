public class Solution {
    int tokenIndex = 0;
    public int EvalRPN(ReadOnlySpan<string> tokens) {
        string token = tokens[^(++tokenIndex)];
        if (token == "+") {
            // Plus
            int a = EvalRPN(tokens);
            int b = EvalRPN(tokens);
            return b + a;
        } else if (token == "-") {
            // Mins
            int a = EvalRPN(tokens);
            int b = EvalRPN(tokens);
            return b - a;
        } else if (token == "*") {
            // Multiply
            int a = EvalRPN(tokens);
            int b = EvalRPN(tokens);
            return b * a;
        } else if (token == "/") {
            // Divide
            int a = EvalRPN(tokens);
            int b = EvalRPN(tokens);
            return b / a;
        } else {
            return int.Parse(token);
        }
    }
}