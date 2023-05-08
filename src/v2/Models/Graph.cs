using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testing_and_benchmarking;
using v2.Utilities;

namespace v2.Models
{
    class Graph
    {
        private static int _vertexCount;
        private int _numOfVertices;
        private int[,] _edgeWeights;
        private int[,] _edgeWeightsCopy;
        private bool[,] _routeStatuses;
        private bool[,] _routeStatusesCopy;
        private string[] _vertices;
        private bool[] _verticesStatuses;
        public string[] Vertices
        {
            get { return _vertices; }
            set { _vertices = value; }
        }
        public Graph(int numOfVertices)
        {
            _numOfVertices = numOfVertices;
            _edgeWeights = new int [ numOfVertices, numOfVertices ];
            _edgeWeightsCopy = new int [ numOfVertices, numOfVertices ];
            _routeStatuses = new bool [ numOfVertices, numOfVertices ];
            _routeStatusesCopy = new bool [ numOfVertices, numOfVertices ];
            _vertices = new string[ numOfVertices ];
            _verticesStatuses = new bool[ numOfVertices ];
            _vertexCount = 0;
        }

        public bool AddVertex(string vertexName)
        {
            if ( _vertexCount < _numOfVertices) 
            {
                _vertices[_vertexCount] = vertexName;
                _vertexCount++;
                return true;
            } 
            else 
            {
                return false;
            }
        }

        public bool AddEdge(string fromVertex, string toVertex, int weight)
        {
            var fromVertexIndex = -1;
            var toVertexIndex = -1;

            for(int i = 0; i < _vertices.Length; i++)
            {
                if(_vertices[i] == fromVertex) 
                {
                    fromVertexIndex = i;
                }

                if(_vertices[i] == toVertex) 
                {
                    toVertexIndex = i;
                }
            }

            if(fromVertexIndex < 0 || toVertexIndex < 0) {
                return false;
            }

            // Set weight for both directions
            _edgeWeights[fromVertexIndex, toVertexIndex] = weight;
            _edgeWeights[toVertexIndex, fromVertexIndex] = weight;

            // Keep copy of weight
            _edgeWeightsCopy = (int[,])_edgeWeights.Clone();

            // Set status for both directions
            _routeStatuses[fromVertexIndex, toVertexIndex] = true;
            _routeStatuses[toVertexIndex, fromVertexIndex] = true;

            // Set status for both stations
            _verticesStatuses[fromVertexIndex] = true;
            _verticesStatuses[toVertexIndex] = true;

            // Keep copy of route statuses
            _routeStatusesCopy = (bool[,])_routeStatuses.Clone();
            return true;
        }

        public bool AddDelay(string fromVertex, string toVertex, int delay)
        {
            var fromVertexIndex = -1;
            var toVertexIndex = -1;

            for(int i = 0; i < _vertices.Length; i++)
            {
                if(_vertices[i] == fromVertex) 
                {
                    fromVertexIndex = i;
                }

                if(_vertices[i] == toVertex) 
                {
                    toVertexIndex = i;
                }
            }

            if(fromVertexIndex < 0 || toVertexIndex < 0) {
                return false;
            }

            // Set weight for both directions
            _edgeWeights[fromVertexIndex, toVertexIndex] += delay;
            _edgeWeights[toVertexIndex, fromVertexIndex] += delay;

            return true;
        }

        public bool RemoveDelay(string fromVertex, string toVertex)
        {
            var fromVertexIndex = -1;
            var toVertexIndex = -1;

            for(int i = 0; i < _vertices.Length; i++)
            {
                if(_vertices[i] == fromVertex) 
                {
                    fromVertexIndex = i;
                }

                if(_vertices[i] == toVertex) 
                {
                    toVertexIndex = i;
                }
            }

            if(fromVertexIndex < 0 || toVertexIndex < 0) {
                return false;
            }

            // Set the weight for both directions from the original edgeWeights copy
            _edgeWeights[fromVertexIndex, toVertexIndex] = _edgeWeightsCopy[fromVertexIndex, toVertexIndex];
            _edgeWeights[toVertexIndex, fromVertexIndex] = _edgeWeightsCopy[fromVertexIndex, toVertexIndex];

            return true;
        }

