using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsApp.Configuration;
using NewsApp.Services.Interfaces;
using NewsApp.Services.MainServices;
using NewsApp.ViewModels;
using NewsApp.Views;
using Xamarin.Essentials;

namespace NewsApp
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            var systemDir = FileSystem.CacheDirectory;
            Utils.ExtractSavedResource("NewsApp.appsettings.json", systemDir);
            var fullConfig = Path.Combine(systemDir, "NewsApp.appsettings.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
                    c.AddJsonFile(fullConfig);
                })
                .ConfigureServices((c, x) =>
                {
                    ConfigureServices(c, x);
                })
                .Build();

            ServiceProvider = host.Services;
        }

        private static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            // MainApp
            services.AddSingleton<App>();

            // Services
            services.AddTransient<IArticlesService, ArticlesService>();

            // Views
            services.AddTransient<ArticlesPage>();

            // ViewModels
            services.AddTransient<ArticlesViewModel>();
            services.AddTransient<ArticleDetailsViewModel>();
        }
    }
}
