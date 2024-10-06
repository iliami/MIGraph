using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Models
{
    public class Vertex(string name, double xPos, double yPos)
    {
        public string Name { get; set; } = name;
        public double XPos { get; set; } = xPos;
        public double YPos { get; set; } = yPos;


        public static bool operator ==(Vertex left, Vertex right)
            => left.Name == right.Name 
            && left.XPos == right.XPos 
            && left.YPos == right.YPos;
        public static bool operator !=(Vertex left, Vertex right)
            => !(left == right);
    }
}
