using System.Collections.Generic;

namespace LeetCodeClassLibrary
{
    public class DecodeString394
    {
        /*
        public string DecodeString(string str)
        {

        }
        */

        public List<string> Tokenize(string str)
        {
            List<string> result = new List<string>();
            int pos = 0;
            string workingStr = str;
            while (pos != workingStr.Length-1)
            {
                result.Add(ExtractToken(workingStr, ref pos));
                if (pos != workingStr.Length-1)
                    workingStr = workingStr.Substring(pos+1);
            }
            return result;
        }

        public string ExtractToken(string str, ref int pos)
        {
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
                        pos = i;
                        return head + tail;
                    }
                }
            }

            return string.Empty; //Will never get here.
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
