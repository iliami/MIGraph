namespace WpfUI.Models
{
    public class Vertex(string name, double x, double y)
    {
        public string Name { get; set; } = name;
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
        public double Weight { get; set; } = 0;

        public override string ToString()
        {
            var result = ( Weight == 0 ) ? 
                $"Имя {Name:16} | Положение ({X:f2}; {Y:f2})" : 
                $"Имя {Name:16} | Положение ({X:f2}; {Y:f2}) | Вес {Weight}";
            return result;
        }
    }
}
