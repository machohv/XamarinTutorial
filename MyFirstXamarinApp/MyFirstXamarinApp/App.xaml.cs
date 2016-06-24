using MyFirstXamarinApp.Pages;
using MyFirstXamarinApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyFirstXamarinApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }

        public static SQLiteService sqliteService { get; internal set; }

        public static ApiService apiService { get; internal set; }

        public static string noteType { get; internal set; }

        public App(string dbPath)
        {

            InitializeComponent();

            Navigator = new NavigatorPage(new MainPage());
            sqliteService = new SQLiteService(dbPath);
            apiService = new ApiService();
            MainPage = Navigator;
            
        }

        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
