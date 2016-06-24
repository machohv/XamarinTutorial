using MyFirstXamarinApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstXamarinApp.Services
{
    public class NavigationService
    {
        public async void Navigate(string PageName)
        {
            switch (PageName)
            {
                case "NewNotePage":
                    App.noteType = "local";
                    await Navigate(new NewNotePage());
                    break;
                case "NewOnlineNotePage":
                    App.noteType = "online";
                    await Navigate(new NewNotePage());
                    break;
                default:
                    break;
            }
        }

        private static async Task Navigate<T>(T page) where T : Page
        {
            await App.Navigator.PushAsync(page);
        }
    }
}
