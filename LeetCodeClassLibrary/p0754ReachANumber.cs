using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p754ReachANumber
{
    //Está dando exceso en el tiempo de ejecución. Tal vez no hace falta usar un backtracking
    //Efectivamente, para generar target=1000 se está bastante tiempo
    public class Solution
    {
        //Backtracking
        public int ReachNumber(int target)
        {
            int nSteps = 0;
            while (!CanBeGenerated(target, nSteps))
                nSteps++;
            return nSteps;
        }

        private bool CanBeGenerated(int target, int nSteps)
        {
            if (nSteps == 0)
                return false;
            else
                return Backtracking(target, nSteps, 0, 0);
        }

        private bool Backtracking(int target, int maxSteps, int stepsCounter, int currentVal)
        {
            if (stepsCounter > maxSteps)
                return false;
            else if (target == currentVal)
                return true;
            else
                return Backtracking(target, maxSteps, stepsCounter + 1, currentVal + stepsCounter + 1) ||
                Backtracking(target, maxSteps, stepsCounter + 1, currentVal - stepsCounter - 1);
        }

    }
}
