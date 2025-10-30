public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        //Time - O(N) Space - O(N)
        IList<int> records = new List<int>();

        //We need 4 pointers and we use 2 pointers each time we traverse a row or column.
        // 1 for starting point and 1 for ending
        int rowStart = 0; // for where the row traversal starts and reverse row traversal ends
        int colStart = 0; // from where the column traversal start and reverse column traversal ends
        int rowEnd = matrix[0].Length-1; // where the row traversal ends and from where reverse row traversal starts
        int colEnd = matrix.Length-1; // where the  column traversal ends and reverse columns traversal starts

        while(colStart <= colEnd && rowStart <= rowEnd){
            //Row traversal
            for(int i=rowStart; i<=rowEnd; i++){
                records.Add(matrix[colStart][i]); 
            }
            colStart++;
            //Column traversal
            if(colStart > colEnd) break;
            for(int j=colStart; j<=colEnd; j++){
                records.Add(matrix[j][rowEnd]);
            }            
            rowEnd--;
            //Reverse row traversal
            if(rowStart > rowEnd) break;
            for(int k=rowEnd; k>=rowStart; k--){
                records.Add(matrix[colEnd][k]);
            }
            colEnd--;
            //Reverse column traversal
            if(colStart > colEnd) break;
            for(int m=colEnd; m>=colStart; m--){
                records.Add(matrix[m][rowStart]);
            }
            rowStart++;
            if(rowStart > rowEnd) break;
        }        
        return records;
    }
}