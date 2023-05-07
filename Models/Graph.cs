namespace tflzone1.Models
{
  class Graph
  {
    private int _numberOfVertices;
    public int NoOfVertices
    {
      get { return _numberOfVertices; }
      set { _numberOfVertices = value; }
    }

    private Dictionary<string, Vertex> _vertices;
    public Dictionary<string, Vertex> Vertices
    {
      get { return _vertices; }
      set { _vertices = value; }
    }

    private Vertex? _previousVertex;
    public Vertex? PreviousVertex
    {
      get { return _previousVertex; }
      set { _previousVertex = value; }
    }


    public Graph()
    {
      _numberOfVertices = 0;
      _vertices = new Dictionary<string, Vertex>();
    }

    public void AddVertex(string node)
    {
      if (!_vertices.ContainsKey(node))
        _vertices.Add(node, new Vertex(node));
    }

    public Vertex? GetVertex(string node)
    {
      if (_vertices.ContainsKey(node))
        return _vertices[node];
      else return null;
    }

    public void AddEdge(Vertex from, Vertex to, int dist, bool singleDirection = false)
    {
      if (!_vertices.ContainsKey(from.Node))
        _vertices.Add(from.Node, from);

      if (!_vertices.ContainsKey(to.Node))
        _vertices.Add(to.Node, to);

      _vertices[from.Node].AddNeighbour(to, dist);
      if(!singleDirection) {
        _vertices[to.Node].AddNeighbour(from, dist);
      }
    }

    public bool AddDelay(string from, string to, int delayCost)
    {
      if (!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
        return false;

      var neighbours = _vertices[from].GetNeighbours();
      var nb = neighbours.FirstOrDefault(neighbour => neighbour.Node.ToLower() == to.ToLower());

      if(nb == null)
        return false;
      
      _vertices[from].AddDelay(to, delayCost);
      _vertices[to].AddDelay(from, delayCost);
      return true;
    }

    public void RemoveDelay(string from, string to, int delayCost)
    {
      if (!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
        return;
      _vertices[from].RemoveDelay(to, delayCost);
      _vertices[to].RemoveDelay(from, delayCost);
    }

    public bool MakeRouteImpossible(string from, string to, string? reason)
    {
      if (!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
        return false;

      if(_vertices[from].Status == Status.Closed || _vertices[to].Status == Status.Closed)
        return false;

      _vertices[from].MakeRouteImpossible(to, reason);
      _vertices[to].MakeRouteImpossible(from, reason);
      return true;
    }

    public void MakeRoutePossible(string from, string to)
    {
      if (!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
        return;
      _vertices[from].MakeRoutePossible(to);
      _vertices[to].MakeRoutePossible(from);
    }

    public void SetCurrent(Vertex prev)
    {
      _previousVertex = prev;
    }

    public List<string> ShortestPath(Vertex v, List<string> path)
    {
      if (v.PreviousVertex != null)
      {
        path.Add(v.PreviousVertex.Node);
        ShortestPath(v.PreviousVertex, path);
      }
      return path;
    }

    public void DisplayDelayedRoutes()
    {
      foreach (var vertex in Vertices)
      {
        var delayedRoutes = vertex.Value.GetDelayedRoutes();

        foreach (var delayedRoute in delayedRoutes)
        {
          Console.WriteLine($"{vertex.Key} - {delayedRoute.Node}: {vertex.Value.GetOriginalWeight(delayedRoute)} min now {vertex.Value.GetWeight(delayedRoute)} min");
          // Victoria Line: Oxford Circus - Warren Street : 18 min now 23 min
        }
      }
    }
    public void DisplayImpossibleRoutes()
    {
      var impossibleRoutes = GetImpossibleRoutes();

      foreach (var vertex in Vertices)
      {
        var impossibleDestinations = vertex.Value.GetImpossibleRoutes();
        // impossibleRoutes.AddRange(impossibleDestinations);
        foreach (var delayedRoute in impossibleDestinations)
        {
          Console.WriteLine($"{vertex.Key} - {delayedRoute.Node} : {vertex.Value.RouteImpossibleComment}");
        }
      }

      // return impossibleRoutes;
    }
    private List<Vertex> GetImpossibleRoutes()
    {
      var impossibleRoutes = new List<Vertex>();
      foreach (var vertex in Vertices)
      {
        var impossibleDestinations = vertex.Value.GetImpossibleRoutes();
        impossibleRoutes.AddRange(impossibleDestinations);
      }
      return impossibleRoutes;
    }

    public void FindFastestWalkingRoute(string start, string target)
    {
      var pathResult = CalculateShortestPath(start, target);

      if(pathResult.Item1 != "Path found") {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(pathResult.Item1);
        Console.ResetColor();
      } else {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Route: {start} to {target}: ");

        Console.WriteLine($"({1}) Start: {start}");
        for (var i = 0; i < pathResult.Item2.Count; i++)
        {
          Console.WriteLine($"({i+2}) {pathResult.Item2[i].Item1} to {pathResult.Item2[i].Item2} {pathResult.Item2[i].Item3} mins");
        }
        Console.WriteLine($"({pathResult.Item2.Count + 2}) End: {target}");
        Console.WriteLine($"Total Journey Time: {pathResult.Item2.Sum( path => path.Item3)} mins");

        Console.ResetColor();
      }
    }

    private (string, List<(string, string, int)>) CalculateShortestPath(string start, string target)
    {

      var pathResult = new List<(string, string, int)>();
      var impossibleDestinations = GetImpossibleRoutes();
      
      if( impossibleDestinations.FirstOrDefault(v => v.Node == start || v.Node == target) != null ) {
        return ("Route impossible", pathResult);
      }

      // NOTE: Always reconstruct graph before calling this function
      var edgeToVertex = new Dictionary<string, int>(); // Start: "akan: a" => ("bakerloo: b", 5), 
      var pathsToVertex = new Dictionary<string, List<(string, string, int)>>();
      var distToVertex = new Dictionary<string, int>();
      var pq = new PriorityQueue<Vertex, int>();
      var startVertex = Vertices.ContainsKey(start) ? Vertices[start] : null;

      if(startVertex is null)
        return ("Start station not found", pathResult);
      
      pq.Enqueue(startVertex, 0);
      edgeToVertex.Add(start, 0);
      distToVertex.Add(start, 0);

      while(pq.Count > 0)
      {
        var current = pq.Dequeue();
        current = Vertices[current.Node];

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

    public Vertex? GetStationInfo(string station)
    {
      if(Vertices.ContainsKey(station))
        return Vertices[station];
      return null;
    }
  }
}