using siteValorium.Models.Article;

using siteValorium.Models;
using System.Text.Json;

namespace siteValorium.Pages
{
    public partial class Index
    {
        public List<Article> lArticles;

        public Index()
        {
            IDataArticleManager manager = new StubArticles();
            this.lArticles = manager.getAllArticles();

            String jsonString = JsonSerializer.Serialize(this.lArticles);
            String filePath = Path.Combine("wwwroot", "data", "my-data.json");

            File.WriteAllTextAsync(filePath, jsonString);
        }
    }
}