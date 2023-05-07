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

            graph.AddEdge(new Vertex("bakerloo: paddington"), new Vertex("bakerloo: edgware road"), 11);
            graph.AddEdge(new Vertex("bakerloo: edgware road"), new Vertex("bakerloo: maryleborne"), 7);
            graph.AddEdge(new Vertex("bakerloo: maryleborne"), new Vertex("bakerloo: baker street"), 6);
            graph.AddEdge(new Vertex("bakerloo: baker street"), new Vertex("bakerloo: regent's park"), 10);
            graph.AddEdge(new Vertex("bakerloo: regent's park"), new Vertex("bakerloo: oxford circus"), 15);
            graph.AddEdge(new Vertex("bakerloo: oxford circus"), new Vertex("bakerloo: picadilly circus"), 12);
            graph.AddEdge(new Vertex("bakerloo: picadilly circus"), new Vertex("bakerloo: charing cross"), 11);
            graph.AddEdge(new Vertex("bakerloo: charing cross"), new Vertex("bakerloo: embarkment"), 3);
            graph.AddEdge(new Vertex("bakerloo: embarkment"), new Vertex("bakerloo: waterloo"), 6);
            graph.AddEdge(new Vertex("bakerloo: waterloo"), new Vertex("bakerloo: labert North"), 9);
            graph.AddEdge(new Vertex("bakerloo: labert North"), new Vertex("bakerloo: elephant and castle"), 18);
        }






        // public static void ConstructGraph()
        // {
        //     graph = new Graph();
        //     graph.AddVertex("northern: a");
        //     graph.AddVertex("bakerloo: b");
        //     graph.AddVertex("circle: c");
        //     graph.AddVertex("district: d");
        //     graph.AddVertex("hammersmith: e");
        //     graph.AddVertex("picadilly: f");

        //     graph.AddEdge(new Vertex("northern: a"), new Vertex("bakerloo: b"), 7);
        //     graph.AddEdge(new Vertex("northern: a"), new Vertex("circle: c"), 9);
        //     graph.AddEdge(new Vertex("northern: a"), new Vertex("picadilly: f"), 14);
        //     graph.AddEdge(new Vertex("bakerloo: b"), new Vertex("circle: c"), 10);
        //     graph.AddEdge(new Vertex("bakerloo: b"), new Vertex("district: d"), 15);
        //     graph.AddEdge(new Vertex("circle: c"), new Vertex("district: d"), 11);
        //     graph.AddEdge(new Vertex("circle: c"), new Vertex("picadilly: f"), 2);
        //     graph.AddEdge(new Vertex("district: d"), new Vertex("hammersmith: e"), 6);
        //     graph.AddEdge(new Vertex("hammersmith: e"), new Vertex("picadilly: f"), 9);
        // }
    }
}