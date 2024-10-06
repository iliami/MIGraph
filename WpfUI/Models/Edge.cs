using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Models
{
    public class Edge(string name, Vertex firstVertex, Vertex secondVertex)
    {
        public string Name { get; set; } = name;
        public Vertex FirstVertex { get; set; } = firstVertex;
        public Vertex SecondVertex { get; set; } = secondVertex;

        public static bool operator ==(Edge left, Edge right)
            => left.Name == right.Name 
            && left.FirstVertex == right.FirstVertex 
            && left.SecondVertex == right.SecondVertex;
        public static bool operator !=(Edge left, Edge right)
            => !(left == right);
    }
}
