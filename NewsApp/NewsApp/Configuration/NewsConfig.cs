using System;
using System.IO;
using Xamarin.Forms;

namespace NewsApp.Configuration
{
    public static class NewsConfig
    {
        public static string BaseAddressUrl = @"http://www.polskatimes.pl";

        public static string ArticlesUrl(int numberOfArticles, int paggination)
        {
            return $@"/aplikacje_mobilne/newslab/sekcja/polska,wiadomosci,{numberOfArticles},{paggination},json.html"; ;
        }

        public static string GetDbPath(string platform)
        {
            string dbPath;

            switch (platform)
            {
                case Device.iOS:
                    var dbDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        "..", "Library", "Databases");
                    if (!Directory.Exists(dbDirectory))
                        Directory.CreateDirectory(dbDirectory);

                    dbPath = Path.Combine(dbDirectory, "news.db");
                    return dbPath;
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                        "news.db");
                    return dbPath;
                default:
                    throw new NotImplementedException("Not supported platform");
            }
        }
    }
}
