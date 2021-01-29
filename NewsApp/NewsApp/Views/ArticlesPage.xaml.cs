using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NewsApp.ViewModels;
using Xamarin.Forms;

namespace NewsApp.Views
{
    public partial class ArticlesPage : ContentPage
    {
        public ArticlesPage()
        {
            InitializeComponent();
            var viewModel = Startup.ServiceProvider.GetService<ArticlesViewModel>();

            Task.Run(async () =>
            {
                await viewModel.GetArticles();
            }).Wait();

            BindingContext = viewModel;
        }
    }
}
