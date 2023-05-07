namespace tflzone1.Models
{
  static class Dijkstra
  {
    public static (string, List<(string, string, int)>) CalculateShortestPath(Graph graph, string start, string target)
    {

      // if ( graph. )

      // NOTE: Always reconstruct graph before calling this function
      var edgeToVertex = new Dictionary<string, int>(); // Start: "akan: a" => ("bakerloo: b", 5), 
      var pathsToVertex = new Dictionary<string, List<(string, string, int)>>();
      var distToVertex = new Dictionary<string, int>();
      var pq = new PriorityQueue<Vertex, int>();
      var startVertex = graph.Vertices.ContainsKey(start) ? graph.Vertices[start] : null;
      var pathResult = new List<(string, string, int)>();

      if(startVertex is null)
        return ("Start station not found", pathResult);
      
      pq.Enqueue(startVertex, 0);
      edgeToVertex.Add(start, 0);
      distToVertex.Add(start, 0);

      while(pq.Count > 0)
      {
        var current = pq.Dequeue();
        current = graph.Vertices[current.Node];

        foreach(var neighbor in current.GetNeighbours()) {
          var distToCurrent = distToVertex.ContainsKey(current.Node) ? distToVertex[current.Node] : 0;
          if(!distToVertex.ContainsKey(neighbor.Node)) {
            distToVertex.Add(neighbor.Node, distToCurrent + current.GetWeight(neighbor));
          } else {
            if(distToVertex[neighbor.Node] > distToCurrent + current.GetWeight(neighbor)) {
              distToVertex[neighbor.Node] = distToCurrent + current.GetWeight(neighbor);
              pathsToVertex.Remove(neighbor.Node);
              edgeToVertex.Remove(neighbor.Node);
            }
          }

          var edgeToCurrent = edgeToVertex.ContainsKey(current.Node) ? edgeToVertex[current.Node] : 0;
          if(!edgeToVertex.ContainsKey(neighbor.Node)) {
            edgeToVertex.Add(neighbor.Node, current.GetWeight(neighbor));

            if(pathsToVertex.ContainsKey(current.Node)) {
              var prevPaths = pathsToVertex[current.Node];
              var copyOfPrevPaths = new List<(string, string, int)>();
              prevPaths.ForEach(path => {
                copyOfPrevPaths.Add(path);
              });
              copyOfPrevPaths.Add((current.Node, neighbor.Node, current.GetWeight(neighbor)));
              pathsToVertex.Add(neighbor.Node, copyOfPrevPaths);
            } else {
              pathsToVertex.Add(neighbor.Node, new List<(string, string, int)>{(current.Node, neighbor.Node, current.GetWeight(neighbor))});
            }
            pq.Enqueue(neighbor, edgeToCurrent + current.GetWeight(neighbor));
          } 
          // else {
          //   edgesToVertex[neighbor.Node].Add((current.Node, neighbor.Node, current.GetWeight(neighbor)));
          // }
        }
      }

      // Console.WriteLine(distToVertex);
      // Console.WriteLine(edgeToVertex);
      // Console.WriteLine(pathsToVertex);

      return ("Path found", pathsToVertex[target]);
    }


    // public static void CalculateShortestPath(Graph graph, Vertex? start, Vertex? target)
    // {
    //   if (start == null || target == null)
    //   {
    //     return;
    //   }
    //   // Set the distance for the start node to zero 
    //   start.SetDistance(0);

    //   var unvisitedQueue = new PriorityQueue<Vertex, int>();

    //   foreach (var vertex in graph.Vertices)
    //   {
    //     unvisitedQueue.Enqueue(vertex.Value, vertex.Value.Distance);
    //   }

    //   while (unvisitedQueue.Count > 0)
    //   {
    //     var current = unvisitedQueue.Dequeue();
    //     current.MarkAsVisited();

    //     foreach (var neighbor in current.GetNeighbours())
    //     {
    //       if (neighbor.Visited)
    //       {
    //         continue;
    //       }
    //       var newDistance = current.Distance + current.GetWeight(neighbor);

    //       if (newDistance < neighbor.Distance)
    //       {
    //         neighbor.SetDistance(newDistance);
    //         neighbor.SetPreviousVertex(current);
    //         Console.WriteLine("Updated: Current {0}, Next: {1}, NewDist: {2}", current.Node, neighbor.Node, neighbor.Distance);
    //       }
    //       else
    //       {
    //         Console.WriteLine("Not Updated: Current {0}, Next: {1}, NewDist: {2}", current.Node, neighbor.Node, neighbor.Distance);
    //       }
    //     }

    //     unvisitedQueue.Clear();
    //     foreach (var vertex in graph.Vertices)
    //     {
    //       if (!vertex.Value.Visited)
    //       {
    //         unvisitedQueue.Enqueue(vertex.Value, vertex.Value.Distance);
    //       }
    //     }
    //   }
    // }

    // public static List<string> FindShortestPath(Vertex v, List<string> path)
    // {
    //   if (v.PreviousVertex != null)
    //   {
    //     path.Add(v.PreviousVertex.Node);
    //     FindShortestPath(v.PreviousVertex, path);
    //   }
    //   return path;
    // }
  }
}