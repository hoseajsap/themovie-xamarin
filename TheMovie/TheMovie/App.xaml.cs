using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TheMovie.Services;
using TheMovie.Views;

namespace TheMovie
{
    public partial class App : Application
    {

        public App ()
        {

            DependencyService.Register<IApiService, ApiService>();
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

