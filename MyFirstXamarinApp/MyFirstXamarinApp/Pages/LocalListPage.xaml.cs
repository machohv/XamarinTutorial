using Android.Graphics;
using MyFirstXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;

namespace MyFirstXamarinApp.Pages
{
    public partial class LocalListPage : ContentPage
    {
        public ObservableCollection<LocalNote> Notes { get; set; }
        public LocalListPage()
        {
            InitializeComponent();
            Notes = new ObservableCollection<LocalNote>();
        }

        protected override async void OnAppearing()
        {
            var list = App.sqliteService.GetAllNotes();
            Notes.Clear();
            foreach (var item in list)
            {
                Notes.Add(item);
            }
            
            listaNotas.ItemsSource = Notes;
        }

        public void OpenImage(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null )
            {
                App.Navigator.PushAsync(
                    new ImageViewPage(((LocalNote)listaNotas.SelectedItem).ImagePath));
            }
        }



    }
}
