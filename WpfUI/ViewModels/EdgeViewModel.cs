using System.Windows.Media;
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

        #region Weight

        public double Weight
        {
            get => Edge.Weight;
            set
            {
                Edge.Weight = value;
                OnPropertyChanged(nameof(Weight));
                OnPropertyChanged(nameof(IsWeightVisible));
            }
        }

        #endregion

        #region IsWeightVisible

        public bool IsWeightVisible => Weight > 0;

        #endregion

        #region Diameter

        private int _Diameter = 28;
        public int Diameter
        {
            get => _Diameter;
            set => Set(ref _Diameter, value);
        }

        #endregion

        #region FontSize

        public int FontSize => 2 * Diameter / 3;

        #endregion

        #region ForegroundColor

        private Color _ForegroundColor;
        public Color ForegroundColor
        {
            get => _ForegroundColor;
            set
            {
                Set(ref _ForegroundColor, value);
                Foreground = new SolidColorBrush(value);
            }
        }

        #endregion

        #region Foreground

        private Brush _Foreground;
        public Brush Foreground
        {
            get => _Foreground;
            set => Set(ref _Foreground, value);
        }

        #endregion

        #region BackgroundColor

        private Color _BackgroundColor;
        public Color BackgroundColor
        {
            get => _BackgroundColor;
            set
            {
                Set(ref _BackgroundColor, value);
                Background = new SolidColorBrush(value);
            }
        }

        #endregion

        #region Background

        private Brush _Background;
        public Brush Background
        {
            get => _Background;
            set => Set(ref _Background, value);
        }

        #endregion

        #region Thickness

        private int _Thickness;
        public int Thickness
        {
            get => _Thickness;
            set => Set(ref _Thickness, value);
        }

        #endregion

        public EdgeViewModel(Edge edge, VertexViewModel firstVertex, VertexViewModel secondVertex)
        {
            _Edge = edge;
            _FirstVertex = firstVertex;
            _SecondVertex = secondVertex;
            _ForegroundColor = Colors.White;
            _Foreground = new SolidColorBrush(_ForegroundColor);
            _BackgroundColor = Colors.Black;
            _Background = new SolidColorBrush(_BackgroundColor);
            _Thickness = 6;
        }
    }
}
