using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models;
using WpfUI.ModelsFacade.Base;

namespace WpfUI.ModelsFacade
{
    public class GraphFacade(Graph graph) : INPC
    {
        private Graph _Graph = graph;

        public ObservableCollection<VertexFacade> Verteces 
            => new(_Graph.Vertices.Select(v => new VertexFacade(v)));

        public ObservableCollection<EdgeFacade> Edges
            => new(_Graph.Edges.Select(v => new EdgeFacade(v)));
    }
}
