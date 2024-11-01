using System.Windows.Media;
using WpfUI.Models;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public class VertexViewModel : ViewModel
    {
        #region Vertex

        private Vertex _Vertex;
        public Vertex Vertex
        {
            get => _Vertex;
            set => Set(ref _Vertex, value);
        }

        #endregion

        #region Name

        public string Name
        {
            get => Vertex.Name;
            set
            {
                Vertex.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        #endregion

        #region X

        public double X
        {
            get => Vertex.X;
            set
            {
                Vertex.X = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanvasLeft));
            }
        }

        #endregion

        #region Y

        public double Y
        {
            get => Vertex.Y;
            set
            {
                Vertex.Y = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanvasTop));
            }
        }

        #endregion

        #region CanvasLeft

        public double CanvasLeft => X - Diameter / 2;

        #endregion

        #region CanvasTop

        public double CanvasTop => Y - Diameter / 2;

        #endregion

        #region Diameter

        private int _Diameter = 40;
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

        public VertexViewModel(Vertex vertex)
        {
            _Vertex = vertex;
            _ForegroundColor = Colors.WhiteSmoke;
            _Foreground = new SolidColorBrush(_ForegroundColor);
            _BackgroundColor = Color.FromRgb(34, 85, 119);
            _Background = new SolidColorBrush(_BackgroundColor);
        }
    }
}
