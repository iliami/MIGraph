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
        private Color SelectedVertexPrevColor;
        private VertexViewModel? _SelectedVertex;
        public VertexViewModel? SelectedVertex
        {
            get => _SelectedVertex;
            set => Set(ref _SelectedVertex, value);
        }

        #endregion

        #region FirstSelectedVertex
        private Color FirstSelectedVertexPrevColor;
        private VertexViewModel? _FirstSelectedVertex;
        public VertexViewModel? FirstSelectedVertex
        {
            get => _FirstSelectedVertex;
            set => Set(ref _FirstSelectedVertex, value);
        }

        #endregion

        #region SecondSelectedVertex

        private VertexViewModel? _SecondSelectedVertex;
        public VertexViewModel? SecondSelectedVertex
        {
            get => _SecondSelectedVertex;
            set => Set(ref _SecondSelectedVertex, value);
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
            if (SelectedVertex is not null)
            {
                SelectedVertex.BackgroundColor = SelectedVertexPrevColor;
                SelectedVertex = null;
            }
            if (FirstSelectedVertex is not null)
            {
                FirstSelectedVertex.BackgroundColor = FirstSelectedVertexPrevColor;
                FirstSelectedVertex = null;
            }

            var vertex = new Vertex(Vertices.Count.ToString(), X, Y);
            var vertexViewModel = new VertexViewModel(vertex);

            Graph.AddVertex(vertex);
            Vertices.Add(vertexViewModel);
        }

        public bool CanAddVertexCommandExecute(object? parameter)
            => CurrentMode == GraphMode.AddVertex;

        #endregion

        #region SelectVertexOnDefaultModeCommand

        public ICommand SelectVertexOnDefaultModeCommand { get; }

        public void OnSelectVertexOnDefaultModeCommandExecuted(object? parameter)
        {
            if (parameter is VertexViewModel vertexViewModel)
            {
                SelectedVertex = vertexViewModel;
                SelectedVertexPrevColor = SelectedVertex.BackgroundColor;

                if (FirstSelectedVertex is not null)
                {
                    FirstSelectedVertex.BackgroundColor = FirstSelectedVertexPrevColor;
                    FirstSelectedVertex = null;
                }

                int offset = 40;

                SelectedVertex.BackgroundColor = Color.FromRgb(
                    ( SelectedVertex.BackgroundColor.R > offset ) ? Convert.ToByte(SelectedVertex.BackgroundColor.R - offset) : SelectedVertex.BackgroundColor.R,
                    ( SelectedVertex.BackgroundColor.G > offset ) ? Convert.ToByte(SelectedVertex.BackgroundColor.G - offset) : SelectedVertex.BackgroundColor.G,
                    ( SelectedVertex.BackgroundColor.B > offset ) ? Convert.ToByte(SelectedVertex.BackgroundColor.B - offset) : SelectedVertex.BackgroundColor.B
                    );
            }
        }

        public bool CanSelectVertexOnDefaultModeCommandExecute(object? parameter)
            => SelectedVertex is null && CurrentMode == GraphMode.Default;

        #endregion

        #region UnselectVertexOnDefaultModeCommand

        public ICommand UnselectVertexOnDefaultModeCommand { get; }

        public void OnUnselectVertexOnDefaultModeCommandExecuted(object? parameter)
        {
            SelectedVertex!.BackgroundColor = SelectedVertexPrevColor;
            SelectedVertex = null;
        }

        public bool CanUnselectVertexOnDefaultModeCommandExecute(object? parameter)
            => SelectedVertex is not null && CurrentMode == GraphMode.Default;

        #endregion

        #region SelectVerticesAndAddEdgeOnAddEdgeModeCommand

        public ICommand SelectVerticesAndAddEdgeOnAddEdgeModeCommand { get; }

        public void OnSelectVerticesAndAddEdgeOnAddEdgeModeCommandExecuted(object? parameter)
        {
            if (parameter is VertexViewModel vertexViewModel)
            {
                if (FirstSelectedVertex is null)
                {
                    FirstSelectedVertex = vertexViewModel;
                    FirstSelectedVertexPrevColor = FirstSelectedVertex.BackgroundColor;

                    int offset = 40;

                    FirstSelectedVertex.BackgroundColor = Color.FromRgb(
                        ( FirstSelectedVertex.BackgroundColor.R > offset ) ? Convert.ToByte(FirstSelectedVertex.BackgroundColor.R - offset) : FirstSelectedVertex.BackgroundColor.R,
                        ( FirstSelectedVertex.BackgroundColor.G > offset ) ? Convert.ToByte(FirstSelectedVertex.BackgroundColor.G - offset) : FirstSelectedVertex.BackgroundColor.G,
                        ( FirstSelectedVertex.BackgroundColor.B > offset ) ? Convert.ToByte(FirstSelectedVertex.BackgroundColor.B - offset) : FirstSelectedVertex.BackgroundColor.B
                        );
                }
                else
                {
                    SecondSelectedVertex = vertexViewModel;

                    (var firstVertex, var secondVertex) = (FirstSelectedVertex.Vertex, SecondSelectedVertex.Vertex);

                    var edge = new Edge(Edges.Count.ToString(), firstVertex, secondVertex);
                    var edgeViewModel = new EdgeViewModel(edge, FirstSelectedVertex, SecondSelectedVertex);

                    Graph.Edges.Add(edge);
                    Edges.Add(edgeViewModel);

                    FirstSelectedVertex.BackgroundColor = FirstSelectedVertexPrevColor;
                    FirstSelectedVertex = null;
                    SecondSelectedVertex = null;
                }
            }
        }
        public bool CanSelectVerticesAndAddEdgeOnAddEdgeModeCommandExecute(object? parameter)
            => CurrentMode == GraphMode.AddEdge;

        #endregion

        #region MoveVertexCommand

        public ICommand MoveVertexCommand { get; }

        public void OnMoveVertexCommandExecuted(object? parameter)
        {
            SelectedVertex!.X = X;
            SelectedVertex!.Y = Y;
        }

        public bool CanMoveVertexCommandExecute(object? parameter)
        {
            if (parameter is object[] values)
            {
                var width = (double)values[0];
                var height = (double)values[1];

                return SelectedVertex is not null &&
                       CurrentMode == GraphMode.Default &&
                       SelectedVertex.Diameter / 2 < X && X < width - SelectedVertex.Diameter / 2 &&
                       SelectedVertex.Diameter / 2 < Y && Y < height - SelectedVertex.Diameter / 2;
            }
            return false;
        }

        #endregion

        public GraphViewModel(Graph graph)
        {
            _Graph = graph;
            _Vertices = new(graph.Vertices.Select(static v => new VertexViewModel(v)));
            _Edges = new(graph.Edges.Select(e => new EdgeViewModel(e, _Vertices.First(v => e.FirstVertex == v.Vertex), _Vertices.First(v => e.SecondVertex == v.Vertex))));

            AddVertexCommand = new LambdaCommand(OnAddVertexCommandExecuted, CanAddVertexCommandExecute);
            SelectVertexOnDefaultModeCommand = new LambdaCommand(OnSelectVertexOnDefaultModeCommandExecuted, CanSelectVertexOnDefaultModeCommandExecute);
            UnselectVertexOnDefaultModeCommand = new LambdaCommand(OnUnselectVertexOnDefaultModeCommandExecuted, CanUnselectVertexOnDefaultModeCommandExecute);
            MoveVertexCommand = new LambdaCommand(OnMoveVertexCommandExecuted, CanMoveVertexCommandExecute);
            SelectVerticesAndAddEdgeOnAddEdgeModeCommand = new LambdaCommand(OnSelectVerticesAndAddEdgeOnAddEdgeModeCommandExecuted, CanSelectVerticesAndAddEdgeOnAddEdgeModeCommandExecute);
        }
    }
}
