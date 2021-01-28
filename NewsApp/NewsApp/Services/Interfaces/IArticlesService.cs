using System.Collections.Generic;
using System.Threading.Tasks;
using NewsApp.Models;

namespace NewsApp.Services.Interfaces
{
    public interface IArticlesService
    {
        Task<List<Article>> GetArticlesFromAPI(int paggination);
        Task<ArticleDetails> GetArticleDetailsFromAPI(string url);
        Task<List<Article>> GetArticlesFromDB();
        Task<ArticleDetails> GetArticleDetailsFromDB(int id);
    }
}
