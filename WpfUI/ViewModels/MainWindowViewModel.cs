using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfUI.ViewModels.Base;

namespace WpfUI.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
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
    }
}
