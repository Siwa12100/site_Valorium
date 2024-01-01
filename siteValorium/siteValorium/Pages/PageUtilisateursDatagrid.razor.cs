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
	using Blazorise;

    public partial class PageUtilisateursDatagrid
	{
		private List<Utilisateur> allUtilisateurs;
		private List<Utilisateur> utilisateursAffiches;
		private int totalUtilisateurs;

		[Inject]
		public HttpClient Http { get; set; }

		[Inject]
		public ILocalStorageService LocalStorage { get; set; }

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		protected override async Task OnAfterRenderAsync(bool firstRender)
		{
			if (!firstRender)
			{
				return;
			}

			var currentData = await LocalStorage.GetItemAsync<Utilisateur[]>("data");

			if (currentData == null)
			{
				var originalData = Http.GetFromJsonAsync<Utilisateur[]>($"{NavigationManager.BaseUri}data/utilisateursFake.json").Result;
				await LocalStorage.SetItemAsync("data", originalData);
			}
		}

		private async Task OnReadData(DataGridReadDataEventArgs<Utilisateur> e)
		{
			if (e.CancellationToken.IsCancellationRequested)
			{
				return;
			}

			var response = (await LocalStorage.GetItemAsync<Utilisateur[]>("data")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

			if (!e.CancellationToken.IsCancellationRequested)
			{
				this.totalUtilisateurs = (await LocalStorage.GetItemAsync<List<Utilisateur>>("data")).Count;
				this.utilisateursAffiches = new List<Utilisateur>(response);
			}
		}
	}
}

