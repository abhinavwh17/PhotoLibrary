using NetheusLibrary.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetheusLibrary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LibraryView();
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
