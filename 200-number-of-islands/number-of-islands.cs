public class Solution 
{
    public int NumIslands(char[][] grid) 
    {
        int count = 0;

        for (int col = 0; col < grid.Length; col++)
        {
            for (int row = 0; row < grid[0].Length; row++)
            {
                if (grid[col][row] == '1')
                {
                    count++;
                    Search(grid, col, row);
                }
            }
        }

        return count;
    }

    private void Search(char[][] grid, int col, int row)
    {
        if (grid[col][row] == '1')
        {
            grid[col][row] = '0';
        }
        else
        {
            return;
        }

        if (col < grid.Length - 1)
        {
            Search(grid, col + 1, row);
        }

        if (col > 0)
        {
            Search(grid, col - 1, row);
        }

        if (row < grid[0].Length - 1)
        {
            Search(grid, col, row + 1);
        }

        if (row > 0)
        {
            Search(grid, col, row - 1);
        }
    }  
}