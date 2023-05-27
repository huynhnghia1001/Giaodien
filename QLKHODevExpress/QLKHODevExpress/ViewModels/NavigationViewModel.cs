using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLKHODevExpress.Utilities;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKHODevExpress.ViewModels
{
    class NavigationViewModel : Utilities.ViewModelBase
    {
        private object _currentView;
        public object CurrentView 
        { 
            get { return _currentView; } 
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand HelpCommand { get; set; }
        public ICommand AboutCommand { get; set; }
        public ICommand SettingCommand { get; set; }

        private void Help(object obj) => CurrentView = new HelpViewModel();
        private void About(object obj) => CurrentView = new AboutViewModel();
        private void Setting(object obj) => CurrentView = new SettingViewModel();

        public NavigationViewModel()
        {
            HelpCommand = new RelayCommand(Help);
            AboutCommand = new RelayCommand(About);
            SettingCommand = new RelayCommand(Setting);

            //Startup Page
            CurrentView = new MainViewModel();
        }
    }
}
