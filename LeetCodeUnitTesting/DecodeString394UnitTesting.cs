using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeClassLibrary;
using System.Collections.Generic;

namespace LeetCodeUnitTesting
{
    [TestClass]
    public class DecodeString394UnitTesting
    {
        [TestMethod]
        public void GetHead()
        {
            DecodeString394 dec = new DecodeString394();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.AreEqual(str1, dec.GetHead(str1, ref pos));
            Assert.AreEqual(str1.Length, pos);

            string str2 = "amcis2[k]a5[hg3[ft]]";
            Assert.AreEqual("amcis2[", dec.GetHead(str2, ref pos));
            Assert.AreEqual(6, pos);
        }

        [TestMethod]
        public void ExtractToken()
        {
            DecodeString394 dec = new DecodeString394();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.AreEqual(str1, dec.ExtractToken(str1, ref pos));
            Assert.AreEqual(str1.Length, pos);

            string str2 = "amcis2[k]a5[hg3[ft]]";
            Assert.AreEqual("amcis2[k]", dec.ExtractToken(str2, ref pos));
            Assert.AreEqual(8, pos);

        }

        [TestMethod] //Vemos que la asignación de strings es una copia.
        public void RefStrings()
        {
            string a = "aaa";
            string b = a;
            a = "bbb";
            Assert.AreNotEqual(a, b);
        }

        [TestMethod]
        public void Tokenize()
        {
            DecodeString394 dec = new DecodeString394();
            string str2 = "amcis2[k]a5[hg3[ft]]";
            List<string> tokens = dec.Tokenize(str2);
            Assert.AreEqual("amcis2[k]", tokens[0]);
            Assert.AreEqual("a5[hg3[ft]]", tokens[1]);
        }
    }
}
