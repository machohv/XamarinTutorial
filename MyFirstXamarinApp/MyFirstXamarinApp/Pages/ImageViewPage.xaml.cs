﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyFirstXamarinApp.Pages
{
    public partial class ImageViewPage : ContentPage
    {
        public ImageViewPage(string imagePath)
        {
            InitializeComponent();
            BigImage.Source = imagePath;
        }
    }
}
