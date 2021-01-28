using Newtonsoft.Json;

namespace NewsApp.Models
{
    public class Article
    {
        public string title { get; set; }
        public string lead { get; set; }
        public string thumbnail { get; set; }
        public string photo { get; set; }
        public string url { get; set; }
        public string photogallery_url { get; set; }
        [JsonProperty("publish-date")]
        public string PublishDate { get; set; }

        public override string ToString()
        {
            string urlPart = @"/aplikacje_mobilne/newslab/artykul/";
            string jsonPart = @",json,id,type.html";

            return url.Replace(urlPart, "").Replace(jsonPart, "");
        }
    }
}
