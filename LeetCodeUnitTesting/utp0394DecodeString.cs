using p394DecodeString;
using System.Collections.Generic;
using Xunit;

namespace LeetCodeUnitTesting
{
    public class utp0394DecodeString
    {
        [Fact]
        public void GetHead()
        {
            Solution dec = new Solution();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.Equal(str1, dec.GetHead(str1, ref pos));
            Assert.Equal(str1.Length, pos);

            string str2 = "amcis2[k]a5[hg3[ft]]";
            Assert.Equal("amcis2[", dec.GetHead(str2, ref pos));
            Assert.Equal(6, pos);
        }

        [Fact]
        public void ExtractToken()
        {
            Solution dec = new Solution();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.Equal(str1, dec.ExtractToken(str1, ref pos));
            Assert.Equal(str1.Length, pos);

            string str2 = "2[k]a5[hg3[ft]]";
            Assert.Equal("2[k]", dec.ExtractToken(str2, ref pos));
            Assert.Equal(4, pos);

        }

        [Fact] //Vemos que la asignación de strings es una copia.
        public void RefStrings()
        {
            string a = "aaa";
            string b = a;
            a = "bbb";
            Assert.NotEqual(a, b);
        }

        [Fact]
        public void Tokenize()
        {
            Solution dec = new Solution();
            string str2 = "amcis2[k]a5[hg3[ft]]";
            List<string> tokens = dec.Tokenize(str2);
            Assert.Equal("amcis", tokens[0]);
            Assert.Equal("2[k]", tokens[1]);
            Assert.Equal("a", tokens[2]);
            Assert.Equal("5[hg3[ft]]", tokens[3]);

            string str3 = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";
            tokens = dec.Tokenize(str3);
            Assert.Equal("3[z]", tokens[0]);
            Assert.Equal("2[2[y]pq4[2[jk]e1[f]]]", tokens[1]);
            Assert.Equal("ef", tokens[2]);
        }

        [Fact]
        public void RepeatString()
        {
            Solution dec = new Solution();
            Assert.Equal("foofoofoo", dec.RepeatString(3, "foo"));
        }
        
        [Fact]
        public void ExtractConstantToken()
        {
            Solution dec = new Solution();
            string str1 = "asdfdshj";
            int pos = 0;
            Assert.Equal(str1, dec.ExtractConstantToken(str1, ref pos));
            Assert.Equal(str1.Length, pos);

            string str2 = "amcis2[k]";
            Assert.Equal("amcis", dec.ExtractConstantToken(str2, ref pos));
            Assert.Equal(5, pos);

            string str3 = "a5[hg3[ft]]";
            Assert.Equal("a", dec.ExtractConstantToken(str3, ref pos));
            Assert.Equal(1, pos);
        }

        [Fact]
        public void GetNumbers()
        {
            Solution dec = new Solution();
            int pos = 0;

            string str2 = "amcis2[k]";
            pos = 5;
            Assert.Equal("2", dec.GetNumbers(str2, ref pos));
            Assert.Equal(6, pos);

            string str3 = "a52[hg3[ft]]";
            pos = 1;
            Assert.Equal("52", dec.GetNumbers(str3, ref pos));
            Assert.Equal(3, pos);
        }

        [Fact]
        public void DecodeToken()
        {
            Solution dec = new Solution();
            string str1 = "asdfdshj";
            Assert.Equal(str1, dec.DecodeToken(str1));

            string str2 = "2[k]";
            Assert.Equal("kk", dec.DecodeToken(str2));

            string str3 = "5[hg3[ft]]";
            Assert.Equal("hgftftfthgftftfthgftftfthgftftfthgftftft", dec.DecodeToken(str3));
        }

        [Fact]
        public void DecodeString()
        {
            Solution dec = new Solution();
            string str4 = "2[jk]e1[f]";
            Assert.Equal("jkjkef", dec.DecodeString(str4));

            string str1 = "2[abc]3[cd]ef";
            Assert.Equal("abcabccdcdcdef", dec.DecodeString(str1));

            string str3 = "2[y]pq4[2[jk]e1[f]]";
            Assert.Equal("yypqjkjkefjkjkefjkjkefjkjkef", dec.DecodeString(str3));

            string str2 = "3[z]2[2[y]pq4[2[jk]e1[f]]]ef";
            Assert.Equal("zzzyypqjkjkefjkjkefjkjkefjkjkefyypqjkjkefjkjkefjkjkefjkjkefef", dec.DecodeString(str2));

            string str5 = string.Empty;
            Assert.Equal(string.Empty, dec.DecodeString(str5));
        }
    }
}
