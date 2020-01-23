using System;

/* NOTA: 
 * Tardé menos de 10 minutos en resolver el problema con la solución más simple (cuadrática).
 * Me dice que es más rápido que el 44% de los envíos y ocupa menos espacio que el 5% de los envíos.
 * La versión que ordena primero es más rápida que el 53% de los envíos y ocupa menos espacio que el 5% de los envíos.
 */

//TODO: Mirar la solución óptima.
namespace p1TwoSum
{
    public class Solution
    {
        public int[] TwoSumTrivial(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }
            //Está garantizado que siempre habrá solución.
            return null;
        }

        private class Item : IComparable<Item>
        {
            public int Value { get; set; }
            public int OriginalIndex { get; set; }

            public int CompareTo(Item other)
            {
                return this.Value - other.Value;
            }
        }

        //Ordenando primero
        public int[] TwoSum(int[] nums, int target)
        {
            //Guardamos los índices originales, que son los que hay que devolver y se pierden al ordenar.
            //No me vale un diccionario, ya que las claves no son únicas
            Item[] nums2 = new Item[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                nums2[i] = new Item { Value = nums[i], OriginalIndex = i };
            //Ordenamos
            Array.Sort(nums2);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums2[i].Value + nums2[j].Value > target)
                        break;
                    if (nums2[i].Value + nums2[j].Value == target)
                        return new int[] { nums2[i].OriginalIndex, nums2[j].OriginalIndex };
                }
            }
            return null;
        }
    }
}
