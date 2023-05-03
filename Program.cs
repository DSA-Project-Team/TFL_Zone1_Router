using tflzone1.Models;

namespace tflzone1;
class Program
{
  static void Main(string[] args)
  {
    //Start the application menu
    MainMenu.UserSelectMenu();


    // var graph = ConstructGraph();
    // MakeRouteImpossible(graph, "D", "E", "Bridge Closed");
    // DisplayImpossibleRoutes(graph);
  }

  static Graph ConstructGraph()
  {
    var graph = new Graph();
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

  static void DisplayDelayedRoutes(Graph graph)
  {
    foreach (var vertex in graph.Vertices)
    {
      var delayedRoutes = vertex.Value.GetDelayedRoutes();

      foreach (var delayedRoute in delayedRoutes)
      {
        Console.WriteLine($"({vertex.Key} - {delayedRoute.Node}, {vertex.Value.GetWeight(delayedRoute)})");
      }
    }
  }
  static void DisplayImpossibleRoutes(Graph graph)
  {
    foreach (var vertex in graph.Vertices)
    {
      var delayedRoutes = vertex.Value.GetImpossibleRoutes();

      foreach (var delayedRoute in delayedRoutes)
      {
        Console.WriteLine($"Route Impossible: ({vertex.Key} - {delayedRoute.Node}, {vertex.Value.RouteImpossibleComment})");
      }
    }
  }
}




// foreach (var vertex in graph.Vertices)
//         {
//             foreach (var w in vertex.Value.GetNeighbours())
//             {
//                 Console.WriteLine($"({vertex.Value.Node},{w.Node},{vertex.Value.GetWeight(w)})");
//             }
//         }

//         Dijkstra.CalculateShortestPath(graph, graph.GetVertex("A"), graph.GetVertex("E"));
//         var target = graph.GetVertex("E");
//         var path = new List<String>(){ target.Node };
//         path = Dijkstra.FindShortestPath(target, path);
//         var result = "[ ";
//         foreach (var p in path)
//         {
//             result = $"{result}, {p}";
//         }
//         result = $"{result} ]";
//         Console.WriteLine($"The shortest path is: {result}");