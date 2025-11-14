public class Solution {
    public int Calculate(string s) {
        int result = 0, num = 0, sign = 1;
        Stack<int> st = new();

        for(int i = 0; i<s.Length;i++)
        {
            if(s[i] == ' ')
            {
                continue;
            }
            if(s[i]-'0' >= 0 && s[i]-'0'<=9)
            {
                num = num * 10 + (s[i]-'0');
            }
            else if (s[i] == '+')
            {
                result += num*sign;
                sign = 1;
                num = 0;
            }
            else if (s[i] == '-')
            {
                result += num * sign;
                sign = -1;
                num = 0;
            }
            else if (s[i] == '(')
            {
                num = 0;
                st.Push(result);
                st.Push(sign);
                sign = 1;
                result = 0;
            }
            else
            {
                result += sign * num;
                num = 0;
                if(st.Count>0)
                {
                    result = result * st.Pop();
                    result += st.Pop();
                }
                sign = 1;
            }
        }
        if(num > 0 )
        {
            result += num*sign;
        }
        return result;
    }
}