namespace siteValorium.Models.Article
{
    public class StubArticles : IDataArticlesManager
    {
        public List<Article> getAllArticles()
        {
            List<Article> list = new List<Article>();

            Article a1 = new Article("Titre 1", "Description de l'Article 1");
            Article a2 = new Article("Titre 2", "Description de l'Article 2");
            Article a3 = new Article("Titre 3", "Description de l'Article 3");
            Article a4 = new Article("Titre 4", "Description de l'Article 4");

            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
            list.Add(a4);

            return list;
        }

        public StubArticles() {
        
        }
    }
}
