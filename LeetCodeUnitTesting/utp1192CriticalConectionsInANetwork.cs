using Microsoft.VisualStudio.TestTools.UnitTesting;
using p1192CriticalConectionsInANetwork;
using System.Collections.Generic;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class utp1192CriticalConectionsInANetwork
    {
        [TestMethod]
        public void DescriptionTest()
        {
            IList<IList<int>> conections = new List<IList<int>>
            {
                new List<int> {0, 1},
                new List<int> {1, 2},
                new List<int> {2, 0},
                new List<int> {1, 3}
            };
            Solution solution = new Solution();
            var sol = solution.CriticalConnections(4, conections);
        }

    }
}
