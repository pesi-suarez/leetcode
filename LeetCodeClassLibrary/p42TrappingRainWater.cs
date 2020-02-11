using System;
using System.Collections.Generic;
using System.Linq;

namespace p42TrappingRainWater
{
    /* NOTA: 
     * Tardé varios días en resolver el problema. Usé varias aproximaciones.
     * Los intentos fallidos están en el otro fichero, en particular una solución trivial cuadrática.
     * Me dice que es más rápido que el 14.12% de los envíos y ocupa menos espacio que el 9.09% de los envíos.
     */

    //TODO: Creo que podría acelerarlo si trato las colas de manera aislada (en los dos sentidos) y la sección central en un único sentido.
    public class Solution
    {
        private Dictionary<int, int> _leftToRigth;
        private Dictionary<int, int> _rightToLeft;

        public Solution()
        {
            _leftToRigth = new Dictionary<int, int>();
            _rightToLeft = new Dictionary<int, int>();
        }

        public int Trap(int[] height)
        {
            if (height.Length == 0)
                return 0;
            GenerateLeftToRight(height);
            GenerateRightToLeft(height);
            int waterCounter = _leftToRigth.Values.Sum();
            foreach (int key in _rightToLeft.Keys)
            {
                if (!_leftToRigth.Keys.Contains(key))
                    waterCounter += _rightToLeft[key];
            }
            return waterCounter;
        }

        public void GenerateLeftToRight(int[] height)
        {
            int length = height.Length;
            int max = height.Max();
            bool valleyFound = false;
            int valleyHeight = 0;
            int valleyWaterCounter = 0;
            int valleyMin = max;
            int valleyMinIndex = 0;
            for (int i = 1; i < length; i++)
            {
                //empieza el valle.
                if (height[i] < height[i-1] && !valleyFound)
                {
                    valleyFound = true;
                    valleyHeight = height[i - 1];
                }

                //dentro del valle.
                if (height[i] < valleyHeight && valleyFound)
                {
                    valleyWaterCounter += valleyHeight - height[i];
                    if (height[i] < valleyMin)
                    {
                        valleyMin = height[i];
                        valleyMinIndex = i;
                    }
                }

                //termina el valle.
                if (height[i] >= valleyHeight && valleyFound)
                {
                    valleyFound = false;
                    _leftToRigth.Add(valleyMinIndex, valleyWaterCounter);
                    valleyWaterCounter = 0;
                    valleyMin = max;
                }
            }
        }

        public void GenerateRightToLeft(int[] height)
        {
            int length = height.Length;
            int max = height.Max();
            bool valleyFound = false;
            int valleyHeight = 0;
            int valleyWaterCounter = 0;
            int valleyMin = max;
            int valleyMinIndex = 0;
            for (int i = length - 2; i >= 0; i--)
            {
                //empieza el valle.
                if (height[i] < height[i + 1] && !valleyFound)
                {
                    valleyFound = true;
                    valleyHeight = height[i + 1];
                }

                //dentro del valle.
                if (height[i] < valleyHeight && valleyFound)
                {
                    valleyWaterCounter += valleyHeight - height[i];
                    if (height[i] <= valleyMin)
                    {
                        valleyMin = height[i];
                        valleyMinIndex = i;
                    }
                }

                //termina el valle.
                if (height[i] >= valleyHeight && valleyFound)
                {
                    valleyFound = false;
                    _rightToLeft.Add(valleyMinIndex, valleyWaterCounter);
                    valleyWaterCounter = 0;
                    valleyMin = max;
                }
            }
        }

    }
}
