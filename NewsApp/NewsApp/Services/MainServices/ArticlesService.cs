using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NewsApp.Configuration;
using NewsApp.Models;
using NewsApp.Services.Interfaces;
using Newtonsoft.Json;

namespace NewsApp.Services.MainServices
{
    public class ArticlesService : IArticlesService
    {
        public ArticlesService()
        {
        }

        public async Task<ArticleDetails> GetArticleDetailsFromAPI(string url)
        {
            try
            {
                var details = new ArticleDetails();

                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(NewsConfig.BaseAddressUrl);
                    var response = await client.GetStringAsync(url);

                    details = JsonConvert.DeserializeObject<ArticleDetails>(response);
                }

                return details;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Task<ArticleDetails> GetArticleDetailsFromDB(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Article>> GetArticlesFromAPI(int paggination)
        {
            try
            {
                var articles = new List<Article>();

                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(NewsConfig.BaseAddressUrl);
                    var response = await client.GetStringAsync(NewsConfig.ArticlesUrl(15, paggination));
                    var news = JsonConvert.DeserializeObject<News>(response);

                    articles = news.articles;
                }

                return articles;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Task<List<Article>> GetArticlesFromDB()
        {
            throw new NotImplementedException();
        }
    }
}
