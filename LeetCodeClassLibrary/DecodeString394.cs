using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeClassLibrary
{
    public class DecodeString394
    {
        public string DecodeString(string str)
        {
            List<string> tokens = Tokenize(str);
            List<string> decodedTokens = tokens.Select(t => DecodeToken(t)).ToList();
            return string.Join("", decodedTokens);
        }

        public string DecodeToken(string tokenStr)
        {
            if (tokenStr.Equals(string.Empty)) return tokenStr;
            else if (tokenStr[0] < '0' || tokenStr[0] > '9') return tokenStr;
            else
            {
                int pos = 0;
                string numbers = GetNumbers(tokenStr, ref pos);
                int repeats = int.Parse(numbers);
                return RepeatString(repeats, DecodeString(tokenStr.Substring(pos+1, tokenStr.Length-pos-2)));
            }
        }

        public string GetNumbers(string str, ref int pos)
        {
            int i;
            string result = string.Empty;
            for (i = pos; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9') result += str[i];
                else break;
            }
            pos = i;
            return result;
        }

        public string RepeatString(int n, string str)
        {
            if (n == 1) return str;
            else return str + RepeatString(n - 1, str);
        }

        public List<string> Tokenize(string str)
        {
            List<string> result = new List<string>();
            int pos = 0;
            string workingStr = str;
            bool condition = true;
            while (condition)
            {
                result.Add(ExtractToken(workingStr, ref pos));
                if (pos != workingStr.Length)
                    workingStr = workingStr.Substring(pos);
                else condition = false;
            }
            return result;
        }

        public string ExtractToken(string str, ref int pos)
        {
            if (str.Equals(string.Empty)) return str;
            if (str[0] < '0' || str[0] > '9')
                return ExtractConstantToken(str, ref pos);

            int headPos = 0;
            string head = GetHead(str, ref headPos);
            if (headPos == str.Length)
            {
                pos = str.Length;
                return head;
            }
            else
            {
                string tail = string.Empty;
                int bracketCounter = 1;
                for (int i = headPos+1; i < str.Length; i++)
                {
                    tail += str[i];

                    if (str[i] == '[') bracketCounter++;
                    else if (str[i] == ']') bracketCounter--;

                    if (bracketCounter == 0)
                    {
                        pos = i+1;
                        return head + tail;
                    }
                }
            }

            return string.Empty; //Will never get here.
        }

        public string ExtractConstantToken(string str, ref int pos)
        {
            int i;
            string result = string.Empty;
            for (i = 0; i < str.Length; i++)
            {
                if ((str[i] < '0' || str[i] > '9') && str[i] != ']') result += str[i];
                else break;
            }
            pos = i;
            return result;
        }

        public string GetHead(string str, ref int pos)
        {
            int i;
            string result = string.Empty;
            for (i = 0; i < str.Length; i++)
            {
                if (str[i] != '[') result += str[i];
                else break;
            }
            if (i < str.Length) result += '[';
            pos = i;
            return result;
        }
    }
}
