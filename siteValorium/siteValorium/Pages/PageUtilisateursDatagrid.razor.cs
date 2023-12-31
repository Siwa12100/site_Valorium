namespace siteValorium.Pages
{
    using Blazorise.DataGrid;
	using Blazored.LocalStorage;
    using siteValorium.Models.utilisateurs;
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    public partial class PageUtilisateursDatagrid
	{
		private List<Utilisateur> allUtilisateurs;
		private List<Utilisateur> utilisateursAffiches;
		private int totalUtilisateurs;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Utilisateur[] tab = await Http.GetFromJsonAsync<Utilisateur[]>($"{NavigationManager.BaseUri}utilisateursFake.json)");
            this.allUtilisateurs = tab.ToList();
        }

        private async Task OnReadData(DataGridReadDataEventArgs<Utilisateur> e)
		{
            StubUtilisateurs stub = new StubUtilisateurs();
            //this.utilisateursAffiches = stub.getAllUtilisateurs();
            this.utilisateursAffiches = this.allUtilisateurs;
		}
	}
}

