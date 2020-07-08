using System.Collections.Generic;

namespace p0020ValidParentheses
{
    public class Solution
    {
        //Accepted answer (ft 29.63%)
        public static readonly Dictionary<char, char> ClosingParenthesisDict = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        private class ValidParentheses
        {
            public char OpeningChar { get; set; }
            public char ClosingChar { get; set; }
            public bool Valid { get; set; }
            public int LastPosition { get; set; }

            public void Execute(string s, int startingPos)
            {
                int parenthesesCounter = 0;
                Valid = true;
                for (int i = startingPos; i < s.Length && Valid; i++)
                {
                    if (s[i] == OpeningChar)
                        parenthesesCounter++;
                    else if (s[i] == ClosingChar)
                    {
                        parenthesesCounter--;
                        if (parenthesesCounter < 0)
                            Valid = false;
                    }
                    else
                    {
                        if (parenthesesCounter == 0)
                            return;
                        else if (!ClosingParenthesisDict.ContainsKey(s[i]))
                            Valid = false;
                        else
                        {
                            ValidParentheses subProblem = new ValidParentheses
                            {
                                OpeningChar = s[i],
                                ClosingChar = ClosingParenthesisDict[s[i]]
                            };
                            subProblem.Execute(s, i);
                            Valid = subProblem.Valid;
                            i = subProblem.LastPosition;
                        }
                    }
                    LastPosition = i;
                }
                if (parenthesesCounter > 0)
                    Valid = false;
            }
        }

        public bool IsValid(string s)
        {
            if (s.Equals(string.Empty))
                return true;

            if (!ClosingParenthesisDict.ContainsKey(s[0]))
                return false;

            ValidParentheses problem = new ValidParentheses
            {
                OpeningChar = s[0],
                ClosingChar = ClosingParenthesisDict[s[0]],
            };
            problem.Execute(s, 0);
            if (!problem.Valid)
                return false;
            while (problem.LastPosition != s.Length-1)
            {
                int pos = problem.LastPosition + 1;
                if (!ClosingParenthesisDict.ContainsKey(s[pos]))
                    return false;
                problem = new ValidParentheses
                {
                    OpeningChar = s[pos],
                    ClosingChar = ClosingParenthesisDict[s[pos]],
                };
                problem.Execute(s, pos);
                if (!problem.Valid)
                    return false;
            }
            return true;
        }

        //Top answer (ft 10% when I run it):
        //Cleaner, though apparently slower.
        /*
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (current == '(' || current == '[' || current == '{')
                {
                    stack.Push(current);
                }
                else if (current == ')' || current == ']' || current == '}')
                {
                    if (stack.Count == 0) return false;
                    else
                    {
                        char previous = stack.Pop();
                        if (previous == '(' && current == ')' ||
                            previous == '[' && current == ']' ||
                            previous == '{' && current == '}')
                            continue;
                        else return false;
                    }
                }
            }
            return stack.Count == 0;
        }
        */
    }
}
