using WpfUI.Models;
using WpfUI.ModelsFacade.Base;

namespace WpfUI.ModelsFacade
{
    public class EdgeFacade(Edge edge) : INPC
    {
        private Edge _Edge = edge;

        public string Name
        {
            get => _Edge.Name;
            set
            {
                _Edge.Name = value;
                OnPropertyChanged();
            }
        }

        public Vertex FirstVertex
        {
            get => _Edge.FirstVertex;
            set
            {
                _Edge.FirstVertex = value;
                OnPropertyChanged();
            }
        }

        public Vertex SecondVertex
        {
            get => _Edge.SecondVertex;
            set
            {
                _Edge.SecondVertex = value;
                OnPropertyChanged();
            }
        }
    }
}
