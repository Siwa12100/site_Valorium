namespace siteValorium.Models.utilisateurs
{
    public class Utilisateur
    {
        protected int Id { get; set; }
        protected string Nom { get; set; }
        protected string Description { get; set; }
        protected DateTime DateCreation { get; set; }

        public Utilisateur (int id, string nom, string description)
        {
            this.Id = id;
            this.Nom = nom;
            this.Description = description;
            this.DateCreation = DateTime.Now;
        }
    }
}
