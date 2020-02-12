namespace p42TrappingRainWater
{
    /* NOTA: 
     * Tardé varios días en resolver el problema. Usé varias aproximaciones.
     * Los intentos fallidos están en el otro fichero, en particular una solución trivial cuadrática.
     * La primera idea exitosa fue recorrer el vector de izquierda a derecha y de derecha a izquierda. Detectar cuando empiezan los "valles" e incrementar el agua recogida hasta que termina el valle. Cada valle está identificado por el índice de su mínimo más a la izquierda. La cantidad de agua de cada valle se guarda en un diccionario indexado por el índice del mínimo (hay dos diccionarios, de derecha a izquierda y de izquierda a derecha). Finalmente se suman los elementos de los dos diccionarios (excluyendo las repeticiones).
     * Me dice que es más rápido que el 14.12% de los envíos y ocupa menos espacio que el 9.09% de los envíos.
     * Refiné la primera solución de tal manera que ahora únicamente la "cola" se recorre de derecha a izquierda. Esto elimina la necesidad de los diccionarios (el volumen de agua se puede incrementar según se detecta el final de un valle) y de gestionar el mínimo.
     * Me dice que es más rápido que el 38.82% de los envíos y ocupa menos espacio que el 9.09% de los envíos.
     * No entiendo cómo puede ocupar lo mismo de memoria, ¡si ya no estoy utilizando diccionarios!
     * Volví a refinar la solución, reordenando los bloques if de dentro de los bucles y haciéndolos excluyentes (sólo se entra en 1 como máximo por iteración). Además, el bloque que probablemente es más frecuente (dentro del valle) es el primero que se comprueba.
     * Me dice que es más rápido que el 98.94% de los envíos y ocupa menos espacio que el 9.09% de los envíos. ¡Qué bien!
     * Voy a volverlo a probar a ver si siempre da lo mismo o hay factores que no se pueden controlar.
     * Efectivamente, una segunda ejecución da 61.76%. Debería investigarlo, pero, ¿por qué no me puedo quedar con mi 98.94%, eh?
     */

    public class Solution
    {
        public int Trap(int[] height)
        {
            int waterCounter = 0;
            int length = height.Length;
            if (length == 0)
                return 0;
            bool valleyFound = false;
            int valleyHeight = 0;
            int valleyStartIndex = 0;
            int valleyWaterCounter = 0;
            for (int i = 1; i < length; i++)
            {
                //dentro del valle.
                if (height[i] < valleyHeight && valleyFound)
                {
                    valleyWaterCounter += valleyHeight - height[i];
                }

                //empieza el valle.
                else if (height[i] < height[i-1] && !valleyFound)
                {
                    valleyFound = true;
                    valleyHeight = height[i - 1];
                    valleyStartIndex = i - 1;
                    valleyWaterCounter += valleyHeight - height[i];
                }

                //termina el valle.
                else if (height[i] >= valleyHeight && valleyFound)
                {
                    valleyFound = false;
                    waterCounter += valleyWaterCounter;
                    valleyWaterCounter = 0;
                    valleyStartIndex = i;
                }
            }

            valleyFound = false;
            valleyHeight = 0;
            valleyWaterCounter = 0;
            for (int i = length - 2; i >= valleyStartIndex; i--)
            {
                //dentro del valle.
                if (height[i] < valleyHeight && valleyFound)
                {
                    valleyWaterCounter += valleyHeight - height[i];
                }

                //empieza el valle.
                else if (height[i] < height[i + 1] && !valleyFound)
                {
                    valleyFound = true;
                    valleyHeight = height[i + 1];
                    valleyWaterCounter += valleyHeight - height[i];
                }

                //termina el valle.
                else if (height[i] >= valleyHeight && valleyFound)
                {
                    valleyFound = false;
                    waterCounter += valleyWaterCounter;
                    valleyWaterCounter = 0;
                }
            }
            return waterCounter;
        }

    }
}
