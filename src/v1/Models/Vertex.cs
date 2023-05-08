using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tflzone1.Models
{
  class Vertex
  {
    private Dictionary<Vertex, int> _neighbours;
    private Dictionary<Vertex, int> _neighboursCopy;
    private bool _visited;
    public bool Visited
    {
      get { return _visited; }
      set { _visited = value; }
    }
    private int _distance;
    public int Distance
    {
      get { return _distance; }
      set { _distance = value; }
    }

    private string _node;
    public string Node
    {
      get { return _node; }
      set { _node = value; }
    }
    
    private Vertex? _previousVertex;
    public Vertex? PreviousVertex
    {
      get { return _previousVertex; }
      set { _previousVertex = value; }
    }

    private bool _hasDelay;
    public bool HasDelay
    {
      get { return _hasDelay; }
      set { _hasDelay = value; }
    }

    private bool _routeImpossible;
    public bool RouteImpossible
    {
      get { return _routeImpossible; }
      set { _routeImpossible = value; }
    }
    private string _routeImpossibleComment;
    public string RouteImpossibleComment
    {
      get { return _routeImpossibleComment; }
      set { _routeImpossibleComment = value; }
    }

    private Status _status;
    public Status Status
    {
        get { return _status; }
        set { _status = value; }
    }
    private Access _access;
    public Access Access
    {
        get { return _access; }
        set { _access = value; }
    }

    public Vertex(string node)
    {
      _node = node;
      _distance = Int32.MaxValue;
      _neighbours = new Dictionary<Vertex, int>();
      _neighboursCopy = new Dictionary<Vertex, int>();
      _hasDelay = false;
      _routeImpossibleComment = String.Empty;
    }

    public void AddNeighbour(Vertex v, int weight)
    {
      if (!_neighbours.ContainsKey(v))
        _neighbours.Add(v, weight);
        _neighboursCopy.Add(v, weight);
    }

    public void AddDelay(string v, int delay)
    {
      var vertex = _neighbours.FirstOrDefault((kv) => kv.Key.Node == v);
      _neighbours[vertex.Key] += delay;
      vertex.Key._hasDelay = true;
    }
    public void RemoveDelay(string v)
    {
      var vertex = _neighbours.FirstOrDefault((kv) => kv.Key.Node == v);
      _neighbours[vertex.Key] = _neighboursCopy[vertex.Key];
      vertex.Key._hasDelay = false;
    }

    public void MakeRouteImpossible(string v, string? reason)
    {
        var vertex = _neighbours.FirstOrDefault((kv) => kv.Key.Node == v);
        vertex.Key._status = Status.Closed;
        vertex.Key._routeImpossibleComment = String.IsNullOrEmpty(reason) ? "": reason;
    }
    public void MakeRoutePossible(string v)
    {
      var vertex = _neighbours.FirstOrDefault((kv) => kv.Key.Node == v);
      vertex.Key._status = Status.Open;
      vertex.Key._routeImpossibleComment = "";
    }

    public Vertex[] GetNeighbours()
    {
      return _neighbours.Keys.ToArray();
    }

    public Vertex[] GetDelayedRoutes()
    {
      return _neighbours.Keys.ToList().Where(v => v._hasDelay == true).ToArray();
    }
    public Vertex[] GetImpossibleRoutes()
    {
      return _neighbours.Keys.ToList().Where(v => v._status == Status.Closed).ToArray();
    }

    public int GetWeight(Vertex neighbor)
    {
      if (_neighbours.ContainsKey(neighbor))
        return _neighbours[neighbor];
      return 0;
    }
    public int GetOriginalWeight(Vertex neighbor)
    {
      if (_neighboursCopy.ContainsKey(neighbor))
        return _neighboursCopy[neighbor];
      return 0;
    }
    public void SetDistance(int distance)
    {
      _distance = distance;
    }

    public void SetPreviousVertex(Vertex prevVertex)
    {
      _previousVertex = prevVertex;
    }
    public void MarkAsVisited()
    {
      _visited = true;
    }
  }
}