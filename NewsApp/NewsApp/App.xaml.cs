using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewsApp.Services;
using NewsApp.Views;
using NewsApp.Configuration;
using Microsoft.EntityFrameworkCore;

namespace NewsApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            var db = new NewsDbContext();
            db.Database.Migrate();
            Startup.Init();
            MainPage = new AppShell();
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
