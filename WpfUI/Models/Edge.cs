namespace WpfUI.Models
{
    public class Edge(string name, Vertex firstVertex, Vertex secondVertex)
    {
        public string Name { get; set; } = name;
        public Vertex FirstVertex { get; set; } = firstVertex;
        public Vertex SecondVertex { get; set; } = secondVertex;
        public double Weight { get; set; } = 0;

        public override string ToString()
        {
            var result = ( Weight == 0 ) ? 
                $"Имя {Name:16} | Вершины [ {FirstVertex.Name:16} ({FirstVertex.X:f2}; {FirstVertex.Y:f2}) | " +
                $"{SecondVertex.Name:16} ({SecondVertex.X:f2}; {SecondVertex.Y:f2}) ]" : 
                $"Имя {Name:16} | Вершины [ {FirstVertex.Name:16} ({FirstVertex.X:f2}; {FirstVertex.Y:f2}) | " +
                $"{SecondVertex.Name:16} ({SecondVertex.X:f2}; {SecondVertex.Y:f2}) ] | Вес {Weight}";
            return result;
        }
    }
}
