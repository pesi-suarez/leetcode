using System;
using System.Collections.Generic;
using System.Linq;

namespace p0994RottingOranges
{
    public class Solution
    {
        //Accepted solution, ft 98.74%
        private enum State
        {
            Empty = 0,
            Fresh = 1,
            Rotten = 2
        }

        private class Coordinate
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        public int OrangesRotting(int[][] grid)
        {
            int minutes = 0;
            List<Coordinate> currentRotten = new List<Coordinate>();
            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                    if (grid[i][j] == (int)State.Rotten)
                        currentRotten.Add(new Coordinate { X = i, Y = j });

            int initialFreshCount = grid.Sum(arr => arr.Count(elem => elem == (int)State.Fresh));
            int initialRottenCount = currentRotten.Count;
            int rottenCount = initialRottenCount;

            while (currentRotten.Count != 0)
            {
                List<Coordinate> newRotten = new List<Coordinate>();
                foreach (Coordinate coordinate in currentRotten)
                {
                    int i = coordinate.X;
                    int j = coordinate.Y;
                    if (j > 0 && grid[i][j - 1] == (int)State.Fresh)
                    {
                        grid[i][j - 1] = (int)State.Rotten;
                        newRotten.Add(new Coordinate { X = i, Y = j - 1 });
                    }
                    if (i > 0 && grid[i - 1][j] == (int)State.Fresh)
                    {
                        grid[i - 1][j] = (int)State.Rotten;
                        newRotten.Add(new Coordinate { X = i - 1, Y = j });
                    }
                    if (j < grid[0].Length - 1 && grid[i][j + 1] == (int)State.Fresh)
                    {
                        grid[i][j + 1] = (int)State.Rotten;
                        newRotten.Add(new Coordinate { X = i, Y = j + 1 });
                    }
                    if (i < grid.Length - 1 && grid[i + 1][j] == (int)State.Fresh)
                    {
                        grid[i + 1][j] = (int)State.Rotten;
                        newRotten.Add(new Coordinate { X = i + 1, Y = j });
                    }
                }
                if (newRotten.Count > 0)
                    minutes++;
                currentRotten = newRotten;
                rottenCount += newRotten.Count;
            }
            return (rottenCount - initialRottenCount == initialFreshCount) ? minutes : -1;
        }

    }
}
