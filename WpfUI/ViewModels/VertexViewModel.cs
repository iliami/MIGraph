using WpfUI.Models;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public class VertexViewModel(Vertex vertex) : ViewModel
    {
        #region Vertex

        private Vertex _Vertex = vertex;
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

        private double _X = vertex.X;
        public double X
        {
            get => _X;
            set
            {
                Vertex.X = value;
                Set(ref _X, value);
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
    }
}
