using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using WpfUI.Infrastructure.Commands;
using WpfUI.Models;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public enum GraphMode
    {
        Default,
        AddVertex,
        AddEdge
    }

    public class GraphViewModel : ViewModel
    {

        #region Graph

        private Graph _Graph;
        public Graph Graph
        {
            get => _Graph;
            set => Set(ref _Graph, value);
        }

        #endregion

        #region CurrentMode

        private GraphMode _CurrentMode = GraphMode.Default;
        public GraphMode CurrentMode
        {
            get => _CurrentMode;
            set => Set(ref _CurrentMode, value);
        }

        #endregion

        #region SelectedVertex

        private VertexViewModel? _SelectedVertex;
        public VertexViewModel? SelectedVertex
        {
            get => _SelectedVertex;
            set => Set(ref _SelectedVertex, value);
        }

        #endregion

        #region SelectedVertexPrevColor

        private Color _SelectedVertexPrevColor;
        public Color SelectedVertexPrevColor
        {
            get => _SelectedVertexPrevColor;
            set => Set(ref _SelectedVertexPrevColor, value);
        }

        #endregion

        #region Vertices

        private ObservableCollection<VertexViewModel> _Vertices;
        public ObservableCollection<VertexViewModel> Vertices
        {
            get => _Vertices;
            set => Set(ref _Vertices, value);
        }

        #endregion

        #region Edges

        private ObservableCollection<EdgeViewModel> _Edges;
        public ObservableCollection<EdgeViewModel> Edges
        {
            get => _Edges;
            set => Set(ref _Edges, value);
        }

        #endregion

        #region X

        private double _X;
        public double X
        {
            get => _X;
            set
            {
                value = Math.Round(value, 2);
                Set(ref _X, value);
            }
        }

        #endregion

        #region Y

        private double _Y;
        public double Y
        {
            get => _Y;
            set
            {
                value = Math.Round(value, 2);
                Set(ref _Y, value);
            }
        }

        #endregion



        #region AddVertexCommand

        public ICommand AddVertexCommand { get; }

        public void OnAddVertexCommandExecuted(object? parameter)
        {
            var vertex = new Vertex(Vertices.Count.ToString(), X, Y);
            var vertexViewModel = new VertexViewModel(vertex);

            Graph.AddVertex(vertex);
            Vertices.Add(vertexViewModel);
        }

        public bool CanAddVertexCommandExecute(object? parameter)
            => CurrentMode == GraphMode.AddVertex;

        #endregion

        #region SelectVertexCommand

        public ICommand SelectVertexCommand { get; }

        public void OnSelectVertexCommandExecuted(object? parameter)
        {
            if (parameter is VertexViewModel vertexViewModel)
            {
                if (SelectedVertex is null)
                {
                    SelectedVertex = vertexViewModel;
                    SelectedVertexPrevColor = SelectedVertex.BackgroundColor;

                    int offset = 40;

                    SelectedVertex.BackgroundColor = Color.FromRgb(
                        (SelectedVertex.BackgroundColor.R > offset ) ? Convert.ToByte(SelectedVertex.BackgroundColor.R - offset) : SelectedVertex.BackgroundColor.R,
                        (SelectedVertex.BackgroundColor.G > offset ) ? Convert.ToByte(SelectedVertex.BackgroundColor.G - offset) : SelectedVertex.BackgroundColor.G,
                        (SelectedVertex.BackgroundColor.B > offset ) ? Convert.ToByte(SelectedVertex.BackgroundColor.B - offset) : SelectedVertex.BackgroundColor.B
                        );
                }
                else if (CurrentMode == GraphMode.AddEdge)
                {
                    (var firstVertex, var secondVertex) = (SelectedVertex.Vertex, vertexViewModel.Vertex);

                    var edge = new Edge(Edges.Count.ToString(), firstVertex, secondVertex);
                    var edgeViewModel = new EdgeViewModel(edge, SelectedVertex, vertexViewModel);

                    Graph.Edges.Add(edge);
                    Edges.Add(edgeViewModel);

                    SelectedVertex.BackgroundColor = SelectedVertexPrevColor;
                    SelectedVertex = null;
                }
            }
        }

        public bool CanSelectVertexCommandExecute(object? parameter)
            => CurrentMode == GraphMode.Default || CurrentMode == GraphMode.AddEdge;

        #endregion

        #region UnselectVertexCommand

        public ICommand UnselectVertexCommand { get; }

        public void OnUnselectVertexCommandExecuted(object? parameter)
        {
            if (SelectedVertex is not null)
            {
                SelectedVertex.BackgroundColor = SelectedVertexPrevColor;
                SelectedVertex = null;
            }
        }

        public bool CanUnselectVertexCommandExecute(object? parameter)
            => SelectedVertex is not null && CurrentMode == GraphMode.Default;

        #endregion

        #region MoveVertexCommand

        public ICommand MoveVertexCommand { get; }

        public void OnMoveVertexCommandExecuted(object? parameter)
        {
            if (SelectedVertex is not null)
            {
                SelectedVertex.X = X;
                SelectedVertex.Y = Y;
            }
        }

        public bool CanMoveVertexCommandExecute(object? parameter)
            => SelectedVertex is not null && CurrentMode == GraphMode.Default;

        #endregion

        public GraphViewModel(Graph graph)
        {
            _Graph = graph;
            _Vertices = new(graph.Vertices.Select(static v => new VertexViewModel(v)));
            _Edges = new(graph.Edges.Select(e => new EdgeViewModel(e, _Vertices.First(v => e.FirstVertex == v.Vertex), _Vertices.First(v => e.SecondVertex == v.Vertex))));

            AddVertexCommand = new LambdaCommand(OnAddVertexCommandExecuted, CanAddVertexCommandExecute);
            SelectVertexCommand = new LambdaCommand(OnSelectVertexCommandExecuted, CanSelectVertexCommandExecute);
            UnselectVertexCommand = new LambdaCommand(OnUnselectVertexCommandExecuted, CanUnselectVertexCommandExecute);
            MoveVertexCommand = new LambdaCommand(OnMoveVertexCommandExecuted, CanMoveVertexCommandExecute);
        }
    }
}
