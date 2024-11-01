using WpfUI.Models;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public class EdgeViewModel : ViewModel
    {

        #region Edge

        private Edge _Edge;
        public Edge Edge
        {
            get => _Edge;
            set => Set(ref _Edge, value);
        }

        #endregion

        #region Name

        public string Name
        {
            get => Edge.Name;
            set
            {
                Edge.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        #endregion

        #region FirstVertex

        private VertexViewModel _FirstVertex;
        public VertexViewModel FirstVertex
        {
            get => _FirstVertex;
            set => Set(ref _FirstVertex, value);
        }

        #endregion

        #region SecondVertex

        private VertexViewModel _SecondVertex;
        public VertexViewModel SecondVertex
        {
            get => _SecondVertex;
            set => Set(ref _SecondVertex, value);
        }

        #endregion

        public EdgeViewModel(Edge edge, VertexViewModel firstVertex, VertexViewModel secondVertex)
        {
            _Edge = edge;
            _FirstVertex = firstVertex;
            _SecondVertex = secondVertex;
        }
    }
}
