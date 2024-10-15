using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Models
{
    public class Vertex(string name, double xPos, double yPos, int diameter = 20)
    {
        public string Name { get; set; } = name;
        public double XPos { get; set; } = xPos;
        public double CanvasLeft { get; set; } = xPos - diameter / 2;
        public double YPos { get; set; } = yPos;
        public double CanvasTop { get; set; } = yPos - diameter / 2;
        public int Diameter { get; set; } = diameter;


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
