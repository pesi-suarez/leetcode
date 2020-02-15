using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NOTA: Mi primera idea fue recorrer la matriz linealmente y asignar la isla en función de la isla de lo que hubiera ya asignado. Pero por ejemplo falla para matricces del estilo:
/*
 * 1 0 0 1 0
 * 1 1 1 1 0
 * 1 0 0 1 1
 * 1 0 0 0 0
 */
//En este caso el elemento (0,0) y el elemento (0,3) se asignarían (de forma incorrecta) a islas diferentes.

/* Mi segunda aproximación sí que funcionó y fue aceptada. Básicamente consiste en avanzar hasta llegar a una isla, recorrerla recursivamente marcando las casillas visitadas y terminada la recursión avanzar hasta la siguiente isla y repetir. Obtuve un tiempo mejor que el 93.95% de los envíos y una memoria menor que el 6.67% de los envíos.
 * Cometí errores al trabajar con las matrices en C#, intercambiando las dimensiones, o poniendo > 0 y no >= 0 en el paso recursivo.
 */

namespace p200NumberOfIslands
{
    public class Solution
    {
        private char[][] _grid;
        private int horizontalLength;
        private int verticalLength;
        private int?[,] map;

        public int NumIslands(char[][] grid)
        {
            _grid = grid;
            horizontalLength = _grid.Length;
            if (horizontalLength == 0)
                return 0;
            verticalLength = _grid[0].Length;
            map = new int?[horizontalLength, verticalLength];
            int islandCounter = 0;
            for (int i = 0; i < horizontalLength; i++)
            {
                for (int j = 0; j < verticalLength; j++)
                {
                    if (_grid[i][j] == '1' && map[i,j] == null)
                    {
                        islandCounter++;
                        map[i, j] = islandCounter;
                        if (j + 1 < verticalLength)
                            Explore(i, j + 1, islandCounter);
                        if (i + 1 < horizontalLength)
                            Explore(i + 1, j, islandCounter);
                    }
                }
            }
            return islandCounter;
        }

        private void Explore(int i, int j, int islandCounter)
        {
            if (_grid[i][j] == '1' && map[i,j] == null)
            {
                map[i, j] = islandCounter;
                if (j + 1 < verticalLength)
                    Explore(i, j + 1, islandCounter);
                if (i + 1 < horizontalLength)
                    Explore(i + 1, j, islandCounter);
                if (j - 1 >= 0)
                    Explore(i, j - 1, islandCounter);
                if (i - 1 >= 0)
                    Explore(i - 1, j, islandCounter);
            }
        }

    }
}
