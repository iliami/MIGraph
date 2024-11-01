namespace WpfUI.Models
{
    public class Vertex(string name, double x, double y)
    {
        public string Name { get; set; } = name;
        public double X { get; set; } = x;
        public double Y { get; set; } = y;
    }
}
