using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.Models.Base;

namespace WpfUI.Models
{
    public class Vertex(string name, double xPos, double yPos, int diameter = 20) : INPC
    {
        #region Name

        private string _Name = name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        #endregion

        #region XPos

        private double _XPos = xPos;
        public double XPos
        {
            get => _XPos;
            set
            {
               Set(ref _XPos, value);
               CanvasLeft = _XPos - _Diameter / 2;
            }
        }

        #endregion

        #region CanvasLeft

        private double _CanvasLeft = xPos - diameter / 2;
        public double CanvasLeft
        {
            get => _CanvasLeft;
            set => Set(ref _CanvasLeft, value);
        }

        #endregion

        #region YPos

        private double _YPos = yPos;
        public double YPos
        {
            get => _YPos;
            set
            {
                Set(ref _YPos, value);
                CanvasTop = _YPos - _Diameter / 2;
            }
        }

        #endregion

        #region CanvasTop

        private double _CanvasTop = yPos - diameter / 2;
        public double CanvasTop
        {
            get => _CanvasTop;
            set => Set(ref _CanvasTop, value);
        }

        #endregion

        #region Diameter

        private int _Diameter = diameter;
        public int Diameter
        {
            get => _Diameter;
            set => Set(ref _Diameter, value);
        }

        #endregion

        public static bool operator ==(Vertex left, Vertex right)
            => left.Name == right.Name 
            && left.XPos == right.XPos 
            && left.YPos == right.YPos;
        public static bool operator !=(Vertex left, Vertex right)
            => !(left == right);

        public override bool Equals(object? obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
