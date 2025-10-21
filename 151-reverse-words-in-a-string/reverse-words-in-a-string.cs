public class Solution {
    public string ReverseWords(string s) {
        var words = s.Split(new char[] {' '}, System.StringSplitOptions.RemoveEmptyEntries);
        System.Array.Reverse(words);
        return string.Join(" ", words);
    }
}