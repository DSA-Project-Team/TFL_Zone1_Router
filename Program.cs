﻿using tflzone1.Controllers;
using tflzone1.Models;

namespace tflzone1;
class Program
{
  static void Main(string[] args)
  {
    // Start App Menu
    // GraphConstructor.ConstructGraph();
    // MainMenu.UserSelectMenu();

    // Test
    // var graph = ConstructTestGraph();
    // graph.FindFastestWalkingRoute("A", "H");

    // TFL ZONE 1
    GraphConstructor.ConstructGraph();
    var graph = GraphConstructor.graph;
    MainMenu.UserSelectMenu();
    // MakeRouteImpossible(graph, "D", "E", "Bridge Closed");
    // DisplayImpossibleRoutes(graph);
  }

  static Graph ConstructTestGraph()
  {
    var graph = new Graph();
    graph.AddVertex("A");
    graph.AddVertex("B");
    graph.AddVertex("C");
    graph.AddVertex("D");
    graph.AddVertex("E");
    graph.AddVertex("F");
    graph.AddVertex("G");
    graph.AddVertex("H");

    graph.AddEdge(new Vertex("A"), new Vertex("E"), 4, true);
    graph.AddEdge(new Vertex("A"), new Vertex("D"), 6, true);
    graph.AddEdge(new Vertex("B"), new Vertex("A"), 1, true);
    graph.AddEdge(new Vertex("D"), new Vertex("B"), 3, true);
    graph.AddEdge(new Vertex("B"), new Vertex("C"), 8, true);
    graph.AddEdge(new Vertex("E"), new Vertex("C"), 1, true);
    graph.AddEdge(new Vertex("D"), new Vertex("F"), 3, true);
    graph.AddEdge(new Vertex("G"), new Vertex("C"), 1, true);
    graph.AddEdge(new Vertex("E"), new Vertex("H"), 9, true);
    graph.AddEdge(new Vertex("F"), new Vertex("G"), 8, true);
    graph.AddEdge(new Vertex("H"), new Vertex("G"), 2, true);
    graph.AddEdge(new Vertex("H"), new Vertex("F"), 5, true);

    return graph;
  }

  static void MakeRouteImpossible(Graph graph, string from, string to, string comment)
  {
    graph.MakeRouteImpossible(from, to, comment);
  }
  static void MakeRoutePossible(Graph graph, string from, string to, string comment)
  {
    graph.MakeRoutePossible(from, to);
  }

  static void AddDelayToRoute(Graph graph, string from, string to, int delay)
  {
    graph.AddDelay(from, to, delay);
  }
  static void RemoveDelayFromRoute(Graph graph, string from, string to, int delay)
  {
    graph.RemoveDelay(from, to, delay);
  }
}


// Algorithm Analysis
// Stopwatch stopWatch = new Stopwatch();
// stopWatch.Start();
// Thread.Sleep(3500);
// stopWatch.Stop();
// // Get the elapsed time as a TimeSpan value.
// TimeSpan ts = stopWatch.Elapsed;

// // Format and display the TimeSpan value.
// string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//     ts.Hours, ts.Minutes, ts.Seconds,
//     ts.Milliseconds / 10);
// Console.WriteLine("RunTime " + elapsedTime);