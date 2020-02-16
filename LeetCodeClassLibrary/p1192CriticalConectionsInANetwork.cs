using System.Collections.Generic;
using System.Linq;

/*
 * NOTA: Para la solución cuadrática (MxN) me dio un timeout. Pero entiendo que como solución era correcta. Seguro tiene que haber una solución de menor complejidad en algún curso de teoría de grafos.
 * En efecto, 8 de 12 casos de test pasados.
 */

namespace p1192CriticalConectionsInANetwork
{
    public class Solution
    {
        private class GraphNode
        {
            public int Value { get; set; }
            public List<GraphNode> Neighbours { get; set; }
        }
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            IList<IList<int>> result = new List<IList<int>>();
            GraphNode graph = BuildGraph(connections);
            foreach (var edge in connections)
            {
                List<int> visited = new List<int>();
                if (!TraversableWithout(graph, edge, visited, n))
                    result.Add(edge.ToList());
            }
            return result;
        }

        private GraphNode BuildGraph(IList<IList<int>> connections)
        {
            Dictionary<int, GraphNode> nodes = new Dictionary<int, GraphNode>();
            foreach (var edge in connections)
            {
                GraphNode node0;
                GraphNode node1;
                if (!nodes.ContainsKey(edge[0]))
                {
                    node0 = new GraphNode { Value = edge[0], Neighbours = new List<GraphNode>() };
                    nodes.Add(edge[0], node0);
                }
                else
                    node0 = nodes[edge[0]];

                if (!nodes.ContainsKey(edge[1]))
                {
                    node1 = new GraphNode { Value = edge[1], Neighbours = new List<GraphNode>() };
                    nodes.Add(edge[1], node1);
                }
                else
                    node1 = nodes[edge[1]];
                nodes[edge[0]].Neighbours.Add(node1);
                nodes[edge[1]].Neighbours.Add(node0);
            }
            return nodes[connections[0][0]];
        }

        //TODO: No sé si una lista es lo más correcto.
        private bool TraversableWithout(GraphNode graph, IList<int> edge, List<int> visited, int n)
        {
            visited.Add(graph.Value);
            if (visited.Count == n)
                return true;
            bool result = false;
            foreach (GraphNode neighbour in graph.Neighbours)
            {
                if (!visited.Contains(neighbour.Value) && !EdgeBetween(graph, neighbour, edge))
                {
                    result = result || TraversableWithout(neighbour, edge, visited, n);
                }
                    
            }
            return result;
        }

        private bool EdgeBetween(GraphNode graph, GraphNode neighbour, IList<int> edge)
        {
            if (graph.Value == edge[0] && neighbour.Value == edge[1])
                return true;
            else if (graph.Value == edge[1] && neighbour.Value == edge[0])
                return true;
            else
                return false;
        }
    }
}
