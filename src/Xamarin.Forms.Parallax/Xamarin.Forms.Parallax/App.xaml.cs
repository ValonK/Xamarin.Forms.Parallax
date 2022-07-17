using System;
using Xamarin.Forms;
using Xamarin.Forms.Parallax.Pages;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Parallax
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
