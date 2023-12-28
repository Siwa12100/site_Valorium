namespace siteValorium.Models.utilisateurs
{
    public class StubUtilisateurs : IDataUtilisateursManager
    {
        protected List<Utilisateur> utilisateurs;
        public StubUtilisateurs()
        {
            this.utilisateurs = new List<Utilisateur> ();
            this.chargerUtilisateurs();

        }

        protected void chargerUtilisateurs()
        {
            Utilisateur utilisateur1 = new Utilisateur(1, "Alice", "Utilisateur principal, passionné de programmation et de nouvelles technologies.");
            Utilisateur utilisateur2 = new Utilisateur(2, "Bob", "Utilisateur secondaire, amateur de musique et de sports.");
            Utilisateur utilisateur3 = new Utilisateur(3, "Charlie", "Utilisateur tertiaire, passionné de photographie et de voyages.");
            Utilisateur utilisateur4 = new Utilisateur(4, "David", "Utilisateur quaternaire, adepte de jeux vidéo et de science-fiction.");
            Utilisateur utilisateur5 = new Utilisateur(5, "Eve", "Utilisateur quinaire, passionnée de lecture et d'art contemporain.");
            Utilisateur utilisateur6 = new Utilisateur(6, "Frank", "Utilisateur senaire, fan de cuisine asiatique et de randonnées en montagne.");
            Utilisateur utilisateur7 = new Utilisateur(7, "Grace", "Utilisateur septenaire, amatrice de danse et de yoga.");
            Utilisateur utilisateur8 = new Utilisateur(8, "Hank", "Utilisateur octonaire, amateur de jeux de société et de comédies musicales.");
            Utilisateur utilisateur9 = new Utilisateur(9, "Ivy", "Utilisateur nonaire, passionnée de jardinage et de musique classique.");
            Utilisateur utilisateur10 = new Utilisateur(10, "Jack", "Utilisateur décenaire, adepte de sports extrêmes et de cuisine fusion.");

            this.utilisateurs.Add(utilisateur1);
            this.utilisateurs.Add(utilisateur2);
            this.utilisateurs.Add(utilisateur3);
            this.utilisateurs.Add(utilisateur4);
            this.utilisateurs.Add(utilisateur5);
            this.utilisateurs.Add(utilisateur6);
            this.utilisateurs.Add(utilisateur7);
            this.utilisateurs.Add(utilisateur8);
            this.utilisateurs.Add(utilisateur9);
            this.utilisateurs.Add(utilisateur10);
        }

        public List<Utilisateur> getAllUtilisateurs()
        {
            return this.utilisateurs;
        }
    }
}
