using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tflzone1.Models;

namespace tflzone1.Controllers
{
    static class GraphConstructor
    {
        public static Graph graph = new Graph();

        public static void ConstructGraph()
        {
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");
            graph.AddVertex("E");
            graph.AddVertex("F");

            graph.AddEdge(new Vertex("A"), new Vertex("B"), 7);
            graph.AddEdge(new Vertex("A"), new Vertex("C"), 9);
            graph.AddEdge(new Vertex("A"), new Vertex("F"), 14);
            graph.AddEdge(new Vertex("B"), new Vertex("C"), 10);
            graph.AddEdge(new Vertex("B"), new Vertex("D"), 15);
            graph.AddEdge(new Vertex("C"), new Vertex("D"), 11);
            graph.AddEdge(new Vertex("C"), new Vertex("F"), 2);
            graph.AddEdge(new Vertex("D"), new Vertex("E"), 6);
            graph.AddEdge(new Vertex("E"), new Vertex("F"), 9);
        }
    }
}