        public bool MakeRouteImpossible(string fromVertex, string toVertex)
        {
            var fromVertexIndex = -1;
            var toVertexIndex = -1;

            for(int i = 0; i < _vertices.Length; i++)
            {
                if(_vertices[i] == fromVertex) 
                {
                    fromVertexIndex = i;
                }

                if(_vertices[i] == toVertex) 
                {
                    toVertexIndex = i;
                }
            }

            if(fromVertexIndex < 0 || toVertexIndex < 0) {
                return false;
            }

            // Set status to false for both directions
            _routeStatuses[fromVertexIndex, toVertexIndex] = false;
            _routeStatuses[toVertexIndex, fromVertexIndex] = false;
            
            // Set status to false for both stations
            _verticesStatuses[fromVertexIndex] = false;
            _verticesStatuses[toVertexIndex] = false;

            return true;
        }

        public bool MakeRoutePossible(string fromVertex, string toVertex)
        {
            var fromVertexIndex = -1;
            var toVertexIndex = -1;

            for(int i = 0; i < _vertices.Length; i++)
            {
                if(_vertices[i] == fromVertex) 
                {
                    fromVertexIndex = i;
                }

                if(_vertices[i] == toVertex) 
                {
                    toVertexIndex = i;
                }
            }

            if(fromVertexIndex < 0 || toVertexIndex < 0) {
                return false;
            }

            // Set status to false for both directions
            _routeStatuses[fromVertexIndex, toVertexIndex] = true;
            _routeStatuses[toVertexIndex, fromVertexIndex] = true;

             // Set status to true for both stations
            _verticesStatuses[fromVertexIndex] = true;
            _verticesStatuses[toVertexIndex] = true;

            return true;
        }

        public void DisplayDelayedRoutes()
        {
            for(int i = 0; i < _numOfVertices; i++)
            {
                for(int j = 0; j < _numOfVertices; j++)
                {
                    if (_edgeWeights[i,j] > _edgeWeightsCopy[i,j]) {
                        Console.WriteLine($"{_vertices[i]} - {_vertices[j]}: {_edgeWeightsCopy[i,j]} mins now {_edgeWeights[i,j]} mins");
                    }
                }
            }
        }

        public void DisplayImpossibleRoutes()
        {
            for(int i = 0; i < _numOfVertices; i++)
            {
                for(int j = 0; j < _numOfVertices; j++)
                {
                    if ( _routeStatuses[i,j] != _routeStatusesCopy[i,j] && _routeStatuses[i,j] == false ) {
                        Console.WriteLine($"Route Impossible: {_vertices[i]} - {_vertices[j]}");
                    }
                }
            }
        }

        public bool ShowStationInfo(string stationName)
        {
            var stationIndex = FindStationIndex(stationName);

            if(stationIndex >= 0) 
            {
                var station = _vertices[stationIndex];
                var status = _verticesStatuses[stationIndex] ? "Open": "Closed";
                Console.WriteLine("Station Information\n");
                Console.WriteLine($"Station Name: {TextHelper.CapitalizeFirstLetter(station.Split(':')[1])}");
                Console.WriteLine($"Tube Line: {TextHelper.CapitalizeFirstLetter(station.Split(':')[0])}");
                Console.WriteLine($"Travel Zone: Zone 1");
                Console.WriteLine($"Station Status: {status}\n");
                return true;
            }

            return false;
        }

        private int FindStationIndex(string stationName)
        {
            var index = -1;

            for(int i = 0; i < _vertices.Length; i++)
            {
                if(_vertices[i] == stationName) 
                {
                    index = i;
                }
            }

            return index;
        }

