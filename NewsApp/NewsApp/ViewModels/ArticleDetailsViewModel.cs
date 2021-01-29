using System;
using System.Threading.Tasks;
using System.Windows.Input;
using NewsApp.Models;
using NewsApp.Services.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class ArticleDetailsViewModel : BaseViewModel
    {
        private readonly IArticlesService _articlesService;

        public ArticleDetailsViewModel(IArticlesService articlesService)
        {
            _articlesService = articlesService;

            GoBackCommand = new Command(
                execute: async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                },
                canExecute: () =>
                {
                    return !IsExecuted;
                });

            AddRemoveLikedCommand = new Command(
                execute: () =>
                {

                },
                canExecute: () =>
                {
                    return !IsExecuted;
                });

            ShareCommand = new Command(
                execute: async () =>
                {
                    IsExecuted = true;

                    await Share.RequestAsync(new ShareTextRequest
                    {
                        Uri = Details.original_url,
                        Title = "Udostępnij artykuł"
                    });

                    IsExecuted = false;
                },
                canExecute: () =>
                {
                    return !IsExecuted;
                });

            ShowGallery = new Command(
                execute: () =>
                {

                },
                canExecute: () =>
                {
                    return !IsExecuted;
                });
        }

        public ICommand GoBackCommand { protected set; get; }
        public ICommand AddRemoveLikedCommand { protected set; get; }
        public ICommand ShareCommand { protected set; get; }
        public ICommand ShowGallery { protected set; get; }

        private ArticleDetails _details;
        public ArticleDetails Details
        {
            get => _details;
            set
            {
                SetProperty(ref _details, value);
            }
        }

        private bool _isExecuted;
        public bool IsExecuted
        {
            get => _isExecuted;
            set
            {
                SetProperty(ref _isExecuted, value);
            }
        }

        private bool _isLiked;
        public bool IsLiked
        {
            get => _isLiked;
            set
            {
                SetProperty(ref _isLiked, value);
            }
        }

        private async Task CheckIsLiked()
        {
            IsLiked = false;
        }

        private async Task AddRemoveLiked()
        {
            if (!IsLiked)
            {
                IsLiked = true;
                return;
            }

            IsLiked = false;
        }
    }
}
