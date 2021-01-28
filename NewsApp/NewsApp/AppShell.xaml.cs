using System;
using System.Collections.Generic;
using NewsApp.ViewModels;
using NewsApp.Views;
using Xamarin.Forms;

namespace NewsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
