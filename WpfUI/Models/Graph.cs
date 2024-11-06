namespace WpfUI.Models
{
    public class Graph(string name)
    {
        public string Name { get; set; } = name;
        public readonly IList<Vertex> Vertices = [];
        public readonly IList<Edge> Edges = [];
        
        public void AddVertex(Vertex vertex)
        {
            Vertices.Add(vertex);
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void RemoveVertex(Vertex vertex)
        {
            Vertices.Remove(vertex);
        }

        public void RemvoeEdge(Edge edge)
        {
            Edges.Remove(edge);
        }
    }
}
