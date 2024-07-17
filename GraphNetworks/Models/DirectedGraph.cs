namespace GraphNetworks.Models
{
    internal class DirectedGraph
    {
        //constructors
        public DirectedGraph() { }


        public DirectedGraph(List<Edge> edges)
        {
            Edges = [.. edges.Distinct()];
            foreach (var edge in edges)
            {
                Vertices.Add(edge.Source);
                Vertices.Add(edge.Destination);
            }
            Vertices = [.. Vertices.Distinct()];
        }


        public DirectedGraph(List<Vertex> vertices)
        {
            Vertices = [.. vertices];
        }


        public DirectedGraph(List<Edge> edges, List<Vertex> vertices)
        {
            Edges = [.. edges.Distinct()];
            foreach (Edge edge in edges)
            {
                Vertices.Add(edge.Source);
                Vertices.Add(edge.Destination);
            }
            foreach (Vertex vertex in vertices)
            {
                Vertices.Add(vertex);
            }
            Vertices = [.. Vertices.Distinct()];
        }


        //storage members
        private List<Edge> Edges = [];
        private List<Vertex> Vertices = [];

        //getters
        public List<Edge> GetEdges() => [.. Edges];
        public List<Vertex> GetVertices() => [.. Vertices];


        //methods
        public void Add(Edge edge)
        {
            if (!Exist(edge))
                Edges.Add(edge);
        }


        public void Add(List<Edge> edges)
        {
            Edges.AddRange(edges.Where(e => !Exist(e)));
        }


        public void Add(Vertex vertex)
        {
            if (!Exist(vertex))
                Vertices.Add(vertex);
        }


        public bool Exist(Edge edge)
        {
            foreach (Edge e in Edges)
            {
                if (e.Equals(edge))
                    return true;
            }
            return false;
        }


        public bool Exist(Vertex vertex)
        {
            foreach (Vertex v in Vertices)
            {
                if (v.Equals(vertex))
                    return true;
            }
            return false;
        }


        public List<Vertex> GetChildOf(Vertex vertex)
        {
            List<Vertex> vertices = [];
            foreach (var e in Edges)
            {
                if (e.Source.Equals(vertex))
                    vertices.Add(e.Destination);
            }
            return vertices;
        }


        public List<Vertex> GetParentOf(Vertex vertex)
        {
            List<Vertex> vertices = [];
            foreach (var e in Edges)
            {
                if (e.Destination.Equals(vertex))
                    vertices.Add(e.Source);
            }
            return vertices;
        }


        public List<Vertex> GetNeighborsOf(Vertex vertex)
        {
            List<Vertex> vertices = [];
            foreach (var e in Edges)
            {
                if (e.Source.Equals(vertex) || e.Destination.Equals(vertex))
                    vertices.Add(e.Source);
            }
            return vertices;
        }
    }
}
