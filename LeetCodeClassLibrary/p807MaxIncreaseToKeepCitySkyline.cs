using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p807MaxIncreaseToKeepCitySkyline
{
    public class Solution
    {
        private int[][] Grid;
        private int[] VerticalSkyline;
        private int[] HorizontalSkyline;

        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            Grid = grid;

            GenerateVerticalSkyline();
            GenerateHorizontalSkyline();

            return GetMaxIncrease();
        }

        private void GenerateVerticalSkyline()
        {
            VerticalSkyline = new int[Grid[0].Length];
            for (int i = 0; i < VerticalSkyline.Length; i++)
                VerticalSkyline[i] = GetColumn(Grid, i).Max();
        }

        private void GenerateHorizontalSkyline()
        {
            HorizontalSkyline = new int[Grid.Length];
            for (int i = 0; i < HorizontalSkyline.Length; i++)
                HorizontalSkyline[i] = GetRow(Grid, i).Max();
        }

        private int GetMaxIncrease()
        {
            int result = 0;
            for (int i = 0; i < Grid.Length; i++)
                for (int j = 0; j < Grid.GetLength(0); j++)
                    result += Math.Min(HorizontalSkyline[i], VerticalSkyline[j]) - Grid[i][j];
            return result;
        }

        //Adapted from https://stackoverflow.com/a/51241629/7031051
        public int[] GetColumn(int[][] matrix, int columnNumber)
        {
            return Enumerable.Range(0, Grid[0].Length)
                    .Select(x => matrix[x][columnNumber])
                    .ToArray();
        }

        public int[] GetRow(int[][] matrix, int rowNumber)
        {
            return Enumerable.Range(0, Grid.Length)
                    .Select(x => matrix[rowNumber][x])
                    .ToArray();
        }

    }
}

/*
//PHP Version:
class Solution {
    function maxIncreaseKeepingSkyline($grid) {
        $N = count($grid);
        $M = count($grid[0]);
        $rowMaxes = array_fill(0, $N, 0);
        $colMaxes = array_fill(0, $M, 0);
        
        for ($i = 0; $i< $N; $i++) {
            for ($j = 0; $j< $M; $j++) {
                $rowMaxes[$i] = max($rowMaxes[$i], $grid[$i][$j]);
            }
        }

        for ($j = 0; $j< $M; $j++) {
            for ($i = 0; $i< $N; $i++) {
                $colMaxes[$i] = max($colMaxes[$i], $grid[$i][$j]);
            }
        }
        
        $ans = 0;
        for ($i = 0; $i< $N; $i++) {
            for ($j = 0; $j< $M; $j++) {
                $ans += min($rowMaxes[$i], $colMaxes[$j]) - $grid[$i][$j];
            }
        }
        
        return $ans;
    }
}     
*/