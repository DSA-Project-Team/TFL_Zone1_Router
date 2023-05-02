namespace tflzone1.Models
{
  static class Dijkstra
  {
    public static void CalculateShortestPath(Graph graph, Vertex? start, Vertex? target)
    {
      if (start == null || target == null)
      {
        return;
      }
      // Set the distance for the start node to zero 
      start.SetDistance(0);

      var unvisitedQueue = new PriorityQueue<Vertex, int>();

      foreach (var vertex in graph.Vertices)
      {
        unvisitedQueue.Enqueue(vertex.Value, vertex.Value.Distance);
      }

      while (unvisitedQueue.Count > 0)
      {
        var current = unvisitedQueue.Dequeue();
        current.MarkAsVisited();

        foreach (var neighbor in current.GetNeighbours())
        {
          if (neighbor.Visited)
          {
            continue;
          }
          var newDistance = current.Distance + current.GetWeight(neighbor);

          if (newDistance < neighbor.Distance)
          {
            neighbor.SetDistance(newDistance);
            neighbor.SetPreviousVertex(current);
            Console.WriteLine("Updated: Current {0}, Next: {1}, NewDist: {2}", current.Node, neighbor.Node, neighbor.Distance);
          }
          else
          {
            Console.WriteLine("Not Updated: Current {0}, Next: {1}, NewDist: {2}", current.Node, neighbor.Node, neighbor.Distance);
          }
        }

        unvisitedQueue.Clear();
        foreach (var vertex in graph.Vertices)
        {
          if (!vertex.Value.Visited)
          {
            unvisitedQueue.Enqueue(vertex.Value, vertex.Value.Distance);
          }
        }
      }
    }

    public static List<string> FindShortestPath(Vertex v, List<string> path)
    {
      if (v.PreviousVertex != null)
      {
        path.Add(v.PreviousVertex.Node);
        FindShortestPath(v.PreviousVertex, path);
      }
      return path;
    }
  }
}