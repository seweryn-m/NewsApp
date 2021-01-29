using NewsApp.Models;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using NewsApp.ViewModels;

namespace NewsApp.Views
{
    public partial class ArticleDetailsPage : ContentPage
    {
        public ArticleDetailsPage(ArticleDetails details)
        {
            InitializeComponent();
            var viewModel = Startup.ServiceProvider.GetService<ArticleDetailsViewModel>();
            viewModel.Details = details;

            BindingContext = viewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }

        void ScrollView_Scrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
        }
    }
}
