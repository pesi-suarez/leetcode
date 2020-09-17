using p0937ReorderDataInLogFiles;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0937ReorderDataInLogFiles
    {
        [Fact]
        public void DescriptionTests()
        {
            Solution solution = new Solution();
            string[] logs = { "dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero" };
            string[] expected = { "let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6" };
            string[] result = solution.ReorderLogFiles(logs);
            Assert.Equal(expected, result);
        }

    }
}
