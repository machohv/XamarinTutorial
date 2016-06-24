using GalaSoft.MvvmLight.Command;
using MyFirstXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstXamarinApp.ViewModels
{
    public class MainViewModel
    {
        NavigationService navigationService;

        public MainViewModel()
        {
            navigationService = new NavigationService();
        }
        

        public ICommand GoToCommand { get { return new RelayCommand<string>(GoTo); } }

        private void GoTo(string pageName)
        {
            navigationService.Navigate(pageName);
        }
        
    }
}
