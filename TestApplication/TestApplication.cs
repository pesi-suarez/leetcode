using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p754ReachANumber;

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
