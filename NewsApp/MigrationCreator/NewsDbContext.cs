using Microsoft.EntityFrameworkCore;
using NewsApp.Models;

namespace MigrationCreator
{
    public class NewsDbContext : DbContext
    {
        private const string dbName = "news.db";

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.UseSqlite($"{dbName}");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleDetails> ArticlesDetails { get; set; }
    }
}
