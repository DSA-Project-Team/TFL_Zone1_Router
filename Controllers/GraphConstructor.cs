using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tflzone1.Models;

namespace tflzone1.Controllers
{
    static class GraphConstructor
    {
        public static Graph graph; //= new Graph();

        public static void ConstructGraph()
        {
            graph = new Graph();
            graph.AddVertex("northern: a");
            graph.AddVertex("bakerloo: b");
            graph.AddVertex("circle: c");
            graph.AddVertex("district: d");
            graph.AddVertex("hammersmith: e");
            graph.AddVertex("picadilly: f");

            graph.AddEdge(new Vertex("northern: a"), new Vertex("bakerloo: b"), 7);
            graph.AddEdge(new Vertex("northern: a"), new Vertex("circle: c"), 9);
            graph.AddEdge(new Vertex("northern: a"), new Vertex("picadilly: f"), 14);
            graph.AddEdge(new Vertex("bakerloo: b"), new Vertex("circle: c"), 10);
            graph.AddEdge(new Vertex("bakerloo: b"), new Vertex("district: d"), 15);
            graph.AddEdge(new Vertex("circle: c"), new Vertex("district: d"), 11);
            graph.AddEdge(new Vertex("circle: c"), new Vertex("picadilly: f"), 2);
            graph.AddEdge(new Vertex("district: d"), new Vertex("hammersmith: e"), 6);
            graph.AddEdge(new Vertex("hammersmith: e"), new Vertex("picadilly: f"), 9);
        }
    }
}