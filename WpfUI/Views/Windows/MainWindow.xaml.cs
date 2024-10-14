using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfUI.Models;
using WpfUI.ViewModels;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ___No_Name__MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas != null)
            {

                var context = DataContext as MainWindowViewModel;
                if (context != null)
                {
                    var p = e.GetPosition(canvas);
                    
                    context.VertexCount += 1;
                    var v = new Vertex(context.VertexCount.ToString(), p.X, p.Y);

                    context.AddVertexCommand.Execute(v);

                    var ellipse = new Ellipse()
                    {
                        Width=20,
                        Height=20,
                        Fill = Brushes.Blue
                    };

                    Canvas.SetLeft(ellipse, p.X);
                    Canvas.SetTop(ellipse, p.Y);
                    canvas.Children.Add(ellipse);
                }
            }
        }
    }
}