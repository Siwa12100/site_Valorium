using siteValorium.Models.Article;

using siteValorium.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;

namespace siteValorium.Pages
{
    public partial class Index
    {
        public List<Article> lArticles;

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Index()
        {
            IDataArticleManager manager = new StubArticles();
            //this.lArticles = manager.getAllArticles();
        }

        protected override async Task OnInitializedAsync()
        {
            this.lArticles = await Http.GetFromJsonAsync<List<Article>>($"{NavigationManager.BaseUri}data/fake-data.json");
        }
    }
}