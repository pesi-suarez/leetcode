using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p200NumberOfIslands;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp0200NumberOfIslands
    {
        [TestMethod]
        public void DescriptionTest00()
        {
            char[][] data = new char[][]
            {
            new char[] {'1', '1', '1', '1', '0'},
            new char[] {'1', '1', '0', '1', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '0', '0', '0'}
            };

            Solution solution = new Solution();
            Assert.AreEqual(1, solution.NumIslands(data));
        }

        [TestMethod]
        public void DescriptionTest01()
        {
            char[][] data = new char[][]
            {
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'1', '1', '0', '0', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
            };

            Solution solution = new Solution();
            Assert.AreEqual(3, solution.NumIslands(data));
        }

        [TestMethod]
        public void Trivial00()
        {
            char[][] data = new char[][]
            {
            };

            Solution solution = new Solution();
            Assert.AreEqual(0, solution.NumIslands(data));
        }

        [TestMethod]
        public void Trivial01()
        {
            char[][] data = new char[][]
            {
                new char[] {'1'}
            };

            Solution solution = new Solution();
            Assert.AreEqual(1, solution.NumIslands(data));
        }

        [TestMethod]
        public void UShapedIsland()
        {
            char[][] data = new char[][]
            {
            new char[] {'1', '0', '0', '1', '0'},
            new char[] {'1', '1', '1', '1', '0'},
            new char[] {'0', '0', '1', '0', '0'},
            new char[] {'0', '0', '0', '1', '1'}
            };

            Solution solution = new Solution();
            Assert.AreEqual(2, solution.NumIslands(data));
        }

    }
}
