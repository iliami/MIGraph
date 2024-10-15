using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfUI.Infrastructure.Commands;
using WpfUI.Models;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Свойства

        #region Title

        private string _Title = "Заголовок окна";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region Status

        private string _Status = "Статус приложения";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        #endregion

        #region Verteces

        private ObservableCollection<Vertex> _Verteces = new();
        public ObservableCollection<Vertex> Verteces
        {
            get => _Verteces;
            set => Set(ref _Verteces, value);
        }

        #endregion

        #region Edges

        private ObservableCollection<Edge> _Edges = new();
        public ObservableCollection<Edge> Edges
        {
            get => _Edges;
            set => Set(ref _Edges, value);
        }

        #endregion

        #region IsVertexAddingMode

        private bool _IsVertexAddingMode;
        public bool IsVertexAddingMode
        {
            get => _IsVertexAddingMode;
            set => Set(ref _IsVertexAddingMode, value);
        }

        #endregion

        #region IsEdgeAddingMode

        private bool _IsEdgeAddingMode;
        public bool IsEdgeAddingMode
        {
            get => _IsEdgeAddingMode;
            set => Set(ref _IsEdgeAddingMode, value);
        }

        #endregion

        #region VertexCount

        private int _VertexCount;
        public int VertexCount
        {
            get => _VertexCount;
            set => Set(ref _VertexCount, value);
        }

        #endregion

        #region X

        private double _X;
        public double X
        {
            get => _X;
            set {
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

        #region SelectedVertex1

        private Vertex? _SelectedVertex1;
        public Vertex? SelectedVertex1
        {
            get => _SelectedVertex1;
            set => Set(ref _SelectedVertex1, value);
        }

        #endregion

        #region SelectedVertex2

        private Vertex? _SelectedVertex2;
        public Vertex? SelectedVertex2
        {
            get => _SelectedVertex2;
            set => Set(ref _SelectedVertex2, value);
        }

        #endregion

        #endregion

        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; }

        public bool CanCloseApplicationCommandExecute(object? parameter) => true;

        public void OnCloseApplicationCommandExecuted(object? parameter)
            => Application.Current.Shutdown();

        #endregion

        #region AddVertexCommand

        public ICommand AddVertexCommand { get; }

        public void OnAddVertexCommandExecuted(object? parameter)
        {
            VertexCount += 1;
            var v = new Vertex(VertexCount.ToString(), X, Y);
            Verteces.Add(v);
        }
        #endregion

        #region RemoveVertexCommand
        public ICommand RemoveVertexCommand { get; }

        public void OnRemoveVertexCommandExecuted(object? parameter)
        {
            if (parameter is Vertex v)
            {
                var vToRemove = Verteces.FirstOrDefault(vertex => vertex == v);

                if (vToRemove is null)
                {
                    return;
                }

                Verteces.Remove(vToRemove);
            }
        }
        #endregion

        #region SelectVertecesCommand
        public ICommand SelectVertecesCommand { get; }

        public void OnSelectVertecesCommandExecuted(object? parameter)
        {
            if (parameter is Vertex v)
            {
                if (SelectedVertex1 is null)
                {
                    SelectedVertex1 = v;
                }
                else
                {
                    SelectedVertex2 = v;
                    Edge e = new("", SelectedVertex1, SelectedVertex2);

                    Edges.Add(e);

                    (SelectedVertex1, SelectedVertex2) = (null, null);
                }
            }
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(
                OnCloseApplicationCommandExecuted,
                CanCloseApplicationCommandExecute);

            AddVertexCommand = new LambdaCommand(
                OnAddVertexCommandExecuted);

            RemoveVertexCommand = new LambdaCommand(
                OnRemoveVertexCommandExecuted);

            SelectVertecesCommand = new LambdaCommand(
                OnSelectVertecesCommandExecuted);

            #endregion

        }
    }
}
