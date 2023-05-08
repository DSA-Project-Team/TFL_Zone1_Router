using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using v2.Models;

namespace v2.Controllers
{
    static class GraphConstructor
    {
        public static Graph graph;

        public static void ConstructGraph()
        {
            graph = new Graph(12);

            // Bakerloo
            graph.AddVertex("bakerloo: paddington");
            graph.AddVertex("bakerloo: edgware road");
            graph.AddVertex("bakerloo: maryleborne");
            graph.AddVertex("bakerloo: baker street");
            graph.AddVertex("bakerloo: regent's park");
            graph.AddVertex("bakerloo: oxford circus");
            graph.AddVertex("bakerloo: picadilly circus");
            graph.AddVertex("bakerloo: charing cross");
            graph.AddVertex("bakerloo: embarkment");
            graph.AddVertex("bakerloo: waterloo");
            graph.AddVertex("bakerloo: labert North");
            graph.AddVertex("bakerloo: elephant and castle");
            
            graph.AddEdge("bakerloo: paddington", "bakerloo: edgware road", 11);
            graph.AddEdge("bakerloo: edgware road", "bakerloo: maryleborne", 7);
            graph.AddEdge("bakerloo: maryleborne", "bakerloo: baker street", 6);
            graph.AddEdge("bakerloo: baker street", "bakerloo: regent's park", 10);
            graph.AddEdge("bakerloo: regent's park", "bakerloo: oxford circus", 15);
            graph.AddEdge("bakerloo: oxford circus", "bakerloo: picadilly circus", 12);
            graph.AddEdge("bakerloo: picadilly circus", "bakerloo: charing cross", 11);
            graph.AddEdge("bakerloo: charing cross", "bakerloo: embarkment", 3);
            graph.AddEdge("bakerloo: embarkment", "bakerloo: waterloo", 6);
            graph.AddEdge("bakerloo: waterloo", "bakerloo: labert North", 9);
            graph.AddEdge("bakerloo: labert North", "bakerloo: elephant and castle", 18);
        }
    }
}