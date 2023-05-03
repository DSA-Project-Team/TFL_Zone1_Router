using tflzone1.Models;

namespace tflzone1;
class Program
{
    static void Main(string[] args)
    {
        var graph = ConstructGraph();
        MakeRouteImpossible(graph, "D", "E", "Bridge Closed");
        DisplayImpossibleRoutes(graph);
    }

    static Graph ConstructGraph()
    {
        var graph = new Graph();
        graph.AddVertex("A", "Elizabeth");
        graph.AddVertex("B", "Elizabeth");
        graph.AddVertex("C", "Elizabeth");
        graph.AddVertex("D", "Elizabeth");
        graph.AddVertex("E", "Elizabeth");
        graph.AddVertex("F", "Elizabeth");

        graph.AddEdge(new Vertex("A", "Elizabeth"), new Vertex("B", "Elizabeth"), 7);
        graph.AddEdge(new Vertex("A", "Elizabeth"), new Vertex("C", "Elizabeth"), 9);
        graph.AddEdge(new Vertex("A", "Elizabeth"), new Vertex("F", "Elizabeth"), 14);
        graph.AddEdge(new Vertex("B", "Elizabeth"), new Vertex("C", "Elizabeth"), 10);
        graph.AddEdge(new Vertex("B", "Elizabeth"), new Vertex("D", "Elizabeth"), 15);
        graph.AddEdge(new Vertex("C", "Elizabeth"), new Vertex("D", "Elizabeth"), 11);
        graph.AddEdge(new Vertex("C", "Elizabeth"), new Vertex("F", "Elizabeth"), 2);
        graph.AddEdge(new Vertex("D", "Elizabeth"), new Vertex("E", "Elizabeth"), 6);
        graph.AddEdge(new Vertex("E", "Elizabeth"), new Vertex("F", "Elizabeth"), 9);

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