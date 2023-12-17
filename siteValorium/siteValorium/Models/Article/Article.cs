namespace siteValorium.Models.Article
{
    public class Article
    {
        public String Titre { get; set; }
        public String Description { get; set; }

        public Article(String Titre, String Description)
        {
            this.Titre = Titre;
            this.Description = Description;
        }
    }
}
