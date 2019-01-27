using Microsoft.VisualStudio.TestTools.UnitTesting;
using p807MaxIncreaseToKeepCitySkyline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp807MaxIncreaseToKeepCitySkyline
    {
        [TestMethod]
        public void GivenTest()
        {
            int[][] grid = new int[4][];
            grid[0] = new int[] { 3, 0, 8, 4 };
            grid[1] = new int[] { 2, 4, 5, 7 };
            grid[2] = new int[] { 9, 2, 6, 3 };
            grid[3] = new int[] { 0, 3, 1, 0 };

            Solution solution = new Solution();
            Assert.AreEqual(35, solution.MaxIncreaseKeepingSkyline(grid));
        }
    }
}

/*
 
  [3, 0, 8, 4], 
  [2, 4, 5, 7],
  [9, 2, 6, 3],
  [0, 3, 1, 0]
  */
