using System.Linq;

namespace p0994RottingOranges
{
    public class Solution
    {
        //Accepted answer (ft 6.20%)
        //O(n^2) solution, could be improved.
        private enum State
        {
            NoOrange = 0,
            FreshOrange = 1,
            RottenOrange = 2
        }

        private class Result
        {
            public int[][] Grid { get; set; }
            public int Rotten { get; set; }
        }

        public int OrangesRotting(int[][] grid)
        {
            int initialFreshOrangeCount = grid.Sum(arr => arr.Count(elem => elem == (int)State.FreshOrange));
            if (initialFreshOrangeCount == 0)
                return 0;
            int initialRottenOrangeCount = grid.Sum(arr => arr.Count(elem => elem == (int)State.RottenOrange));
            if (initialRottenOrangeCount == 0)
                return -1;
            int previousRottenOrangeCount = initialRottenOrangeCount;
            int minuteCounter = 0;
            Result result = PassMinute(grid);
            int newRottenOrangeCount = initialRottenOrangeCount + result.Rotten;
            while (newRottenOrangeCount != previousRottenOrangeCount)
            {
                minuteCounter++;
                result = PassMinute(result.Grid);
                previousRottenOrangeCount = newRottenOrangeCount;
                newRottenOrangeCount += result.Rotten;
            }

            return (newRottenOrangeCount - initialRottenOrangeCount == initialFreshOrangeCount) ? minuteCounter : -1;
        }

        private Result PassMinute(int[][] grid)
        {
            Result result = new Result { Grid = GridCopy(grid) };
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == (int)State.RottenOrange)
                    {
                        result.Rotten += RotLeft(grid, result.Grid, i, j);
                        result.Rotten += RotUp(grid, result.Grid, i, j);
                        result.Rotten += RotRight(grid, result.Grid, i, j);
                        result.Rotten += RotDown(grid, result.Grid, i, j);
                    }
                    //No need for considering other cases, thanks to Clone()
                }
            }
            return result;
        }

        private int[][] GridCopy(int[][] grid)
        {
            int[][] copy = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                copy[i] = new int[grid[0].Length];
                for (int j = 0; j < grid[0].Length; j++)
                {
                    copy[i][j] = grid[i][j];
                }
            }
            return copy;
        }

        private int RotLeft(int[][] grid, int[][] resultGrid, int i, int j)
        {
            if (j > 0 && grid[i][j-1] == (int)State.FreshOrange && resultGrid[i][j-1] != (int)State.RottenOrange)
            {
                resultGrid[i][j - 1] = (int)State.RottenOrange;
                return 1;
            }
            return 0;
        }

        private int RotUp(int[][] grid, int[][] resultGrid, int i, int j)
        {
            if (i > 0 && grid[i-1][j] == (int)State.FreshOrange && resultGrid[i-1][j] != (int)State.RottenOrange)
            {
                resultGrid[i - 1][j] = (int)State.RottenOrange;
                return 1;
            }
            return 0;
        }

        private int RotRight(int[][] grid, int[][] resultGrid, int i, int j)
        {
            if (j < grid[0].Length-1 && grid[i][j+1] == (int)State.FreshOrange && resultGrid[i][j+1] != (int)State.RottenOrange)
            {
                resultGrid[i][j + 1] = (int)State.RottenOrange;
                return 1;
            }
            return 0;
        }

        private int RotDown(int[][] grid, int[][] resultGrid, int i, int j)
        {
            if (i < grid.Length-1 && grid[i+1][j] == (int)State.FreshOrange && resultGrid[i+1][j] != (int)State.RottenOrange)
            {
                resultGrid[i + 1][j] = (int)State.RottenOrange;
                return 1;
            }
            return 0;
        }

    }
}
