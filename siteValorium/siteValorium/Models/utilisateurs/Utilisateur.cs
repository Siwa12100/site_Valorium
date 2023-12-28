namespace siteValorium.Models.utilisateurs
{
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }

        public Utilisateur (int id, string nom, string description)
        {
            this.Id = id;
            this.Nom = nom;
            this.Description = description;
            this.DateCreation = DateTime.Now;
        }
    }
}
