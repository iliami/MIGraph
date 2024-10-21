using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Models
{
    public class Graph(string name)
    {
        public string Name { get; set; } = name;
        public readonly ICollection<Vertex> Vertices = [];
        public readonly ICollection<Edge> Edges = [];
    }
}
