using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics.Drawables;
using Java.IO;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using Plugin.Media;

namespace MyFirstXamarinApp.Droid
{
    [Activity(Label = "MyFirstXamarinApp", Icon = "@drawable/ic_launcher",
        Theme = "@android:style/Theme.Material.Light.DarkActionBar",
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        static readonly File file =
            new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            string dbPath = FileAccessHelper.GetLocalFilePath("Note.db3");

            await CrossMedia.Current.Initialize();

            LoadApplication(new App(dbPath));

            ActionBar.SetIcon(
                new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));

         }

    }
}

