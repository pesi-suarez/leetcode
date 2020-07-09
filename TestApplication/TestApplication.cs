using p754ReachANumber;
using System;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            for (int i = -1000; i < 1000; i++)
            {
                Console.WriteLine($"{i}: \t\t{solution.ReachNumber(i)}");
            }
        }
    }
}
