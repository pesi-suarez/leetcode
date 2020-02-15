using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p709ToLowerCase
{
    public class Solution
    {
        //Esto es correcto y LeetCode lo acepta. De hecho es la solución más rápida (aunque puede dar más tiempo)
        /*
        public string ToLowerCase(string str)
        {
            return str.ToLower();
        }
        */

        //Esto es prácticamente equivalente
        public string ToLowerCase(string str)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(str);
            byte[] resultBytes = new byte[asciiBytes.Length];
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                if (asciiBytes[i] >= 65 && asciiBytes[i] <= 90)
                    resultBytes[i] = (byte)(asciiBytes[i] + 32);
                else
                    resultBytes[i] = asciiBytes[i];
            }
            return Encoding.Default.GetString(resultBytes);
        }

    }
}
