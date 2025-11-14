public class Solution {

        public int Calculate(string s)
        {
            int result = 0;
            int i = 0;
            Stack<int> stack = new Stack<int>();
            int sign = 1;
            int num = 0;
            while (i < s.Length)
            {
                switch (s[i])
                {
                    case '+':
                        sign = 1;
                        break;
                    case '-':
                        sign = -1;
                        break;
                    case '(':
                        stack.Push(result);
                        stack.Push(sign);
                        result = 0;
                        sign = 1;
                        break;
                    case ')':
                        int lastSign = stack.Pop();
                        result *= lastSign;
                        int lastNum = stack.Pop();
                        result += lastNum;

                        break;
                    case ' ':
                        break;
                    default:
                        if (char.IsDigit(s[i]))
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append(s[i]);
                            while (i+1 < s.Length && char.IsDigit(s[i+1]))
                            {
                                stringBuilder.Append(s[++i]);
                            }

                            num = int.Parse(stringBuilder.ToString());
                            num *= sign;
                            result+=num;
                            sign = 1;
                        }
                        break;
                }
                i++;
            }

            return result;
        }
      
}