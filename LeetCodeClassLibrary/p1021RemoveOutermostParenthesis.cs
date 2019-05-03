using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1021RemoveOutermostParenthesis
{
    public class Solution
    {
        public string RemoveOuterParentheses(string S)
        {
            StringBuilder resultBuilder = new StringBuilder();
            int openingCounter = 0;
            int startingIndex = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '(')
                    openingCounter++;
                else
                    openingCounter--;
                if (openingCounter == 0)
                {
                    resultBuilder.Append(S.Substring(startingIndex + 1, i - startingIndex - 1));
                    startingIndex = i + 1;
                }
            }
            return resultBuilder.ToString();
        }
    }
}
