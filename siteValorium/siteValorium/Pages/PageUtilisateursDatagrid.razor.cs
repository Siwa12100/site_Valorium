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
			// Do not treat this action if is not the first render
			if (!firstRender)
			{
				return;
			}

			var currentData = await LocalStorage.GetItemAsync<Utilisateur[]>("data");

			// Check if data exist in the local storage
			if (currentData == null)
			{
				// this code add in the local storage the fake data (we load the data sync for initialize the data before load the OnReadData method)
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

			// When you use a real API, we use this follow code
			//var response = await Http.GetJsonAsync<Data[]>( $"http://my-api/api/data?page={e.Page}&pageSize={e.PageSize}" );
			var response = (await LocalStorage.GetItemAsync<Utilisateur[]>("data")).Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToList();

			if (!e.CancellationToken.IsCancellationRequested)
			{
				this.totalUtilisateurs = (await LocalStorage.GetItemAsync<List<Utilisateur>>("data")).Count;
				this.utilisateursAffiches = new List<Utilisateur>(response); // an actual data for the current page
			}
		}


		// Ancien code : 

		//      [Inject]
		//      public ILocalStorageService LocalStorage { get; set; }

		//      [Inject]
		//      public HttpClient Http { get; set; }

		//      [Inject]
		//      public NavigationManager NavigationManager { get; set; }

		//      protected override async Task OnInitializedAsync()
		//      {
		//          Utilisateur[] tab = await Http.GetFromJsonAsync<Utilisateur[]>($"{NavigationManager.BaseUri}utilisateursFake.json)");
		//          this.allUtilisateurs = tab.ToList();
		//      }

		//      private async Task OnReadData(DataGridReadDataEventArgs<Utilisateur> e)
		//{
		//          StubUtilisateurs stub = new StubUtilisateurs();
		//          //this.utilisateursAffiches = stub.getAllUtilisateurs();
		//          this.utilisateursAffiches = this.allUtilisateurs;
		//}
	}
}

