using System.Windows;
using System.Windows.Input;
using WpfUI.Infrastructure.Commands;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        #region Модели-представления

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

        #endregion

        #region Команды

        #region CloseApplicationCommand

        public ICommand CloseApplicationCommand { get; private set; }

        public bool CanCloseApplicationCommandExecute(object? parameter) => true;

        public void OnCloseApplicationCommandExecuted(object? parameter)
            => Application.Current.Shutdown();

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Команды

            CloseApplicationCommand = new LambdaCommand(
                OnCloseApplicationCommandExecuted,
                CanCloseApplicationCommandExecute);

            #endregion
        }
    }
}
