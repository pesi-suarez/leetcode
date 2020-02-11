using System;
using System.Linq;

namespace p42TrappingRainWaterUnsuccesfulAttempts
{
    /* NOTA: 
     * Me equivoqué una vez porque no tuve en cuenta el vector vacío.
     * Luego me falló porque la solución trivial (cuadrática) tardaba demasiado
     */
    public class Solution
    {
        //NOTA: No funciona si hay un máximo "sumergido".
        //NOTA: A lo mejor puedo ordenar los índices de los máximos y luego aplicar algún tipo de estrategia recursiva. Debería dibujarlo.
        //TODO: Tengo que tener cuidado cuando los máximos locales valen lo mismo, quiero que siempre el más cercano sea hijo de su padre en el árbol. Al mismo tiempo no estoy considerando hijos con la misma altura.
        //Se podrían usar dos ordenaciones diferentes del vector de índices.

        private class IndexedItem : IComparable<IndexedItem>
        {
            public int Index { get; set; }
            public int Value { get; set; }

            public int CompareTo(IndexedItem other)
            {
                if (this.Value - other.Value == 0)
                    return this.Index - other.Index;
                else
                    return this.Value - other.Value;
            }
        }

        private class TreeNode
        {
            public IndexedItem Value { get; set; }
            public TreeNode Left{ get; set; }
            public TreeNode Right { get; set; }
        }

        public int Trap(int[] height)
        {
            bool[] localMaxes = GetLocalMaxes(height);
            IndexedItem[] indexedItems = GetIndexedItems(height, localMaxes);
            Array.Sort(indexedItems);
            Array.Reverse(indexedItems);
            TreeNode rootPointer = BuildTree(indexedItems);

            return 0;
        }

        private IndexedItem[] GetIndexedItems(int[] height, bool[] localMaxes)
        {
            IndexedItem[] result = new IndexedItem[localMaxes.Where(lm => lm).Count()];
            int j = 0;
            for (int i = 0; i < height.Length; i++)
                if (localMaxes[i])
                {
                    result[j] = new IndexedItem { Index = i, Value = height[i] };
                    j++;
                }
            return result;
        }

        private TreeNode BuildTree(IndexedItem[] indexedItems)
        {
            TreeNode root = new TreeNode { Value = indexedItems[0] };
            RecursionBuildLeft(root, indexedItems, 1);
            RecursionBuildRight(root, indexedItems, 1);
            return root;
        }

        private void RecursionBuildLeft(TreeNode node, IndexedItem[] indexedItems, int i)
        {
            int j = i;
            while (j < indexedItems.Length)
            {
                if (indexedItems[j].Index < node.Value.Index)
                {
                    node.Left = new TreeNode { Value = indexedItems[j] };
                    RecursionBuildLeft(node.Left, indexedItems, j + 1);
                    RecursionBuildRight(node.Left, indexedItems, j + 1);
                    return;
                }
                j++;
            }
        }

        private void RecursionBuildRight(TreeNode node, IndexedItem[] indexedItems, int i)
        {
            int j = i;
            while (j < indexedItems.Length)
            {
                if (indexedItems[j].Index > node.Value.Index)
                {
                    node.Right = new TreeNode { Value = indexedItems[j] };
                    RecursionBuildLeft(node.Left, indexedItems, j + 1);
                    RecursionBuildRight(node.Left, indexedItems, j + 1);
                    return;
                }
                j++;
            }
        }

        /*
        public int Trap(int[] height)
        {
            int waterCounter = 0;
            int length = height.Length;
            if (length < 3)
                return 0;
            bool[] localMaxes = GetLocalMaxes(height, length);
            bool firstLocalMaxFound = false;
            bool secondLocalMaxFound = false;
            int firstLocalMaxindex;
            int secondLocalMaxindex;
            int currentWaterCounter = 0;
            for (int i = 0; i < length; i++)
            {
                if (localMaxes[i] && !firstLocalMaxFound)
                {
                    firstLocalMaxFound = true;
                    firstLocalMaxindex = i;
                }
                else if (!localMaxes[i] && firstLocalMaxFound)
                {
                    currentWaterCounter += 
                }
            }

            return waterCounter;
        }
        */

        private bool[] GetLocalMaxes(int[] height)
        {
            int length = height.Length;
            bool[] localMaxes = new bool[length]; //Defaults to false.
            if (height[1] < height[0])
                localMaxes[0] = true;
            for (int i = 1; i < length - 1; i++)
            {
                if (height[i - 1] <= height[i] && height[i + 1] < height[i])
                    localMaxes[i] = true;
            }
            if (height[length - 1] > height[length - 2])
                localMaxes[length - 1] = true;
            return localMaxes;
        }

        public int TrapQuadratic(int[] height)
        {
            if (height.Length == 0)
                return 0;
            int maxHeight = height.Max();
            int waterCounter = 0;
            for (int i = 1; i <= maxHeight; i++)
            {
                bool initialRockFound = false;
                int currentWaterCounter = 0;
                for (int j = 0; j < height.Length; j++)
                {
                    if (height[j] >= i && !initialRockFound)
                    {
                        initialRockFound = true;
                    }
                    else if (height[j] < i && initialRockFound)
                    {
                        currentWaterCounter++;
                    }
                    else if (height[j] >= i && initialRockFound)
                    {
                        waterCounter += currentWaterCounter;
                        currentWaterCounter = 0;
                    }
                }
            }
            return waterCounter;
        }
    }
}
