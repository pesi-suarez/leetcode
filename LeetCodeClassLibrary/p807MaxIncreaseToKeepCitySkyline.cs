﻿using System;
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
