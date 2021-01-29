using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using NewsApp.Models;
using Xamarin.Forms;

namespace NewsApp.Configuration
{
    public class NewsDbContext : DbContext
    {
        private const string dbName = "news.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    dbPath =
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "..", "Library", dbName);
                    break;
                case Device.Android:
                    dbPath =
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                        dbName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleDetails> ArticlesDetails { get; set; }
    }
}