        public void FindFastestWalkingRoute(string start, string target)
        {
            RunTimeAnalyzer.Start(); // Stop Timer
            var pathResult = CalculateShortestPath(start, target);

            if(pathResult.Item1 != "Path found") 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(pathResult.Item1);
                Console.ResetColor();
            } 
            else 
            {
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

            RunTimeAnalyzer.Stop(); // Stop Timer
            RunTimeAnalyzer.Save(); // Save Result
        }

        private int GetVertexWeight(string vertexA, string vertexB)
        {
            var vertexAIndex = FindStationIndex(vertexA);
            var vertexBIndex = FindStationIndex(vertexB);

            if(vertexAIndex < 0 || vertexBIndex < -1) {
                return -1;
            }

            return _edgeWeights[vertexAIndex, vertexBIndex];
        }

        private List<string> GetNeighbours(string vertex)
        {
            var neighbors = new List<string>();
            var vertexIndex = FindStationIndex(vertex);
            for(int i = 0; i < _numOfVertices; i++)
            {
                if(_edgeWeightsCopy[vertexIndex, i] > 0)
                {
                    neighbors.Add(_vertices[i]);
                }
            }

            return neighbors;
        }

        private (string, List<(string, string, int)>) CalculateShortestPath(string start, string target)
        {
            var pathResult = new List<(string, string, int)>();
            var edgeToVertex = new Dictionary<string, int>();
            var pathsToVertex = new Dictionary<string, List<(string, string, int)>>();
            var distToVertex = new Dictionary<string, int>();
            var pq = new PriorityQueue<string, int>();
            var startVertexIndex = FindStationIndex(start);
            var targetVertexIndex = FindStationIndex(target);
            
            if(startVertexIndex < 0)
                return ("Start station not found", pathResult);

            if(!_verticesStatuses[startVertexIndex] || !_verticesStatuses[targetVertexIndex]) {
                return ("Route impossible", pathResult);
            }

            var startVertex = _vertices[startVertexIndex];

            
            pq.Enqueue(startVertex, 0);
            edgeToVertex.Add(start, 0);
            distToVertex.Add(start, 0);

            while(pq.Count > 0)
            {
                var current = pq.Dequeue();
                current = _vertices[FindStationIndex(current)];

                foreach(var neighbor in GetNeighbours(current))
                {
                    var distToCurrent = distToVertex.ContainsKey(current) ? distToVertex[current] : 0;
                    if(!distToVertex.ContainsKey(neighbor)) 
                    {
                        distToVertex.Add(neighbor, distToCurrent + GetVertexWeight(current, neighbor));
                    } 
                    else 
                    {
                        if(distToVertex[neighbor] > distToCurrent + GetVertexWeight(current, neighbor)) 
                        {
                            distToVertex[neighbor] = distToCurrent + GetVertexWeight(current, neighbor);
                            pathsToVertex.Remove(neighbor);
                            edgeToVertex.Remove(neighbor);
                        }
                    }

                    var edgeToCurrent = edgeToVertex.ContainsKey(current) ? edgeToVertex[current] : 0;
                    if(!edgeToVertex.ContainsKey(neighbor)) 
                    {
                        edgeToVertex.Add(neighbor, GetVertexWeight(current, neighbor));

                        if(pathsToVertex.ContainsKey(current)) 
                        {
                            var prevPaths = pathsToVertex[current];
                            var copyOfPrevPaths = new List<(string, string, int)>();
                            prevPaths.ForEach(path => {
                                copyOfPrevPaths.Add(path);
                            });
                            copyOfPrevPaths.Add((current, neighbor, GetVertexWeight(current, neighbor)));
                            pathsToVertex.Add(neighbor, copyOfPrevPaths);
                        } 
                        else 
                        {
                            pathsToVertex.Add(neighbor, new List<(string, string, int)>{(current, neighbor, GetVertexWeight(current, neighbor))});
                        }
                        pq.Enqueue(neighbor, edgeToCurrent + GetVertexWeight(current, neighbor));
                    }
                }
            }

            return ("Path found", pathsToVertex[target]);
        }
    }
}