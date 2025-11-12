using System;
using System.Collections.Generic;

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new();

        foreach (string token in tokens)
        {
            if (token is "+" or "-" or "*" or "/")
            {
                int right = stack.Pop();
                int left = stack.Pop();
                int result = token switch
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => left / right,
                    _ => throw new ArgumentOutOfRangeException(nameof(token))
                };
                stack.Push(result);
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }
}