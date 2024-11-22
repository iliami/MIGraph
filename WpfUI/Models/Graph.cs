namespace WpfUI.Models
{
    public class Graph(string name)
    {
        public string Name { get; set; } = name;
        public readonly IList<Vertex> Vertices = [];
        public readonly IList<Edge> Edges = [];
        
        public readonly IList<IList<bool>> AdjMatrix = [];
        public readonly IList<IList<bool>> IncMatrix = [];
        public readonly IDictionary<Vertex, IList<Vertex>> AdjList = new Dictionary<Vertex, IList<Vertex>>();
        public readonly IDictionary<Vertex, IList<Edge>> IncList = new Dictionary<Vertex, IList<Edge>>();

        public void AddVertex(Vertex vertex)
        {
            for (var i = 0; i < Vertices.Count; i++)
            {
                AdjMatrix[i].Add(false);
            }
            AdjMatrix.Add(Enumerable.Repeat(false, Vertices.Count + 1).ToList());
            
            IncMatrix.Add(Enumerable.Repeat(false, Edges.Count).ToList());

            AdjList[vertex] = [];

            IncList[vertex] = [];

            Vertices.Add(vertex);
        }

        public void AddEdge(Edge edge)
        {
            AdjList[edge.FirstVertex].Add(edge.SecondVertex);
            AdjList[edge.SecondVertex].Add(edge.FirstVertex);

            IncList[edge.FirstVertex].Add(edge);
            IncList[edge.SecondVertex].Add(edge);

            var indexFirstVertex = Vertices.IndexOf(edge.FirstVertex);
            var indexSecondVertex = Vertices.IndexOf(edge.SecondVertex);

            AdjMatrix[indexFirstVertex][indexSecondVertex] = true;
            AdjMatrix[indexSecondVertex][indexFirstVertex] = true;

            for (var i = 0; i < Vertices.Count; i++)
            {
                IncMatrix[i].Add(false);
            }
            IncMatrix[indexFirstVertex][^1] = true;
            IncMatrix[indexSecondVertex][^1] = true;

            Edges.Add(edge);
        }

        public void RemoveVertex(Vertex vertex)
        {
            var indexRemovingVertex = Vertices.IndexOf(vertex);

            foreach (var row in AdjMatrix)
            {
                row.RemoveAt(indexRemovingVertex);
            }
            AdjMatrix.RemoveAt(indexRemovingVertex);

            foreach (var adjVertex in AdjList[vertex])
            {
                AdjList[adjVertex].Remove(vertex);
            }
            AdjList.Remove(vertex);

            var incEdges = IncList[vertex];
            var indeciesIncEdges = incEdges.Select((e, i) => Edges.IndexOf(e) - i).ToList();
            foreach (var indexIncEdge in indeciesIncEdges)
            {
                foreach (var row in IncMatrix)
                {
                    row.RemoveAt(indexIncEdge);
                }
            }
            IncMatrix.RemoveAt(indexRemovingVertex);

            foreach (var incEdge in incEdges)
            {
                Edges.Remove(incEdge);

                var otherVertex = ( incEdge.FirstVertex == vertex ) ? incEdge.SecondVertex : incEdge.FirstVertex;
                IncList[otherVertex].Remove(incEdge);
            }
            IncList.Remove(vertex);

            Vertices.Remove(vertex);
        }

        public void RemoveEdge(Edge edge)
        {
            var indexFirstVertex = Vertices.IndexOf(edge.FirstVertex);
            var indexSecondVertex = Vertices.IndexOf(edge.SecondVertex);

            AdjMatrix[indexFirstVertex][indexSecondVertex] = false;
            AdjMatrix[indexSecondVertex][indexFirstVertex] = false;

            AdjList[edge.FirstVertex].Remove(edge.SecondVertex);
            AdjList[edge.SecondVertex].Remove(edge.FirstVertex);

            var indexRemovingEdge = Edges.IndexOf(edge);

            foreach (var row in IncMatrix)
            {
                row.RemoveAt(indexRemovingEdge);
            }

            IncList[edge.FirstVertex].Remove(edge);
            IncList[edge.SecondVertex].Remove(edge);

            Edges.Remove(edge);
        }
    }
}
