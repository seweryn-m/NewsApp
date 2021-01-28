using System.Collections.Generic;

namespace NewsApp.Models
{
    public class News
    {
        public List<Article> articles { get; set; }
        public string section { get; set; }
        public string newspaper { get; set; }
    }
}
