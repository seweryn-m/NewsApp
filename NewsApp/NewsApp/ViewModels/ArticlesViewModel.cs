using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NewsApp.Models;
using NewsApp.Services.Interfaces;
using NewsApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class ArticlesViewModel : BaseViewModel
    {
        private readonly IArticlesService _articlesService;
        
        public ArticlesViewModel(IArticlesService articlesService)
        {
            _articlesService = articlesService;

            RefreshCommand = new Command(
                execute: async () =>
                {
                    await GetArticles();
                },
                canExecute: () =>
                {
                    return !IsExecuted;
                });

            GoToDetailsCommand = new Command(
                execute: async () =>
                {
                    await GoToDetails();
                },
                canExecute: () =>
                {
                    return !IsExecuted;
                });
        }

        public ICommand RefreshCommand { protected set; get; }
        public ICommand GoToDetailsCommand { protected set; get; }
        public ICommand ItemThresholdReachedCommand { protected set; get; }

        private bool _isExecuted;
        public bool IsExecuted
        {
            get => _isExecuted;
            set
            {
                SetProperty(ref _isExecuted, value);
            }
        }

        private int _itemThreshold;
        public int ItemThreshold
        {
            get => _itemThreshold;
            set
            {
                SetProperty(ref _itemThreshold, value);
            }
        }

        private Article _article;
        public Article Article
        {
            get => _article;
            set
            {
                SetProperty(ref _article, value);
            }
        }

        private ObservableCollection<Article> _articles;
        public ObservableCollection<Article> Articles
        {
            get => _articles;
            set
            {
                SetProperty(ref _articles, value);
            }
        }

        private async Task GoToDetails()
        {
            IsExecuted = true;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("News", "Brak połączenia z internetem", "Ok");
                return;
            }

            var details = await _articlesService.GetArticleDetailsFromAPI(Article.url);
            await Application.Current.MainPage.Navigation.PushAsync(new ArticleDetailsPage(details));
            Article = null;

            IsExecuted = false;
        }

        public async Task GetArticles()
        {
            IsExecuted = true;

            if(Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                int paggination = 0;
                if (Articles != null)
                    paggination = Articles.Count;

                var articles = await _articlesService.GetArticlesFromAPI(paggination);
                if(articles != null)
                    Articles = new ObservableCollection<Article>(articles);
            }

            IsExecuted = false;
            ItemThreshold = 1;
        }
    }
}
