using System.ComponentModel;
using Xamarin.Forms;
using NewsApp.ViewModels;

namespace NewsApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}