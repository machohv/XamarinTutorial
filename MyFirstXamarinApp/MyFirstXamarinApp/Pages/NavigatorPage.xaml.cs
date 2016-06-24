using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyFirstXamarinApp.Pages
{
    public partial class NavigatorPage : NavigationPage
    {
        public NavigatorPage(CarouselPage page)
        {
            this.PushAsync(page);
            InitializeComponent();
        }
    }
}
