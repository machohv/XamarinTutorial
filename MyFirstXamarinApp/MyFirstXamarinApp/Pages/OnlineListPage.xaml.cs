using MyFirstXamarinApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyFirstXamarinApp.Pages
{
    public partial class OnlineListPage : ContentPage
    {
        public ObservableCollection<OnlineNote> Notes { get; set; }
        public OnlineListPage()
        {
            InitializeComponent();
            Notes = new ObservableCollection<OnlineNote>();
        }

        protected override async void OnAppearing()
        {
            var list = await App.apiService.GetAllNotes();
            Notes.Clear();
            foreach (var item in list)
            {
                Notes.Add(item);
            }

            listaNotas.ItemsSource = Notes;
        }

        public void OpenImage(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                App.Navigator.PushAsync(
                    new ImageViewPage(((OnlineNote)listaNotas.SelectedItem).ImagePath));
            }
        }
    }
}
