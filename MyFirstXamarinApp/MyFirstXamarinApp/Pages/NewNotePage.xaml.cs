using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstXamarinApp.Models;
using MyFirstXamarinApp.Services;

using Xamarin.Forms;
using Plugin.Media;

namespace MyFirstXamarinApp.Pages
{
    public partial class NewNotePage : ContentPage
    {
        private string imagePath = "";
        public NewNotePage()
        {
            InitializeComponent();
        }

        public async void SaveNote(object sender, EventArgs args)
        {
            string message = "";
            if (imagePath == "")
            {
                imagePath = "icon.png";
            }

            if (App.noteType == "local")
            {
                LocalNote note = new LocalNote
                {
                    Title = Title.Text,
                    Description = Description.Text,
                    Date = Date.Date,
                    ImagePath = imagePath
                };

                App.sqliteService.AddNewNote(note);
                message = App.sqliteService.StatusMessage;

                
            }
            else
            {
                OnlineNote note = new OnlineNote
                {
                    Title = Title.Text,
                    Description = Description.Text,
                    Date = Date.Date,
                    ImagePath = imagePath
                };

                await App.apiService.AddNote(note);
                message = "Nota agregada correctamente a la nube";
            }
            await App.Navigator.DisplayAlert("Información", message, "Ok");
        }

        public async void TakePhoto(object sender, EventArgs args)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "Ok");
                return;
            }

            var file = await CrossMedia.Current.
                TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions {
                SaveToAlbum = true
            });

            if (file== null)
            {
                return;
            }

            imagePath = file.AlbumPath;

            ImagePreview.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                }
            );
        }
    }
}
