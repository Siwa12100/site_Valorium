namespace siteValorium.Pages
{
    using siteValorium.Models.utilisateurs;
    public partial class PageUtilisateurs
    {
        public List<Utilisateur> utilisateurs;

        public PageUtilisateurs()
        {
            StubUtilisateurs stubUtilisateurs = new StubUtilisateurs();
            this.utilisateurs = stubUtilisateurs.getAllUtilisateurs();
        }
    }
}
