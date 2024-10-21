namespace WpfUI.Models
{
    public class Edge(string name, Vertex firstVertex, Vertex secondVertex)
    {
        public string Name { get; set; } = name;
        public Vertex FirstVertex { get; set; } = firstVertex;
        public Vertex SecondVertex { get; set; } = secondVertex;
    }
}
