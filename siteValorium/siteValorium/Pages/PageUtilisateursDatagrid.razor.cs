namespace siteValorium.Pages
{
	using Blazorise.DataGrid;
	using siteValorium.Models.utilisateurs;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public partial class PageUtilisateursDatagrid
	{
		private List<Utilisateur> allUtilisateurs;
		private List<Utilisateur> utilisateursAffiches;
		private int totalUtilisateurs;

		protected override void OnInitialized()
		{
			// Initialisez vos données ici au lieu de le faire dans le constructeur
			StubUtilisateurs stub = new StubUtilisateurs();
			this.allUtilisateurs = stub.getAllUtilisateurs();

			// Assurez-vous de faire appel à la méthode de la classe de base
			base.OnInitialized();
		}

		private async Task OnReadData(DataGridReadDataEventArgs<Utilisateur> e)
		{
			// Utilisez les données déjà chargées, évitez de créer une nouvelle instance de StubUtilisateurs
			// Vous pouvez également ajouter un mécanisme de mise en cache pour éviter de charger les données à chaque fois
			this.utilisateursAffiches = this.allUtilisateurs.Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();
		}
	}
}

