﻿using System;
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
            problem394DecodeString dec = new problem394DecodeString();
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
            problem394DecodeString dec = new problem394DecodeString();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.AreEqual(str1, dec.ExtractToken(str1, ref pos));
            Assert.AreEqual(str1.Length, pos);

            string str2 = "2[k]a5[hg3[ft]]";
            Assert.AreEqual("2[k]", dec.ExtractToken(str2, ref pos));
            Assert.AreEqual(4, pos);

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
            problem394DecodeString dec = new problem394DecodeString();
            string str2 = "amcis2[k]a5[hg3[ft]]";
            List<string> tokens = dec.Tokenize(str2);
            Assert.AreEqual("amcis", tokens[0]);
            Assert.AreEqual("2[k]", tokens[1]);
            Assert.AreEqual("a", tokens[2]);
            Assert.AreEqual("5[hg3[ft]]", tokens[3]);

            string str3 = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";
            tokens = dec.Tokenize(str3);
            Assert.AreEqual("3[z]", tokens[0]);
            Assert.AreEqual("2[2[y]pq4[2[jk]e1[f]]]", tokens[1]);
            Assert.AreEqual("ef", tokens[2]);
        }

        [TestMethod]
        public void RepeatString()
        {
            problem394DecodeString dec = new problem394DecodeString();
            Assert.AreEqual("foofoofoo", dec.RepeatString(3, "foo"));
        }
        
        [TestMethod]
        public void ExtractConstantToken()
        {
            problem394DecodeString dec = new problem394DecodeString();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.AreEqual(str1, dec.ExtractConstantToken(str1, ref pos));
            Assert.AreEqual(str1.Length, pos);

            string str2 = "amcis2[k]";
            Assert.AreEqual("amcis", dec.ExtractConstantToken(str2, ref pos));
            Assert.AreEqual(5, pos);

            string str3 = "a5[hg3[ft]]";
            Assert.AreEqual("a", dec.ExtractConstantToken(str3, ref pos));
            Assert.AreEqual(1, pos);
        }

        [TestMethod]
        public void GetNumbers()
        {
            problem394DecodeString dec = new problem394DecodeString();
            int pos = 0;

            string str2 = "amcis2[k]";
            pos = 5;
            Assert.AreEqual("2", dec.GetNumbers(str2, ref pos));
            Assert.AreEqual(6, pos);

            string str3 = "a52[hg3[ft]]";
            pos = 1;
            Assert.AreEqual("52", dec.GetNumbers(str3, ref pos));
            Assert.AreEqual(3, pos);
        }

        [TestMethod]
        public void DecodeToken()
        {
            problem394DecodeString dec = new problem394DecodeString();
            string str1 = "asdfdshj";
            Assert.AreEqual(str1, dec.DecodeToken(str1));

            string str2 = "2[k]";
            Assert.AreEqual("kk", dec.DecodeToken(str2));

            string str3 = "5[hg3[ft]]";
            Assert.AreEqual("hgftftfthgftftfthgftftfthgftftfthgftftft", dec.DecodeToken(str3));
        }

        [TestMethod]
        public void DecodeString()
        {
            problem394DecodeString dec = new problem394DecodeString();
            string str4 = "2[jk]e1[f]";
            Assert.AreEqual("jkjkef", dec.DecodeString(str4));

            string str1 = "2[abc]3[cd]ef";
            Assert.AreEqual("abcabccdcdcdef", dec.DecodeString(str1));

            string str3 = "2[y]pq4[2[jk]e1[f]]";
            Assert.AreEqual("yypqjkjkefjkjkefjkjkefjkjkef", dec.DecodeString(str3));

            string str2 = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";
            Assert.AreEqual("zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef", dec.DecodeString(str2));

            string str5 = string.Empty;
            Assert.AreEqual(string.Empty, dec.DecodeString(str5));
        }
    }
}
