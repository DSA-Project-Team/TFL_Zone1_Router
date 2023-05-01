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
            if(!_vertices.ContainsKey(node))
                _vertices.Add(node, new Vertex(node));
        }

        public Vertex? GetVertex(string node)
        {
            if(_vertices.ContainsKey(node))
                return _vertices[node];
            else return null;
        }

        public void AddEdge(Vertex from, Vertex to, int dist) 
        {
            if(!_vertices.ContainsKey(from.Node))
                _vertices.Add(from.Node, from);

            if(!_vertices.ContainsKey(to.Node))
                _vertices.Add(to.Node, to);

            _vertices[from.Node].AddNeighbour(to, dist);
            _vertices[to.Node].AddNeighbour(from, dist);
        }

        public void AddDelay(string from, string to, int delayCost) 
        {
            if(!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
                return;
            _vertices[from].AddDelay(to, delayCost);
            _vertices[to].AddDelay(from, delayCost);
        }

        public void RemoveDelay(string from, string to, int delayCost) 
        {
            if(!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
                return;
            _vertices[from].RemoveDelay(to, delayCost);
            _vertices[to].RemoveDelay(from, delayCost);
        }

        public void MakeRouteImpossible(string from, string to, string reason)
        {
            if(!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
                return;
            _vertices[from].MakeRouteImpossible(to, reason);
            _vertices[to].MakeRouteImpossible(from, reason);
        }

        public void MakeRoutePossible(string from, string to)
        {
            if(!_vertices.ContainsKey(from) || !_vertices.ContainsKey(to))
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
            if(v.PreviousVertex != null) {
                path.Add(v.PreviousVertex.Node);
                ShortestPath(v.PreviousVertex, path);
            }
            return path;
        }
    }
}